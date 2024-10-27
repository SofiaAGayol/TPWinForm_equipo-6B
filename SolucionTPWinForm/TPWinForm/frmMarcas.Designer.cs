namespace TPWinForm
{
    partial class frmMarcas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvListaMarcas = new System.Windows.Forms.DataGridView();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtModificado = new System.Windows.Forms.Label();
            this.txtModificar = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMarcas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(87, 45);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(185, 20);
            this.txtFiltro.TabIndex = 12;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(12, 49);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(69, 13);
            this.lblFiltro.TabIndex = 11;
            this.lblFiltro.Text = "Filtro Rápido:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articulosToolStripMenuItem,
            this.categoriasToolStripMenuItem,
            this.marcasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(742, 25);
            this.menuStrip1.TabIndex = 31;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            this.articulosToolStripMenuItem.Text = "Artículos";
            this.articulosToolStripMenuItem.Click += new System.EventHandler(this.articulosToolStripMenuItem_Click);
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            this.categoriasToolStripMenuItem.Text = "Categorías";
            this.categoriasToolStripMenuItem.Click += new System.EventHandler(this.categoriasToolStripMenuItem_Click);
            // 
            // marcasToolStripMenuItem
            // 
            this.marcasToolStripMenuItem.Name = "marcasToolStripMenuItem";
            this.marcasToolStripMenuItem.Size = new System.Drawing.Size(63, 21);
            this.marcasToolStripMenuItem.Text = "Marcas";
            this.marcasToolStripMenuItem.Click += new System.EventHandler(this.marcasToolStripMenuItem_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(307, 45);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(94, 23);
            this.btnLimpiarFiltros.TabIndex = 32;
            this.btnLimpiarFiltros.Text = "Limpiar Filtros";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(168, 396);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 23);
            this.btnEliminar.TabIndex = 54;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(91, 396);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 53;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(14, 396);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 52;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvListaMarcas
            // 
            this.dgvListaMarcas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListaMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaMarcas.Location = new System.Drawing.Point(15, 74);
            this.dgvListaMarcas.MultiSelect = false;
            this.dgvListaMarcas.Name = "dgvListaMarcas";
            this.dgvListaMarcas.ReadOnly = true;
            this.dgvListaMarcas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaMarcas.Size = new System.Drawing.Size(707, 316);
            this.dgvListaMarcas.TabIndex = 55;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(628, 443);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(94, 23);
            this.btnAceptar.TabIndex = 66;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtModificado
            // 
            this.txtModificado.AutoSize = true;
            this.txtModificado.Location = new System.Drawing.Point(470, 424);
            this.txtModificado.Name = "txtModificado";
            this.txtModificado.Size = new System.Drawing.Size(0, 13);
            this.txtModificado.TabIndex = 65;
            this.txtModificado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModificar
            // 
            this.txtModificar.AutoSize = true;
            this.txtModificar.Location = new System.Drawing.Point(370, 424);
            this.txtModificar.Name = "txtModificar";
            this.txtModificar.Size = new System.Drawing.Size(94, 13);
            this.txtModificar.TabIndex = 64;
            this.txtModificar.Text = "Marca a modificar:";
            this.txtModificar.Visible = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(280, 401);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(87, 13);
            this.lblTitulo.TabIndex = 63;
            this.lblTitulo.Text = "Nueva Marca:";
            this.lblTitulo.Visible = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(660, 396);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(62, 23);
            this.btnCancelar.TabIndex = 62;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(592, 396);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(62, 23);
            this.btnAplicar.TabIndex = 61;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Visible = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(373, 396);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(183, 23);
            this.txtDescripcion.TabIndex = 60;
            this.txtDescripcion.Visible = false;
            // 
            // frmMarcas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 484);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtModificado);
            this.Controls.Add(this.txtModificar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.dgvListaMarcas);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnLimpiarFiltros);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.lblFiltro);
            this.Name = "frmMarcas";
            this.Text = "frmMarcas";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaMarcas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvListaMarcas;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label txtModificado;
        private System.Windows.Forms.Label txtModificar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.TextBox txtDescripcion;
    }
}