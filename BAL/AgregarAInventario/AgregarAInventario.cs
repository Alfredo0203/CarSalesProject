using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.AgregarAInventario
{
   public class AgregarAInventario
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double PrecioCompra { get; set; }
        public int Cantidad { get; set; }
        public double SubTotal { get; set; }
        public static double TotalAPagar { get; set; }
        public static List<AgregarAInventario> listaAutosAVender = new List<AgregarAInventario>();

        public List<AgregarAInventario> AgregarParaVender(int id, string marca, string modelo, int cantidad, double precio, double total)
        {
            AgregarAInventario auto = new AgregarAInventario();
            auto.Id = id;
            auto.Cantidad = cantidad;
            auto.Marca = marca;
            auto.Modelo = modelo;
            auto.PrecioCompra = precio;
            auto.SubTotal = total;

            listaAutosAVender.Add(auto);

            return listaAutosAVender;
        }
    }
}
