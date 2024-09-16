using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;

namespace TPWinForm
{
    public partial class frmBuscarArt : Form
    {

        public Articulo articulo { get; set; }


        public frmBuscarArt()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBuscarArt_Load(object sender, EventArgs e)
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
                pictureBox.Load(articulo.Imagenes[0].ImgURL);
            }
            catch (Exception)
            {

                pictureBox.Load("https://salonlfc.com/wp-content/uploads/2018/01/image-not-found-1-scaled-1150x647.png");
            }


        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            ArticulosDB articulosDB = new ArticulosDB();

            articulo = articulosDB.buscarArticulo( int.Parse(txtID.Text) );

            if (articulo.Id == int.Parse(txtID.Text) ) 
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
                    pictureBox.Load(articulo.Imagenes[0].ImgURL);
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

        private void txtPrecio_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
