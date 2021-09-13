using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ProductoParaVender
{
   public class AutosAVender
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public double SubTotal { get; set; }
        public static double TotalAPagar { get; set; }
        public static List<AutosAVender> listaAutosAVender = new List<AutosAVender>();

        public List<AutosAVender> AgregarParaVender(int id, string marca, string modelo, int cantidad, double precio, double total)
        {
            AutosAVender auto = new AutosAVender();
            auto.Id = id;
            auto.Cantidad = cantidad;
            auto.Marca= marca;
            auto.Modelo = modelo;
            auto.Precio = precio;
            auto.SubTotal = total;

            listaAutosAVender.Add(auto);

            return listaAutosAVender;
        }

    }
}
