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

        public bool modificando = false;
        public bool aModificar = false;
        public bool sinModificarImagen = true;

        string rutaImagen = "https://t3.ftcdn.net/jpg/02/48/42/64/240_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg";
        private Articulo articulo = null;
        private List<string> lista = new List<string>();
        private List<string> listaAgregarImagenes = new List<string>();
        private int imagenActual = 0;
        private int imagenModificar = 0;


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
            Text = "Modificar Articulo";
        }

        private void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            CargarImagenDesdeUrl(txtUrlImagen.Text);
        }

        private void CargarImagenDesdeUrl(string url)
        {
            try
            { 
                pbxArticulo.Load(url);  // Cargar la imagen en el PictureBox
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar la imagen: " + ex.Message);
                // Cargar una imagen por defecto si ocurre una excepción
                pbxArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWN8hLKJungcUipWLReON9fse4yZcyB0rzNw&s");
            }
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
                cboCategoria.SelectedIndex = -1;
                pbxArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTWN8hLKJungcUipWLReON9fse4yZcyB0rzNw&s");

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Articulo articulo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            //int idNuevo = 0;
            Imagen img = new Imagen();

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
                

                if (!string.IsNullOrWhiteSpace(txtUrlImagen.Text))
                {
                    img.ImagenUrl =  txtUrlImagen.Text;
                    if (articulo.Imagenes == null)
                    {
                        articulo.Imagenes = new List<Imagen>();
                    }
                }

                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    //articulo.Id = idNuevo;
                    negocio.agregar(articulo);                    
                    MessageBox.Show("Agregado exitosamente");
                }

                img.IdArticulo = articulo.Id;
                imagenNegocio.agregar(img);

                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el artículo: " + ex.Message);
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            string imageUrl = txtUrlImagen.Text.Trim();
            if (!string.IsNullOrEmpty(imageUrl))
            {
                try
                {
                    Imagen img = new Imagen { ImagenUrl = imageUrl };

                    if (articulo.Imagenes == null)
                    {
                        articulo.Imagenes = new List<Imagen>();
                    }

                    articulo.Imagenes.Add(img);

                    // Mostrar la imagen en el PictureBox si se desea visualizar
                    var webClient = new WebClient();
                    var imageStream = webClient.OpenRead(imageUrl);
                    var image = Image.FromStream(imageStream);
                    pbxArticulo.Image = image;

                    // Limpiar el campo de texto después de agregar la imagen
                    txtUrlImagen.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo agregar la imagen desde la URL. Verifica la URL e inténtalo nuevamente.");
                    Console.WriteLine("Error al cargar la imagen desde la URL: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingresa una URL de imagen válida.");
            }
        }


    }
}
