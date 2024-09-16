using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace TPWinForm
{
    public partial class frmArticulos : Form
    {
        private List<Articulo> listaArticulo;
        public frmArticulos()
        {
            InitializeComponent();
        }
        
        private void frmArticulos_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Id");
            cboCampo.Items.Add("Codigo");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Categoria");
        }

        //IMAGENES

        private int indiceImagenActual = 0;

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dataGridView.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.Imagenes[indiceImagenActual].ImagenUrl);
                
            }
        }

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulo = negocio.listar();
                dataGridView.DataSource = listaArticulo;
                cargarImagen(listaArticulo[0].Imagenes[0].ImagenUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                if (Uri.IsWellFormedUriString(imagen, UriKind.Absolute))
                {
                    pictureBox1.Load(imagen);
                }
                else
                {
                    pictureBox1.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWN8hLKJungcUipWLReON9fse4yZcyB0rzNw&s");
                }
            }
            catch (Exception)
            {
                pictureBox1.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWN8hLKJungcUipWLReON9fse4yZcyB0rzNw&s");
            }
        }

        private void btnSiguienteImagen_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dataGridView.CurrentRow.DataBoundItem;
            if (seleccionado != null && seleccionado.Imagenes.Count > 0)
            {
                indiceImagenActual = (indiceImagenActual + 1) % seleccionado.Imagenes.Count; 
                cargarImagen(listaArticulo[0].Imagenes[0].ImagenUrl);
            }
        }

        private void btnImagenAnterior_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dataGridView.CurrentRow.DataBoundItem;
            if (seleccionado != null && seleccionado.Imagenes.Count > 0)
            {
                indiceImagenActual = (indiceImagenActual - 1 + seleccionado.Imagenes.Count) % seleccionado.Imagenes.Count;
                cargarImagen(listaArticulo[0].Imagenes[0].ImagenUrl);
            }
        }

        //FIN IMAGENES



        //FILTRO

        private void ocultarColumnas()
        {
            //dataGridView.Columns["Id"].Visible = false;
        }

        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el campo para filtrar.");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione el criterio para filtrar.");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Id" || cboCampo.SelectedItem.ToString() == "Precio")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("Debes cargar el filtro para numéricos...");
                    return true;
                }
                if (!(soloNumeros(txtFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Solo nros para filtrar por un campo numérico...");
                    return true;
                }

            }

            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (cboCampo.SelectedItem.ToString() != "Marca" && cboCampo.SelectedItem.ToString() != "Categoria" && validarFiltro())
                    return;


                string opcion = cboCampo.SelectedItem.ToString();
                
                string campo = cboCampo.SelectedItem.ToString();
                string criterio;
                string filtro; 
                if (opcion == "Marca")
                {
                    criterio = cboCriterioAvanzado.SelectedItem.ToString();
                    filtro = criterio;
                    dataGridView.DataSource = negocio.filtrar(campo, criterio, filtro);
                }
                else if (opcion == "Categoria")
                {
                    criterio = cmbCriterioCategoria.SelectedItem.ToString();
                    filtro = criterio;
                    dataGridView.DataSource = negocio.filtrar(campo, criterio, filtro);
                }
                
                else
                {
                    criterio = cboCriterio.SelectedItem.ToString();
                    filtro = txtFiltroAvanzado.Text;
                    dataGridView.DataSource = negocio.filtrar(campo, criterio, filtro);
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            string filtro = txtFiltro.Text;

            if (filtro.Length >= 3)
            {
                listaFiltrada = listaArticulo.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaArticulo;
            }

            dataGridView.DataSource = null;
            dataGridView.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCampo != null && cboCampo.SelectedItem != null)
            {
                string opcion = cboCampo.SelectedItem.ToString();



                if (opcion == "Id" || opcion == "Precio")
                {
                    cboCriterio.Visible = true;
                    cboCriterioAvanzado.Visible = false;
                    cmbCriterioCategoria.Visible = false;

                    cboCriterio.Items.Clear();

                    txtFiltroAvanzado.Enabled = true;

                    cboCriterio.Items.Add("Mayor a");
                    cboCriterio.Items.Add("Menor a");
                    cboCriterio.Items.Add("Igual a");
                }
                else if (opcion == "Marca")
                {
                    cboCriterio.Visible = false;
                    cboCriterioAvanzado.Visible = true;
                    cmbCriterioCategoria.Visible = false;

                    MarcaNegocio marcaNegocio = new MarcaNegocio();
                    cboCriterioAvanzado.Items.Clear();
                    cboCriterioAvanzado.DataSource = marcaNegocio.listar();
                    cboCriterioAvanzado.ValueMember = "Id";
                    cboCriterioAvanzado.DisplayMember = "Descripcion";

                    txtFiltroAvanzado.Enabled = false;

                }
                else if (opcion == "Categoria")
                {
                    cboCriterio.Visible = false;
                    cboCriterioAvanzado.Visible = false;
                    cmbCriterioCategoria.Visible = true;

                    CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                    cmbCriterioCategoria.Items.Clear();
                    cmbCriterioCategoria.DataSource = categoriaNegocio.listar();
                    cmbCriterioCategoria.ValueMember = "Id";
                    cmbCriterioCategoria.DisplayMember = "Descripcion";

                    txtFiltroAvanzado.Enabled = false;

                }
                else
                {

                    cboCriterio.Visible = true;
                    cboCriterioAvanzado.Visible = false;
                    cmbCriterioCategoria.Visible = false;

                    cboCriterio.Items.Clear();

                    txtFiltroAvanzado.Enabled = true;
                    cboCriterio.Items.Add("Comienza con");
                    cboCriterio.Items.Add("Termina con");
                    cboCriterio.Items.Add("Contiene");
                }
            }

        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
                
                cboCampo.SelectedIndex = -1;

                
                cboCriterio.DataSource = null;
                cboCriterio.Items.Clear();
                cboCriterio.Visible = true;

                cmbCriterioCategoria.DataSource = null;
                cmbCriterioCategoria.Items.Clear();
                cboCriterioAvanzado.Visible = false;
                
                cmbCriterioCategoria.DataSource = null;
                cmbCriterioCategoria.Items.Clear();
                cmbCriterioCategoria.Visible = false; 

                txtFiltroAvanzado.Text = string.Empty;
                txtFiltroAvanzado.Enabled = false;
            
                cargar();

        }

        //FIN FILTRO
    }

}
