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

            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                cargar();
                
                cbxCampo.Items.Add("Marca");
                cbxCampo.Items.Add("Categoria");
                cbxCampo.Items.Add("Todos");

            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                
            }
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.ImagenUrl);
        }

        private void cargar()
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
               
                listaArticulo = negocio.listar();
                dgvArticulos.DataSource = listaArticulo;
                ocultarColumnas();
                pboxArticulos.Load(listaArticulo[0].ImagenUrl);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString()); 
            }
        
        
        }
  
        private void cargarImagen(string imagen)
        {
            try
            {
                pboxArticulos.Load(imagen);
            }
            catch (Exception ex)
            {
                pboxArticulos.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzSc0E_-ezcw1juku7x_q9rIVtGDEFGDsZnA&usqp=CAU");
            }
        }
   
        private void ocultarColumnas()
        {
            dgvArticulos.Columns["Codigo"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
            dgvArticulos.Columns["precio"].Visible = false;
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["Categoria"].Visible = false;
        }

        private void btnVerArticulo_Click(object sender, EventArgs e)
        {
            ////////////////////////////////////////////////////////////////////

            ///// Hacer validacion no olvidarseeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee
                try
                {
                    if (dgvArticulos.CurrentRow.DataBoundItem!= null)
                    { 
                        Articulo seleccionado;
                        seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                        FormDescripcion artDescricion = new FormDescripcion(seleccionado);
                        artDescricion.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    ///////////////////////////////////////////////////////////
                    MessageBox.Show(ex.ToString());

                }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            FrmAltaArticulo modificar = new FrmAltaArticulo(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaArticulo alta = new FrmAltaArticulo();
            alta.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo seleccionado;

            try
            {
                DialogResult repuesta  = MessageBox.Show("¿Vas a eliminar este articulo?","Eliminando",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (repuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.Id);
                    cargar();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        private void cbxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            MarcaNegocio Aux = new MarcaNegocio();
            CategoriaNegocio AuxCat = new CategoriaNegocio();

            string opcion = cbxCampo.SelectedItem.ToString();
            try
            {
                if (opcion == "Marca")
                {
                    cbxCriterio.DataSource = Aux.listar();
                    cbxCriterio.ValueMember = "Id";
                    cbxCriterio.DisplayMember = "Descripcion";
                }
                else if (opcion == "Categoria")
                {
                    cbxCriterio.DataSource = AuxCat.listar();
                    cbxCriterio.ValueMember = "Id";
                    cbxCriterio.DisplayMember = "Descripcion";
                }
                else if (opcion == "Todos")
                {
                    cbxCriterio.DataSource = null;
                    cbxCriterio.Items.Clear();                  
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
    
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                if (cbxCampo.SelectedItem.ToString()== "Todos")
                {
                    dgvArticulos.DataSource = negocio.listar();
                }
                else
                {
                    string campo = cbxCampo.SelectedItem.ToString();
                    string criterio = cbxCriterio.SelectedItem.ToString();
                    dgvArticulos.DataSource = negocio.filtrar(campo, criterio);
              
                }
         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ToString());
            }
        }

    }


}

