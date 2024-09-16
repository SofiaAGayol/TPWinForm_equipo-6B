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
            cboCampo.Items.Add("Número");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");
        }

        //IMAGENES

        private int indiceImagenActual = 0;

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                Articulo seleccionado = (Articulo)dataGridView.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.Imagenes[0].ImagenUrl);
                
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
                pictureBox1.Load(imagen);
            }
            catch (Exception)
            {
                pictureBox1.Load("https://salonlfc.com/wp-content/uploads/2018/01/image-not-found-1-scaled-1150x647.png");
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
            if (cboCampo.SelectedItem.ToString() == "Número")
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
                if (validarFiltro())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dataGridView.DataSource = negocio.filtrar(campo, criterio, filtro);

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
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Número")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }

        }

        //Vista detallada + buscar
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dataGridView.CurrentRow.DataBoundItem;

            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmArticuloDetalles))
                    return;
            }

            frmArticuloDetalles Ventana = new frmArticuloDetalles() { articulo = seleccionado };
            Ventana.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmAgregarArticulo))
                    return;
            }

            frmAgregarArticulo Ventana = new frmAgregarArticulo();
            Ventana.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dataGridView.CurrentRow.DataBoundItem;

            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmModificarArticulo))
                    return;
            }

            frmModificarArticulo Ventana = new frmModificarArticulo() { articulo = seleccionado };
            Ventana.Show();
        }

        //FIN FILTRO
    }

}
