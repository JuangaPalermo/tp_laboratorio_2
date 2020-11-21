using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class ListadoProductos : Form
    {
        #region Atributos

        public SqlDataAdapter da;
        public DataTable dt;
        public SqlConnection cn;

        #endregion

        #region Constructor
        public ListadoProductos()
        {
            InitializeComponent();
            
            try
            {
                CrearDataTable();
                ConfigurarGrilla();
                ConfigurarDataAdapter();
                CargarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #endregion

        #region Eventos

        #endregion

        #region Metodos

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

        #endregion
    }
}
