using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm
{
    public partial class frmCategorias : Form
    {
        List<Categoria> listaCategoria;
        private Categoria categoria = null;
        private CategoriaNegocio negocio = new CategoriaNegocio();
        private bool esEdicion = false;

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAgregarArticulo frmAgregarArticulo = new frmAgregarArticulo();
            frmAgregarArticulo.ShowDialog();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategorias frmCategorias = new frmCategorias();
            frmCategorias.ShowDialog();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMarcas frmMarcas = new frmMarcas();
            frmMarcas.ShowDialog();
        }

        public frmCategorias()
        {
            InitializeComponent();
            this.Text = "Categorias";
            cargar();
        }
        public frmCategorias(Categoria categoria)
        {
            InitializeComponent();
            this.categoria = categoria;
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            cargar();
        }

        private void cargar()
        {
            listaCategoria = negocio.listar();

            try
            {
                if (listaCategoria.Count > 0)
                {
                    dgvListaCategorias.DataSource = listaCategoria;
                    dgvListaCategorias.Refresh();
                }
                else
                {
                    MessageBox.Show("No hay categorias disponibles para mostrar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Categoria> filtroCat;
            string filtro = txtFiltro.Text;

            if (filtro.Length >= 1)
            {
                filtroCat = listaCategoria.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                filtroCat = listaCategoria;
            }

            dgvListaCategorias.DataSource = null;
            dgvListaCategorias.DataSource = filtroCat;
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtFiltro.Text = string.Empty;
            cargar();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            esEdicion = false;
            txtModificar.Visible = false;
            lblTitulo.Visible = true;
            txtDescripcion.Visible = true;
            btnAplicar.Visible = true;
            btnCancelar.Visible = true;
            txtModificado.Text = string.Empty;
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            lblTitulo.Visible = true;
            txtDescripcion.Visible = true;
            txtModificar.Visible = true;
            btnAplicar.Visible = true;
            btnCancelar.Visible = true;

            if (dgvListaCategorias.CurrentRow != null)
            {
                esEdicion = true;
                Categoria seleccionado = (Categoria)dgvListaCategorias.CurrentRow.DataBoundItem;
                frmCategorias frmEditarCategoria = new frmCategorias(seleccionado);
                txtModificado.Text = seleccionado.Descripcion;
            }
            else
            {
                MessageBox.Show("Seleccione una categoría para editar");
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {
                if (esEdicion && dgvListaCategorias.CurrentRow != null)
                {
                    categoria = (Categoria)dgvListaCategorias.CurrentRow.DataBoundItem;
                    categoria.Descripcion = txtDescripcion.Text;
                    negocio.modificar(categoria.Id, categoria.Descripcion);
                    MessageBox.Show("Categoría actualizada exitosamente.");
                }
                else
                {
                    Categoria nueva = new Categoria();
                    nueva.Descripcion = txtDescripcion.Text;
                    negocio.agregar(nueva);
                    MessageBox.Show("Categoría agregada exitosamente.");
                }

                cargar();
                txtDescripcion.Text = string.Empty;
                categoria = null;

                lblTitulo.Visible = false;
                txtDescripcion.Visible = false;
                btnAplicar.Visible = false;
                btnCancelar.Visible = false;
                esEdicion = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar o modificar la categoría: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) 
        {

            lblTitulo.Visible = false;
            txtDescripcion.Visible = false;
            txtModificar.Visible = false;
            txtModificado.Text = string.Empty;
            btnAplicar.Visible = false;
            btnCancelar.Visible = false;
            txtDescripcion.Text = string.Empty;

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListaCategorias.CurrentRow != null)
            {
                Categoria seleccionado = (Categoria)dgvListaCategorias.CurrentRow.DataBoundItem;
                CategoriaNegocio negocio = new CategoriaNegocio();
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Seguro deseas Eliminar?", "Eliminar", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        negocio.eliminar(seleccionado.Id);
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        cargar();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo eliminar");
                }
                cargar();
            }
            else
            {
                MessageBox.Show("Seleccione un articulo para eliminar");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }


}
