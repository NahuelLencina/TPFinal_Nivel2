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


namespace Presentación
{
    public partial class FrmAltaArticulo : Form
    {

        private Articulo articulo = null;

        public FrmAltaArticulo()
        {
            InitializeComponent();
            Text = "Nuevo Articulo";
        }

        public FrmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Articulo";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
           // Articulo art = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            
            try
            {
                if (articulo == null)
                    articulo = new Articulo ();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = decimal.Parse(txtPrecio.Text);
                articulo.ImagenUrl = txtUrlImagen.Text;
                articulo.Marca = (Marca)cbxMarca.SelectedItem;
                articulo.Categoria = (Categoria)cbxCategoria.SelectedItem;

                if (articulo.Id != 0)
                {
                    negocio.modificar(articulo);
                    MessageBox.Show("Modificado Exitosamente...");
                }
                else
                {
                    negocio.agregar(articulo);
                    MessageBox.Show("Agregado Exitosamente...");
                }

                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio Aux = new MarcaNegocio();
            CategoriaNegocio AuxCat = new CategoriaNegocio();

            try
            {
                cbxMarca.DataSource = Aux.listar();
                cbxMarca.ValueMember = "Id";
                cbxMarca.DisplayMember = "Descripcion";
                cbxCategoria.DataSource = AuxCat.listar();
                cbxCategoria.ValueMember = "Id";
                cbxCategoria.DisplayMember = "Descripcion";

                if (articulo != null)
                {
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    txtPrecio.Text = articulo.Precio.ToString();
                    txtUrlImagen.Text = articulo.ImagenUrl;
                    cbxMarca.SelectedValue = articulo.Marca.Id;
                    cbxCategoria.SelectedValue = articulo.Categoria.Id;
                   
                }
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
        }
    }
}
