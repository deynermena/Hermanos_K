using System;
using System.Collections.Generic;

namespace HermanosK.Models
{
    public class Receipt
    {
        public int ID { get; set; }
        public int FirstName { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentarios { get; set; }
       

        public virtual User User { get; set; }
    }
}