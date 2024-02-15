using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace dominio
{
    public class Articulo
    {
        //--------- Propiedades ---------------

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string ImagenUrl { get; set; }
        public String Descripcion { get; set; }
        public decimal Precio { get; set; }

        public Marca Marca { get; set; }   
        public Categoria Categoria { get; set; }

    }
}