using System;
using System.Windows.Forms;
using Clases_Instanciables;

namespace PuntoDeVenta
{
    public partial class NuevoProducto : Form
    {
        #region Atributos

        public Teclado t;
        public Mouse m;

        #endregion

        #region Constructor
        public NuevoProducto()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento del boton aceptar. Si se oprime, el dialogResult pasara a ser OK.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtPrecio.Text != "" && cbMarca.Text != "" && cbProducto.Text != "")
            {
                switch (cbProducto.SelectedIndex)
                {
                    case 0: //selecciona teclado
                        t = new Teclado(Periferico.MapeoTipoMarca(cbMarca.Text), txtPrecio.Text, txtNombre.Text);
                        break;
                    case 1: //selecciona mouse
                        m = new Mouse(Periferico.MapeoTipoMarca(cbMarca.Text), txtPrecio.Text, txtNombre.Text);
                        break;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            else
            {
                MessageBox.Show("Falta ingresar uno de los campos!");
            }
        }

        /// <summary>
        /// evento del boton cancelar. Si se oprime, el dialog result sera Cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        #endregion

    }
}
