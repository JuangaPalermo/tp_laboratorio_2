﻿using System;
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


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (this.CBOperador.SelectedItem == null)
            {
                
                this.CBOperador.Text = "+";

            }

            this.LabelResultado.Text = Convert.ToString(Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.CBOperador.Text));
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (this.LabelResultado.Text != "Valor invalido" && this.LabelResultado.Text != "")
            {
                this.LabelResultado.Text = Numero.DecimalBinario(Convert.ToDouble(this.LabelResultado.Text));                
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if(this.LabelResultado.Text != "Valor invalido" && this.LabelResultado.Text != "")
            {
                this.LabelResultado.Text = Numero.BinarioDecimal(this.LabelResultado.Text);
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
            DialogResult rta = MessageBox.Show("¿Está seguro de salir?", "Atención",
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
            this.CBOperador.ResetText();
            this.CBOperador.Text = null;
            this.LabelResultado.Text = null;
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
