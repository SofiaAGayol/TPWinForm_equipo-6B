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
        }

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
                pictureBox1.Load(imagen);
            }
            catch (Exception ex)
            {
                pictureBox1.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");
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
    }

}
