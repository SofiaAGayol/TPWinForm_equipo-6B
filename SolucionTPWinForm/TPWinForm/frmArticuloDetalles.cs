using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm
{
    public partial class frmArticuloDetalles : Form
    {

        public Articulo articulo = new Articulo();

        public frmArticuloDetalles()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            ArticuloNegocio articulosDB = new ArticuloNegocio();

            articulo = articulosDB.buscarArticulo(int.Parse(txtID.Text));

            if (articulo.Id == int.Parse(txtID.Text))
            {
                txtID.Text = articulo.Id.ToString();
                txtCodigo.Text = articulo.Codigo.ToString();
                txtNombre.Text = articulo.Nombre.ToString();
                txtDescripcion.Text = articulo.Descripcion.ToString();
                txtMarca.Text = articulo.Marca.ToString();
                txtCategoria.Text = articulo.Categoria.ToString();
                txtPrecio.Text = articulo.Precio.ToString();
                pictureBox.Visible = true;
                try
                {
                    pictureBox.Load(articulo.Imagenes[0].ImagenUrl);
                }
                catch (Exception)
                {

                    pictureBox.Load("https://salonlfc.com/wp-content/uploads/2018/01/image-not-found-1-scaled-1150x647.png");
                }

            }
            else
            {
                MessageBox.Show("No existe el artículo con el ID: #" + txtID.Text);
                txtID.Text = "";
                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                txtMarca.Text = "";
                txtCategoria.Text = "";
                txtPrecio.Text = "";
                pictureBox.Visible = false;
            }
        }

        private void frmArticuloDetalles_Load(object sender, EventArgs e)
        {
            {
                txtID.Text = articulo.Id.ToString();
                txtCodigo.Text = articulo.Codigo.ToString();
                txtNombre.Text = articulo.Nombre.ToString();
                txtDescripcion.Text = articulo.Descripcion.ToString();
                txtMarca.Text = articulo.Marca.ToString();
                txtCategoria.Text = articulo.Categoria.ToString();
                txtPrecio.Text = articulo.Precio.ToString();


                try
                {
                    pictureBox.Load(articulo.Imagenes[0].ImagenUrl);
                }
                catch (Exception)
                {

                    pictureBox.Load("https://salonlfc.com/wp-content/uploads/2018/01/image-not-found-1-scaled-1150x647.png");
                }


            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
