using dominio;
using negocio;
using System;
using System.Windows.Forms;


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

        private void colorCampo()
        {
            if (txtCodigo.Text == "")
                txtCodigo.BackColor = System.Drawing.Color.Yellow;
            else
                txtCodigo.BackColor = System.Drawing.Color.White;

            if (txtNombre.Text == "")
                txtNombre.BackColor = System.Drawing.Color.Yellow;
            else
                txtNombre.BackColor = System.Drawing.Color.White;

            if (txtDescripcion.Text == "")
                txtDescripcion.BackColor = System.Drawing.Color.Yellow;
            else
                txtDescripcion.BackColor = System.Drawing.Color.White;

            if ((txtPrecio.Text == "") || (!validarSoloNumeros(txtPrecio.Text)))
                txtPrecio.BackColor = System.Drawing.Color.Yellow;
            else
                txtPrecio.BackColor = System.Drawing.Color.White;

        }

        private bool validarCampos()
        {
            if (txtCodigo.Text != "" && txtNombre.Text != "" && txtDescripcion.Text != "" && txtPrecio.Text != "" && validarSoloNumeros(txtPrecio.Text))
            {
                return true;
            }
            else
            {
                if (validarSoloNumeros(txtPrecio.Text))
                {
                    colorCampo();
                    MessageBox.Show("Hay campos sin completar...");
                }
                else
                {
                    MessageBox.Show("El campo precio solo admite números y ","...");
                    txtPrecio.BackColor = System.Drawing.Color.Yellow;
                    colorCampo();
                }
                
                return false;
            }
        }

        private bool validarSoloNumeros(string cadena)
        {
            try
            {
                foreach (char caracter in cadena)
                {
                    if (!char.IsNumber(caracter) && caracter!= ',')
                        return false;

                    if ((caracter == ',') && (txtPrecio.Text.IndexOf(',') == 0))
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (articulo == null)
                    articulo = new Articulo();

                if (validarCampos())
                {
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
