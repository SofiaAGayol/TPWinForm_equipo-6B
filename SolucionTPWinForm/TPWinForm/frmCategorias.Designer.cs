namespace TPWinForm
{
    partial class frmCategorias
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnLimpiarFiltros = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.dgvListaCategorias = new System.Windows.Forms.DataGridView();
            this.txtModificar = new System.Windows.Forms.Label();
            this.txtModificado = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCategorias)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(279, 407);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(106, 13);
            this.lblTitulo.TabIndex = 56;
            this.lblTitulo.Text = "Nueva Categoria:";
            this.lblTitulo.Visible = false;
            // 
            // btnAplicar
            // 
            this.btnAplicar.Location = new System.Drawing.Point(591, 402);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(62, 23);
            this.btnAplicar.TabIndex = 54;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Visible = false;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(391, 402);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(164, 23);
            this.txtDescripcion.TabIndex = 52;
            this.txtDescripcion.Visible = false;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(166, 402);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(79, 23);
            this.btnEliminar.TabIndex = 51;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(89, 402);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 50;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(12, 402);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 49;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(307, 44);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(94, 23);
            this.btnLimpiarFiltros.TabIndex = 48;
            this.btnLimpiarFiltros.Text = "Limpiar Filtros";
            this.btnLimpiarFiltros.UseVisualStyleBackColor = true;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
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
            this.menuStrip1.Size = new System.Drawing.Size(735, 25);
            this.menuStrip1.TabIndex = 47;
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
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(87, 44);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(185, 20);
            this.txtFiltro.TabIndex = 46;
            this.txtFiltro.TextChanged += new System.EventHandler(this.txtFiltro_TextChanged);
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(12, 48);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(69, 13);
            this.lblFiltro.TabIndex = 45;
            this.lblFiltro.Text = "Filtro Rápido:";
            // 
            // dgvListaCategorias
            // 
            this.dgvListaCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListaCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaCategorias.Location = new System.Drawing.Point(12, 80);
            this.dgvListaCategorias.MultiSelect = false;
            this.dgvListaCategorias.Name = "dgvListaCategorias";
            this.dgvListaCategorias.ReadOnly = true;
            this.dgvListaCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListaCategorias.Size = new System.Drawing.Size(709, 316);
            this.dgvListaCategorias.TabIndex = 44;
            // 
            // txtModificar
            // 
            this.txtModificar.AutoSize = true;
            this.txtModificar.Location = new System.Drawing.Point(388, 430);
            this.txtModificar.Name = "txtModificar";
            this.txtModificar.Size = new System.Drawing.Size(109, 13);
            this.txtModificar.TabIndex = 57;
            this.txtModificar.Text = "Categoria a modificar:";
            this.txtModificar.Visible = false;
            // 
            // txtModificado
            // 
            this.txtModificado.AutoSize = true;
            this.txtModificado.Location = new System.Drawing.Point(503, 431);
            this.txtModificado.Name = "txtModificado";
            this.txtModificado.Size = new System.Drawing.Size(0, 13);
            this.txtModificado.TabIndex = 58;
            this.txtModificado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(627, 449);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(94, 23);
            this.btnAceptar.TabIndex = 59;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(659, 402);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(62, 23);
            this.btnCancelar.TabIndex = 55;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 488);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtModificado);
            this.Controls.Add(this.txtModificar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnLimpiarFiltros);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.lblFiltro);
            this.Controls.Add(this.dgvListaCategorias);
            this.Name = "frmCategorias";
            this.Text = "frmCategorias";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnLimpiarFiltros;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcasToolStripMenuItem;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.DataGridView dgvListaCategorias;
        private System.Windows.Forms.Label txtModificar;
        private System.Windows.Forms.Label txtModificado;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}