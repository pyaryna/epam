using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace serialization
{
    [Serializable]
    public class Car
    {
        public int CarId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [NonSerialized]
        public decimal total;
        public Car() { }
        public Car(int id, decimal price, int quantity)
        {
            CarId = id;
            Price = price;
            Quantity = quantity;
            total = price * quantity;
        }

        public override string ToString()
        {
            return $"CarId = {CarId}, Price = {Price}, Quantity = {Quantity}, Total = {Price * Quantity}";
        }
    }
}
