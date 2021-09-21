using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P55___PIZZERIA
{
    public class PizzaFamiliar : Pizza
    {
        private double precio = 199.00;

        public PizzaFamiliar(string estado, string descripcion = "Pizza Familar") : base(estado, descripcion) { }

        public override double Precio()
        {
            return precio;
        }
    }
}
