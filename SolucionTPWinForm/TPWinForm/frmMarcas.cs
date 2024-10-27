using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm
{
    public partial class frmMarcas : Form
    {
        List<Marca> listaMarcas;
        private Marca marca = null;
        private MarcaNegocio negocio = new MarcaNegocio();
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

        public frmMarcas()
        {
            InitializeComponent();
            this.Text = "Categorias";
            cargar();
        }
        public frmMarcas(Marca marca)
        {
            InitializeComponent();
            this.marca = marca;
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = false;
            cargar();
        }

        private void cargar()
        {
            listaMarcas = negocio.listar();

            try
            {
                if (listaMarcas.Count > 0)
                {
                    dgvListaMarcas.DataSource = listaMarcas;
                    dgvListaMarcas.Refresh();
                }
                else
                {
                    MessageBox.Show("No hay marcas disponibles para mostrar.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Marca> filtroMarca;
            string filtro = txtFiltro.Text;

            if (filtro.Length >= 1)
            {
                filtroMarca = listaMarcas.FindAll(x => x.Descripcion.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                filtroMarca = listaMarcas;
            }

            dgvListaMarcas.DataSource = null;
            dgvListaMarcas.DataSource = filtroMarca;
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

            if (dgvListaMarcas.CurrentRow != null)
            {
                esEdicion = true;
                Marca seleccionado = (Marca)dgvListaMarcas.CurrentRow.DataBoundItem;
                frmMarcas frmEditarMarcas = new frmMarcas(seleccionado);
                txtModificado.Text = seleccionado.Descripcion;
            }
            else
            {
                MessageBox.Show("Seleccione una marca para editar");
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            MarcaNegocio negocio = new MarcaNegocio();

            try
            {
                if (esEdicion && dgvListaMarcas.CurrentRow != null)
                {
                    marca = (Marca)dgvListaMarcas.CurrentRow.DataBoundItem;
                    marca.Descripcion = txtDescripcion.Text;
                    negocio.modificar(marca.Id, marca.Descripcion);
                    MessageBox.Show("Categoría actualizada exitosamente.");
                }
                else
                {
                    Marca nueva = new Marca();
                    nueva.Descripcion = txtDescripcion.Text;
                    negocio.agregar(nueva);
                    MessageBox.Show("Marca agregada exitosamente.");
                }

                cargar();
                txtDescripcion.Text = string.Empty;
                marca = null;

                lblTitulo.Visible = false;
                txtDescripcion.Visible = false;
                btnAplicar.Visible = false;
                btnCancelar.Visible = false;
                esEdicion = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar o modificar la marca: " + ex.Message);
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
            if (dgvListaMarcas.CurrentRow != null)
            {
                Marca seleccionado = (Marca)dgvListaMarcas.CurrentRow.DataBoundItem;
                MarcaNegocio negocio = new MarcaNegocio();
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
