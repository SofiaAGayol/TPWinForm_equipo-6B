using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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

        private void cargar()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulo = negocio.listar();
                dataGridView.DataSource = listaArticulo;
                //dataGridView.Columns["imagenes"].Visible = false;
                dataGridView.Columns["Id"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
            
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dataGridView.CurrentRow.DataBoundItem;
            try
            {
                imgArticulo.Load(seleccionado.Imagenes[0].ImgURL);
            }
            catch (Exception)
            {

                imgArticulo.Load("https://salonlfc.com/wp-content/uploads/2018/01/image-not-found-1-scaled-1150x647.png");
            }
        }

        private void agregarArtículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach( var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmAgregarArt))
                    return;
            }

            frmAgregarArt Ventana = new frmAgregarArt();
            Ventana.Show();
            
        }

        private void verArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmBuscarArt))
                    return;
            }

            frmBuscarArt Ventana = new frmBuscarArt();
            Ventana.Show();
        }

        private void eliminarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmEliminar))
                    return;
            }

            frmEliminar Ventana = new frmEliminar();
            Ventana.Show();
        }

        private void modificarArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
         
            foreach (var item in Application.OpenForms)
            {
                if (item.GetType() == typeof(frmModificar))
                    return;
            }

            frmModificar Ventana = new frmModificar();
            Ventana.Show();
        
        }
    }
}
