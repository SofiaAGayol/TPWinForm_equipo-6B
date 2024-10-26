using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using System.Configuration;
using System.Xml.Linq;
using System.Collections;
using System.Net;

namespace TPWinForm
{
    public partial class frmAgregarArticulo : Form
    {
        private Articulo articulo = null;
        private List<Imagen> imagenesTemporales = new List<Imagen>();
        private int indiceImagenActual = 0;

        public frmAgregarArticulo()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public frmAgregarArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void frmAgregarArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

            try
            {
                cboMarca.DataSource = marcaNegocio.listar();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";

                cboCategoria.DataSource = categoriaNegocio.listar();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();

                    if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
                    {
                        txtUrlImagen.Text = articulo.Imagenes[0].ImagenUrl;
                        CargarImagenDesdeUrl(txtUrlImagen.Text);
                    }

                    if (articulo.Marca != null)
                    {
                        cboMarca.SelectedValue = articulo.Marca.Id;
                    }

                    if (articulo.Categoria != null)
                    {
                        cboCategoria.SelectedValue = articulo.Categoria.Id;
                    }
                }
                else
                {
                    this.Text = "+";
                    articulo = new Articulo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //AGREGAR IMAGENES
        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            string imageUrl = txtUrlImagen.Text.Trim();

            if (!string.IsNullOrEmpty(imageUrl))
            {
                try
                {
                    Imagen img = new Imagen { ImagenUrl = imageUrl, IdArticulo = 0 };
                    imagenesTemporales.Add(img);

                    // Mostrar la imagen en el PictureBox
                    CargarImagenDesdeUrl(imageUrl);
                    txtUrlImagen.Clear();

                    // Limpiar el campo de texto después de agregar la imagen
                    txtUrlImagen.Text = "";
                    MessageBox.Show("Imagen agregada con exito");
                    CargarImagenDesdeUrl(imageUrl);

                }
                catch (Exception ex)
                {
                    txtUrlImagen.Text = "";
                    MessageBox.Show("No se pudo agregar la imagen desde la URL. Verifica la URL e inténtalo nuevamente.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa una URL de imagen válida.");
            }
        }

        //AGREGAR ARTICULO
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ImagenNegocio imagenNegocio = new ImagenNegocio();

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show("Por favor, ingrese un precio válido.");
                    return;
                }

                articulo.Precio = precio;
                articulo.Marca = (Marca)cboMarca.SelectedItem;
                articulo.Categoria = (Categoria)cboCategoria.SelectedItem;

                if (articulo.Id == 0)
                {
                    negocio.agregar(articulo);
                    int nuevoId = articulo.Id;
                    MessageBox.Show("Agregado exitosamente");
                }

                foreach (var img in imagenesTemporales)
                {
                    img.IdArticulo = articulo.Id;
                    if (img.IdArticulo != 0)
                    {
                        imagenNegocio.agregar(img);
                    }
                    
                }

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el artículo: " + ex.Message);
            }
        }


        //MOSTRAR IMAGENES
        private void CargarImagenDesdeUrl(string url)
        {
            try
            {
                if (url == null && imagenesTemporales.Count > 0)
                {
                    url = imagenesTemporales[imagenesTemporales.Count - 1].ImagenUrl;
                    lblImagen.Text = "Imagen " + (imagenesTemporales.Count - 1) + " de " + imagenesTemporales.Count;
                }

                if (!string.IsNullOrEmpty(url))
                {
                    var webClient = new WebClient();
                    var imageStream = webClient.OpenRead(url);
                    var image = Image.FromStream(imageStream);
                    pbxArticulo.Image = image;
                }
                else
                {
                    pbxArticulo.Image = null;
                }
            }
            catch (Exception ex)
            {
                pbxArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSk8RLjeIEybu1xwZigumVersvGJXzhmG8-0Q&s");
            }
        }

        private void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            CargarImagenDesdeUrl(txtUrlImagen.Text);
        }

        private void btnSiguienteImagen_Click(object sender, EventArgs e)
        {
            if (imagenesTemporales.Count > 0)
            {
                indiceImagenActual = (indiceImagenActual + 1) % imagenesTemporales.Count;
                CargarImagenDesdeUrl(imagenesTemporales[indiceImagenActual].ImagenUrl);
                lblImagen.Text = "Imagen " + (indiceImagenActual + 1) + " de " + imagenesTemporales.Count;
            }
            else
            {
                MessageBox.Show("No hay imágenes para mostrar.");
            }
        }

        private void btnImagenAnterior_Click(object sender, EventArgs e)
        {
            if (imagenesTemporales.Count > 0)
            {
                indiceImagenActual = (indiceImagenActual - 1) % imagenesTemporales.Count;
                CargarImagenDesdeUrl(imagenesTemporales[indiceImagenActual].ImagenUrl);
                lblImagen.Text = "Imagen " + (indiceImagenActual + 1) + " de " + imagenesTemporales.Count;
            }
            else
            {
                MessageBox.Show("No hay imágenes para mostrar.");
            }
        }
        


    }



}
