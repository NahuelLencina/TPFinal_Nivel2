using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;





namespace negocio
{
    public class ArticuloNegocio
    {
        // ------------ Metodo/funsión  ------------

        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select  A.Codigo, A.Nombre, A.Id, A.Descripcion, C.Descripcion , A.ImagenUrl, M.Descripcion Marca, A.Precio, A.IdMarca, A.IdCategoria From ARTICULOS A, CATEGORIAS C, MARCAS M where C.Id = A.IdCategoria and M.Id = A.IdMarca");
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Articulo auxA = new Articulo();

                    auxA.Codigo = datos.Lector.GetString(0);
                    auxA.Nombre = (string)datos.Lector["Nombre"];
                    auxA.Id = (int)datos.Lector["Id"];
                    auxA.Descripcion = (string)datos.Lector["Descripcion"];
                    auxA.Precio = (decimal)datos.Lector["Precio"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        auxA.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    auxA.Marca = new Marca();
                    auxA.Marca.Id = (int)datos.Lector["IdMarca"];
                    auxA.Marca.Descripcion = (string)datos.Lector["Marca"];
                    auxA.Categoria = new Categoria();
                    auxA.Categoria.Id = (int)datos.Lector["IdCategoria"];            

                    lista.Add(auxA);
                }

                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS(Codigo, Nombre, Descripcion, Precio, ImagenUrl, IdMarca, IdCategoria) values ('" + nuevo.Codigo + "', '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', '"+nuevo.Precio + "', '" + nuevo.ImagenUrl + "', @idMarca, @idCategoria)");
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);             
                datos.ejecutarAccion();               
            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idcategoria, ImagenUrl = @img, Precio = @precio where Id = @id");
                datos.setearParametro("@codigo", modificar.Codigo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@descripcion", modificar.Descripcion);
                datos.setearParametro("@idMarca", modificar.Marca.Id);
                datos.setearParametro("@idCategoria", modificar.Categoria.Id);
                datos.setearParametro("@img", modificar.ImagenUrl);
                datos.setearParametro("@precio", modificar.Precio);
                datos.setearParametro("@id",modificar.Id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Articulo> filtrar(string campo, string criterio)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
           

            try
            {
                string consulta = "select  A.Codigo, A.Nombre, A.Id, A.Descripcion, C.Descripcion , A.ImagenUrl, M.Descripcion Marca, A.Precio, A.IdMarca, A.IdCategoria From ARTICULOS A, CATEGORIAS C, MARCAS M where C.Id = A.IdCategoria and M.Id = A.IdMarca And ";

                if (campo == "Marca")
                {
                    switch(criterio)
                    {
                        case "Apple":

                            consulta += "M.Descripcion like'" + criterio + "%' ";
                            break;
                        
                        case "Samsung":

                            consulta += "M.Descripcion like'" + criterio + "%' ";
                            break;

                        case "Motorola":

                            consulta += "M.Descripcion like'" + criterio + "%' ";
                            break;

                        case "Sony":

                            consulta += "M.Descripcion like'" + criterio + "%' ";
                            break;

                        case "Huawei":

                            consulta += "M.Descripcion like'" + criterio + "%' ";
                            break;

                        //default:
                            
                        //    break;

                    }
                    
                }
                
                else if (campo == "Categoria")
                {
                    switch (criterio)
                    {
                        case "Audio":

                            consulta += "C.Descripcion like'" + criterio + "%' ";
                            break;

                        case "Televisores":

                            consulta += "C.Descripcion like'" + criterio + "%' ";
                            break;

                        case "Media":

                            consulta += "C.Descripcion like'" + criterio + "%' ";
                            break;

                        case "Celulares":

                            consulta += "C.Descripcion like'" + criterio + "%' ";
                            break;

                        
                           //default:

                            //    break;

                    }
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo auxA = new Articulo();

                    auxA.Codigo = datos.Lector.GetString(0);
                    auxA.Nombre = (string)datos.Lector["Nombre"];
                    auxA.Id = (int)datos.Lector["Id"];
                    auxA.Descripcion = (string)datos.Lector["Descripcion"];
                    auxA.Precio = (decimal)datos.Lector["Precio"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        auxA.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    auxA.Marca = new Marca();
                    auxA.Marca.Id = (int)datos.Lector["IdMarca"];
                    auxA.Marca.Descripcion = (string)datos.Lector["Marca"];
                    auxA.Categoria = new Categoria();
                    auxA.Categoria.Id = (int)datos.Lector["IdCategoria"];

                    lista.Add(auxA);
                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
 }