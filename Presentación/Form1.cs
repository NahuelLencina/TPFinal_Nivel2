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
using System.Net;





namespace Presentación
{
    public partial class FrmArticulos : Form
    {
        private List<Articulo> listaArticulo;
        public FrmArticulos()
        {
            InitializeComponent();

        }

        private void FrmArticulos_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulo = negocio.listar();
                dgvArticulos.DataSource = listaArticulo;
                dgvArticulos.Columns["ImagenUrl"].Visible = false;
                pboxAticulos.Load(listaArticulo[0].ImagenUrl);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
//---------------- Metodo privado encargado de cambiar la imagen que muestra
//---------------- al hacer click en otro articulo.
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.ImagenUrl);         
        }

//--------------- Metodo privado que carga la imagen ---------------------------------
//--------------- si la URL esta rota carga una imagen por defecto -------------------   
        private void cargarImagen(string imagen)
        {
            try
            {
                pboxAticulos.Load(imagen);
            }
            catch (Exception ex)
            {
                pboxAticulos.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzSc0E_-ezcw1juku7x_q9rIVtGDEFGDsZnA&usqp=CAU");
            }
        }

    }
}
