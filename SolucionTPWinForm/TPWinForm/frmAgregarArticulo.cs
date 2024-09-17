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

namespace TPWinForm
{
    public partial class frmAgregarArticulo : Form
    {
       
        private Articulo articulo = null;
        private OpenFileDialog archivo = null;

        public frmAgregarArticulo()
        {
            InitializeComponent();
        }
        public frmAgregarArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                if (articulo == null)
                {
                    articulo = new Articulo();
                    //articulo.Id = int.Parse(txtCodigo.Text);
                    articulo.Codigo = txtCodigo.Text;
                    articulo.Nombre = txtNombre.Text;
                    articulo.Descripcion = txtDescripcion.Text;
                    articulo.Precio = decimal.Parse(txtPrecio.Text);
                    articulo.Marca = (Marca)cboMarca.SelectedItem;
                    articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                    //setear imagen

                    if (articulo.Id != 0)
                    {
                        //negocio.modificar(articulo);
                        MessageBox.Show("Modificado exitosamente");
                    }
                    else
                    {
                        //negocio.agregar(articulo);
                        MessageBox.Show("Agregado exitosamente");
                    }

                    //Guardo imagen si la levantó localmente:
                    //if (archivo != null && !(txtUrlImagen.Text.ToUpper().Contains("HTTP")))
                    // File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);

                    Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        
        }

    }
}
