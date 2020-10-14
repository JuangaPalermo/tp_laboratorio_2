using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculador : Form
    {
        
        #region FIELDS
        public FormCalculador()
        {
            InitializeComponent();
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (this.cmbOperador.Text != "-" && this.cmbOperador.Text != "/" && this.cmbOperador.Text != "*")
            {
                
                this.cmbOperador.Text = "+";

            }

            this.lblResultado.Text = Convert.ToString(Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(this.lblResultado.Text == Double.MinValue.ToString())
            {
                this.lblResultado.Text = Numero.DecimalBinario(Double.MinValue);
            }
            else
            {
                if (this.lblResultado.Text != "Valor invalido" && this.lblResultado.Text != "")
                {
                    this.lblResultado.Text = Numero.DecimalBinario(Convert.ToDouble(this.lblResultado.Text));
                }
            }
            
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if(this.lblResultado.Text != "Valor invalido" && this.lblResultado.Text != "")
            {
                this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
            }
        }

        #endregion

        #region EVENTS

        private void FormCalculador_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void FormCalculador_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Seguro de querer salir?", "Salir",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                                MessageBoxDefaultButton.Button2);

            if (rta == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region METODOS

        private void Limpiar()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.ResetText();
            this.cmbOperador.Text = null;
            this.lblResultado.Text = null;
        }

        public static double Operar(string numero1, string numero2, string operador)
        {
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            return Calculadora.Operar(num1, num2, operador);
        }


        #endregion

    }
}
