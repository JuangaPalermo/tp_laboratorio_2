using Archivos;
using Bases_de_Datos;
using Clases_Instanciables;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using static Clases_Instanciables.Periferico;
using Extension;
using Excepciones;

namespace PuntoDeVenta
{
    public partial class PuntoDeVenta : Form
    {

        #region Atributos

        public SqlDataAdapter da;
        public DataTable dt;
        public SqlConnection cn;

        //acumulador de los productos que se van seleccionando
        Compra<Periferico> compra;

        //hilo que se utilizara para actualizar automaticamente el DataTable
        Thread hiloDataTable;

        //path que va a contener los productos guardados en la BBDD
        private const String PATH_XML_PRODUCTOS = "DataTableProductosDatos.xml";
        //path que va a contener el esqueleto de mi Data Table. 
        private const String PATH_XML_PRODUCTOS_SCHEMA = "DataTableProductosSchema.xml";

        #endregion

        #region Constructor
        public PuntoDeVenta()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #endregion

        #region Eventos

        #region ToolStripMenu

        /// <summary>
        /// Permitira agregar un nuevo producto a la Base de datos. Ademas, esto disparara un hilo que hara que la misma se actualice
        /// automaticamente durante la ejecucion del programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmAgregarNuevo_Click(object sender, EventArgs e)
        {
            NuevoProducto np = new NuevoProducto();

            if (np.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (np.t != null)
                    {
                        ConexionBD<Teclado>.InsertProducto(np.t);
                    }
                    else
                    {
                        ConexionBD<Mouse>.InsertProducto(np.m);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                
            }
            else
            {
                MessageBox.Show("Usted ha cancelado la adicion");
            }
        }


        #endregion

        #region Buttons

        /// <summary>
        /// Agrega el producto que se selecciona desde el DataTable a la compra, y actualiza el ticket para que muestre los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            try
            {
                int indice = this.dgvGrilla.SelectedRows[0].Index;

                DataRow fila = this.dt.Rows[indice];

                string tipo = fila["Tipo"].ToString();
                Marca marca = MapeoTipoMarca(fila["Marca"].ToString());
                float precio = float.Parse(fila["Precio"].ToString());
                string nombre = fila["Nombre"].ToString();

                switch (tipo)
                {
                    case "Teclado":
                        Teclado t = new Teclado(marca, precio, nombre);
                        compra.Agregar(t);
                        break;
                    case "Mouse":
                        Mouse m = new Mouse(marca, precio, nombre);
                        compra.Agregar(m);
                        break;
                }

                txtVisorTickets.Text = "";
                txtVisorTickets.Text += compra.MostrarCompra(compra);

                if (compra.PrecioTotal > 20000)
                {
                    compra.PremioAlcanzado = null;
                    compra.PremioAlcanzado += compra_EventoPrecio;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Si tiene informacion, descarga el contenido txtVisorTickets, en un archivo de tecto llamado Ticket.txt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDescargar_Click(object sender, EventArgs e)
        {
            if (txtVisorTickets.Text != "")
            {
                try
                {
                    Texto aux = new Texto();

                    aux.Guardar("Ticket.txt", txtVisorTickets.Text);

                    MessageBox.Show("El ticket se ha impreso correctamente");

                }
                catch (ArchivosException)
                {
                    MessageBox.Show("Error al querer imprimir el ticket");
                }
            }
            else
            {
                MessageBox.Show("El ticket no tiene contenido!");
            }

        }

        /// <summary>
        /// Muestra la informacion del Row seleccionado del DataTable, a traves de un metodo de extension.
        /// Este metodo de extension, agregara la informacion de la garantia del producto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarInfoDetallada_Click(object sender, EventArgs e)
        {
            try
            {
                int indice = this.dgvGrilla.SelectedRows[0].Index;

                DataRow fila = this.dt.Rows[indice];

                string tipo = fila["Tipo"].ToString();
                Marca marca = MapeoTipoMarca(fila["Marca"].ToString());
                float precio = float.Parse(fila["Precio"].ToString());
                string nombre = fila["Nombre"].ToString();

                switch (tipo)
                {
                    case "Teclado":
                        Teclado t = new Teclado(marca, precio, nombre);
                        MessageBox.Show(t.ObtenerInfoExtendida());
                        break;
                    case "Mouse":
                        Mouse m = new Mouse(marca, precio, nombre);
                        MessageBox.Show(m.ObtenerInfoExtendida());
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Al confirmar la compra, se reseta para poder cargar una nueva. Ademas, en caso de que el cliente haya superado los 20000
        /// arrojara el evento PremioAlcanzado, informandole al cajero que debe darle un voucher de descuento para su proxima compra.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (compra.PrecioTotal > 20000 && compra.PremioAlcanzado != null)
            {
                compra.PremioAlcanzado.Invoke(compra, EventArgs.Empty);
            }

            ResetearCompra();
        }


        #endregion

        #region Ciclo de Vida 

        /// <summary>
        /// Evento load del formulario, configurara el data table y el data adapter, y lo llenara automaticamente con la informacion
        /// que se encuentra en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PuntoDeVenta_Load(object sender, EventArgs e)
        {

            try
            {
                CrearDataTable();
                ConfigurarGrilla();
                ConfigurarDataAdapter();
                CargarGrilla();
                compra = new Compra<Periferico>();

                try
                {
                    hiloDataTable = new Thread(this.CargarGrillaHilo);
                    hiloDataTable.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Evento formClosing, generara automaticamente la serializacion del dataTable (Contenido y Schema), y abortara
        /// el hilo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PuntoDeVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GuardarXml())
            {
                MessageBox.Show("Se ha serializado el contenido actualizado del deposito");
            }

            try
            {
                hiloDataTable.Abort();
            }
            catch (ThreadAbortException)
            {

            }
        }

        #endregion

        #region Evento Precio

        /// <summary>
        /// Evento precio, arroja un MessageBox que le informa al cajero que debe darle un voucher de descuento al cliente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void compra_EventoPrecio(object sender, EventArgs e)
        {
            MessageBox.Show("El cliente ha alcanzado el premio, entregarle cupon de descuento para su proxima compra.");
            this.compra.PremioAlcanzado = null;
        }

        #endregion

        #endregion

        #region Metodos

        /// <summary>
        /// Crea el data table en el form principal
        /// </summary>
        /// <returns>true si lo crea correctamente, false si lanza excepcion</returns>
        private bool CrearDataTable()
        {
            bool res = true;

            try
            {
                this.dt = new DataTable("Producto");

                this.dt.Columns.Add("Id", typeof(int));
                this.dt.Columns.Add("Tipo", typeof(string));
                this.dt.Columns.Add("Nombre", typeof(string));
                this.dt.Columns.Add("Marca", typeof(string));
                this.dt.Columns.Add("Precio", typeof(float));

                this.dt.PrimaryKey = new DataColumn[] { this.dt.Columns[0] };

                this.dt.Columns["Id"].AutoIncrement = true;
                this.dt.Columns["Id"].AutoIncrementSeed = 1;
                this.dt.Columns["Id"].AutoIncrementStep = 1;
            }
            catch
            {
                res = false;
            }

            return res;
        }
        

        /// <summary>
        /// Configura la grilla del Data Grid View
        /// </summary>
        /// <returns>true si lo hace correctamente, false si lanza excepcion</returns>
        private bool ConfigurarGrilla()
        {
            bool res = true;

            try
            {
                //Color de fondo para las filas
                this.dgvGrilla.RowsDefaultCellStyle.BackColor = Color.Coral;

                //Defino las caracteristicas de los encabezados
                this.dgvGrilla.ColumnHeadersDefaultCellStyle.Font = new Font(dgvGrilla.Font, FontStyle.Bold);
                this.dgvGrilla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //Color de las lineas de separacion
                this.dgvGrilla.GridColor = Color.Black;

                //Evito la multiseleccion
                this.dgvGrilla.MultiSelect = false;

                //Genero que solo se pueda editar a traves de codigo (no graficamente)
                this.dgvGrilla.EditMode = DataGridViewEditMode.EditProgrammatically;

                //Selecciono toda la grilla a la vez
                this.dgvGrilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                //Saco los encabezados de las filas
                this.dgvGrilla.RowHeadersVisible = false;

                //Hago que se ajusten automaticamente en tamaño
                this.dgvGrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                this.dgvGrilla.DataSource = this.dt;
            }
            catch
            {
                res = false;
            }

            return res;
        }

        /// <summary>
        /// Configura el data adapter
        /// </summary>
        /// <returns>true si lo hace correctamente, false si lanza error</returns>
        private bool ConfigurarDataAdapter()
        {
            bool rta = true;

            try
            {
                cn = new SqlConnection(Properties.Settings.Default.conexion);

                this.da = new SqlDataAdapter();

                this.da.SelectCommand = new SqlCommand("SELECT * FROM productos", cn);
                this.da.InsertCommand = new SqlCommand("INSERT INTO productos (Tipo, Nombre, Marca, Precio)" +
                                                       "VALUES (@Tipo, @Nombre, @Marca, @Precio)", cn);
                this.da.UpdateCommand = new SqlCommand("UPDATE productos SET Tipo=@Tipo, Nombre=@Nombre, Marca=@Marca, " +
                                                       "Precio=@Precio WHERE Id=@Id", cn);
                this.da.DeleteCommand = new SqlCommand("DELETE FROM producto WHERE Id=@Id", cn);

                this.da.InsertCommand.Parameters.Add("@Tipo", SqlDbType.VarChar, 50, "Tipo");
                this.da.InsertCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50, "Nombre");
                this.da.InsertCommand.Parameters.Add("@Marca", SqlDbType.VarChar, 50, "Marca");
                this.da.InsertCommand.Parameters.Add("@Precio", SqlDbType.Float, 10, "Precio");

                this.da.UpdateCommand.Parameters.Add("@Tipo", SqlDbType.VarChar, 50, "Tipo");
                this.da.UpdateCommand.Parameters.Add("@Nombre", SqlDbType.VarChar, 50, "Nombre");
                this.da.UpdateCommand.Parameters.Add("@Marca", SqlDbType.VarChar, 50, "Marca");
                this.da.UpdateCommand.Parameters.Add("@Precio", SqlDbType.Float, 10, "Precio");
                this.da.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 10, "Id");

                this.da.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 10, "Id");
            }
            catch (Exception e)
            {
                rta = false;
                MessageBox.Show(e.Message);
            }

            return rta;

        }

        /// <summary>
        /// Cargara la grilla configurada con los datos del dt
        /// </summary>
        /// <returns>true si lo hace correctamente, de lo contrario, false</returns>
        private bool CargarGrilla()
        {
            bool res = true;

            try
            {
                this.da.Fill(this.dt);
            }
            catch (Exception e)
            {
                res = false;
                MessageBox.Show(e.Message);
            }

            return res;
        }

        /// <summary>
        /// Reinicia los elementos de la compra, el estado del pemio, y el contenido del visor de tickets, para que se pueda agregar
        /// una compra nueva luego de confirmar la anterior.
        /// </summary>
        private void ResetearCompra()
        {
            compra.Elementos.Clear();
            compra.PremioAlcanzado = null;
            txtVisorTickets.Text = "";
        }

        /// <summary>
        /// Metodo que ejecutara el Hilo, haciendo que la grilla se actualice automaticamente cada 3000MS.
        /// </summary>
        private void CargarGrillaHilo()
        {
            try
            {
                do
                {
                    try
                    {
                        this.da.Fill(this.dt);
                        Thread.Sleep(3000);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                                 
        }

        /// <summary>
        /// Serializa el Schema y el contenido del DataTable en un archivo XML
        /// </summary>
        /// <returns>true si lo hace correctamente, sino, false.</returns>
        private bool GuardarXml()
        {
            bool res = true;

            try
            {
                this.dt.WriteXmlSchema(PATH_XML_PRODUCTOS_SCHEMA);
                this.dt.WriteXml(PATH_XML_PRODUCTOS);
            }
            catch (Exception e)
            {
                res = false;
                MessageBox.Show(e.Message);
            }

            return res;
        }

        #endregion
    }
}
