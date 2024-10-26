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
using System.Security.Policy;
using System.Reflection;

namespace TPWinForm
{
    public partial class frmAgregarArticulo : Form
    {
        private Articulo articulo = null;
        private List<Imagen> imagenesTemporales = new List<Imagen>();
        private int indiceImagenActual = 0;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public frmAgregarArticulo()
        {
            InitializeComponent();
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
                    this.Text = "Modificar";
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();

                    if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
                    {
                        indiceImagenActual = 0;
                        CargarImagenDesdeUrl(articulo.Imagenes[indiceImagenActual].ImagenUrl);
                        lblImagen.Text = "Imagen " + (indiceImagenActual + 1) + " de " + articulo.Imagenes.Count;
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
                    this.Text = "Agregar";
                    articulo = new Articulo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            string imageUrl = txtUrlImagen.Text.Trim();

            if (!string.IsNullOrEmpty(imageUrl))
            {
                try
                {
                    Imagen img = new Imagen { ImagenUrl = imageUrl, IdArticulo = 0 };
                    imagenesTemporales.Add(img);

                    CargarImagenDesdeUrl(imageUrl);
                    txtUrlImagen.Clear();

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

                articulo.Imagenes.AddRange(imagenesTemporales);

                if (articulo.Id == 0)
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado exitosamente");
                }
                else
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Artículo actualizado exitosamente.");
                }

                //foreach (var img in imagenesTemporales)
                //{
                //    img.IdArticulo = articulo.Id;
                //    if (img.IdArticulo != 0)
                //    {
                //        imagenNegocio.agregar(img);
                //    }

                //}

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
                if (string.IsNullOrEmpty(url) && imagenesTemporales.Count > 0)
                {
                    url = imagenesTemporales[imagenesTemporales.Count - 1].ImagenUrl;
                    lblImagen.Text = "Imagen " + imagenesTemporales.Count + " de " + imagenesTemporales.Count;
                }
                else if (string.IsNullOrEmpty(url) && articulo.Imagenes.Count > 0)
                {
                    url = articulo.Imagenes[articulo.Imagenes.Count - 1].ImagenUrl;
                    lblImagen.Text = "Imagen " + articulo.Imagenes.Count + " de " + articulo.Imagenes.Count;
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
            else if (articulo.Imagenes.Count > 0)
            {
                indiceImagenActual = (indiceImagenActual + 1) % articulo.Imagenes.Count;
                CargarImagenDesdeUrl(articulo.Imagenes[indiceImagenActual].ImagenUrl);
                lblImagen.Text = "Imagen " + (indiceImagenActual + 1) + " de " + articulo.Imagenes.Count;
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
            else if (articulo.Imagenes.Count > 0)
            {
                indiceImagenActual = (indiceImagenActual - 1) % articulo.Imagenes.Count;
                CargarImagenDesdeUrl(articulo.Imagenes[indiceImagenActual].ImagenUrl);
                lblImagen.Text = "Imagen " + (indiceImagenActual + 1) + " de " + articulo.Imagenes.Count;
            }
            else
            {
                MessageBox.Show("No hay imágenes para mostrar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (articulo != null)
            {
                if (articulo.Imagenes.Count > 1)
                {
                    var resultado = MessageBox.Show("¿Está seguro de que desea eliminar esta imagen?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (resultado == DialogResult.Yes)
                    {

                        articulo.Imagenes.RemoveAt(indiceImagenActual);
                        if (articulo.Imagenes.Count > 0)
                        {
                            indiceImagenActual = Math.Min(indiceImagenActual, articulo.Imagenes.Count - 1);
                            CargarImagenDesdeUrl(articulo.Imagenes[0].ImagenUrl);
                        }
                        else
                        {
                            pbxArticulo.Image = null;
                            MessageBox.Show("No quedan imágenes. Agregue al menos una imagen antes de guardar.");
                        }

                        MessageBox.Show("Imagen eliminada. Recuerde guardar el artículo completo para guardar los cambios en las imágenes.");

                    }
                }
                else
                {
                    MessageBox.Show("El artículo debe tener por lo menos una imagen.");
                }
            }
        }
    }



}
