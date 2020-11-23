namespace PuntoDeVenta
{
    partial class PuntoDeVenta
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtVisorTickets = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.depositoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAgregarNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMostrarInfoDetallada = new System.Windows.Forms.Button();
            this.btnDescargar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.dgvGrilla = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).BeginInit();
            this.SuspendLayout();
            // 
            // txtVisorTickets
            // 
            this.txtVisorTickets.BackColor = System.Drawing.Color.White;
            this.txtVisorTickets.Location = new System.Drawing.Point(211, 45);
            this.txtVisorTickets.Multiline = true;
            this.txtVisorTickets.Name = "txtVisorTickets";
            this.txtVisorTickets.ReadOnly = true;
            this.txtVisorTickets.Size = new System.Drawing.Size(205, 269);
            this.txtVisorTickets.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Ticket de la compra";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(25, 45);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(161, 30);
            this.btnAgregar.TabIndex = 29;
            this.btnAgregar.Text = "Agregar a la compra";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.depositoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(996, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // depositoToolStripMenuItem
            // 
            this.depositoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAgregarNuevo});
            this.depositoToolStripMenuItem.Name = "depositoToolStripMenuItem";
            this.depositoToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.depositoToolStripMenuItem.Text = "Deposito";
            // 
            // tsmAgregarNuevo
            // 
            this.tsmAgregarNuevo.Name = "tsmAgregarNuevo";
            this.tsmAgregarNuevo.Size = new System.Drawing.Size(168, 22);
            this.tsmAgregarNuevo.Text = "Agregar producto";
            this.tsmAgregarNuevo.Click += new System.EventHandler(this.tsmAgregarNuevo_Click);
            // 
            // btnMostrarInfoDetallada
            // 
            this.btnMostrarInfoDetallada.Location = new System.Drawing.Point(25, 128);
            this.btnMostrarInfoDetallada.Name = "btnMostrarInfoDetallada";
            this.btnMostrarInfoDetallada.Size = new System.Drawing.Size(161, 29);
            this.btnMostrarInfoDetallada.TabIndex = 33;
            this.btnMostrarInfoDetallada.Text = "Mostrar info del producto";
            this.btnMostrarInfoDetallada.UseVisualStyleBackColor = true;
            this.btnMostrarInfoDetallada.Click += new System.EventHandler(this.btnMostrarInfoDetallada_Click);
            // 
            // btnDescargar
            // 
            this.btnDescargar.Location = new System.Drawing.Point(25, 206);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(161, 28);
            this.btnDescargar.TabIndex = 34;
            this.btnDescargar.Text = "Descargar ticket de compra";
            this.btnDescargar.UseVisualStyleBackColor = true;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.Location = new System.Drawing.Point(25, 286);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(161, 28);
            this.btnConfirmar.TabIndex = 35;
            this.btnConfirmar.Text = "Confirmar compra";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // dgvGrilla
            // 
            this.dgvGrilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrilla.Location = new System.Drawing.Point(432, 45);
            this.dgvGrilla.Name = "dgvGrilla";
            this.dgvGrilla.Size = new System.Drawing.Size(552, 266);
            this.dgvGrilla.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(666, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Productos en el deposito";
            // 
            // PuntoDeVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(996, 326);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvGrilla);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnDescargar);
            this.Controls.Add(this.btnMostrarInfoDetallada);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVisorTickets);
            this.Controls.Add(this.menuStrip1);
            this.Name = "PuntoDeVenta";
            this.Text = "Punto de venta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PuntoDeVenta_FormClosing);
            this.Load += new System.EventHandler(this.PuntoDeVenta_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrilla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVisorTickets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem depositoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmAgregarNuevo;
        private System.Windows.Forms.Button btnMostrarInfoDetallada;
        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.DataGridView dgvGrilla;
        private System.Windows.Forms.Label label2;
    }
}

