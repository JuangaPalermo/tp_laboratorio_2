using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases_Instanciables;
using Clases_Abstractas;
using static Clases_Abstractas.Periferico;

namespace PuntoDeVenta
{
    public partial class NuevoProducto : Form
    {

        public Teclado t;
        public Mouse m;

        public NuevoProducto()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtNombre.Text != null && txtPrecio.Text != null && cbMarca.Text != null && cbProducto.Text != null)
            {
                switch(cbProducto.SelectedIndex)
                {
                    case 0: //selecciona teclado
                        t = new Teclado(MapeoTipoGenero(cbMarca.Text), txtPrecio.Text, txtNombre.Text);
                        break;
                    case 1: //selecciona mouse
                        m = new Mouse(MapeoTipoGenero(cbMarca.Text), txtPrecio.Text, txtNombre.Text);
                        break;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            else
            {
                MessageBox.Show("Falta ingresar uno de los campos!");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public static Marca MapeoTipoGenero(string aux)
        {
            switch (aux)
            {
                case "HyperX":
                    return Marca.HyperX;
                case "Gigabyte":
                    return Marca.Gigabyte;
                case "Razer":
                    return Marca.Razer;
                case "Logitech":
                    return Marca.Logitech;
                default:
                    return Marca.OtraMarca;
            }
        }
    }
}
