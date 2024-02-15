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
using dominio;


namespace Presentación
{
    public partial class FormDescripcion : Form
    {

        private Articulo articulo = null;
     
        public FormDescripcion()
        {
            InitializeComponent();
        }

        public FormDescripcion(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }


        public void FormDescripcion_Load(object sender, EventArgs e)
        {
           

            try
            {
                ltbDescripcion.Text = "Codigo Art: "+ articulo.Codigo + "\r" + "NOMBRE DEL ARTICULO: " + articulo.Nombre + "\r" + "Marca: " + articulo.Marca + "\r"+ "DESCRIPCCION: " + articulo.Descripcion +  "\r\r"   +  "PRECIO: " + articulo.Precio;
                pboxArticulo.Load(articulo.ImagenUrl);
            }

            catch (Exception ex)
            {
                pboxArticulo.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzSc0E_-ezcw1juku7x_q9rIVtGDEFGDsZnA&usqp=CAU");

            }
        }

    }
}
