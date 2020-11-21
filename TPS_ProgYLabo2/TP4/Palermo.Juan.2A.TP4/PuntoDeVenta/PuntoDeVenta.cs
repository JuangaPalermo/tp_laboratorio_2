using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntoDeVenta
{
    public partial class PuntoDeVenta : Form
    {
        public PuntoDeVenta()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void tsmAgregarNuevo_Click(object sender, EventArgs e)
        {
            NuevoProducto np = new NuevoProducto();

            if(np.ShowDialog() == DialogResult.OK)
            {
                ListadoProductos lp = new ListadoProductos();

                try
                {
                    DataRow fila = lp.dt.NewRow();
                
                    if(np.t != null)
                    {
                        fila["Tipo"] = np.t.Tipo;
                        fila["Nombre"] = np.t.Nombre;
                        fila["Marca"] = np.t.MarcaProducto;
                        fila["Precio"] = np.t.Precio;

                        lp.dt.Rows.Add(fila);
                    }
                    else
                    {
                        fila["Tipo"] = np.m.Tipo;
                        fila["Nombre"] = np.m.Nombre;
                        fila["Marca"] = np.m.MarcaProducto;
                        fila["Precio"] = np.m.Precio;

                        lp.dt.Rows.Add(fila);
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

        private void tsmModificar_Click(object sender, EventArgs e)
        {

        }

        private void tsmEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {

        }

        private void btnVerDisponibles_Click(object sender, EventArgs e)
        {
            ListadoProductos lp = new ListadoProductos();

            try
            {
                lp.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
    }
}
