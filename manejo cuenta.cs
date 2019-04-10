using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tiendita
{
    class manejo_cuenta
    {

        public string ingresar_valor(string a, int b, int c, int d)
        {
            return "producto: " + a + " cantidad: " + b + " costo: " + c + "\r\n importe: " + d;
        }

        public double sub_total(int cant, int cost)
        {
            return (cost * cant);
        }

        public double iva(double sub_total)
        {
            return (sub_total + (sub_total * .16));
        }

        public double total(double sub, double iva)
        {
            return sub + iva;
        }

        public string pagar(double total, double pago)
        {
            if (pago < total)
                return "monto insuficiente: ";
            else
                return "cuenta pagada, su cambio es de : $" + (pago - total);
        }

    }
}
