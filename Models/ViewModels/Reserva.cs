namespace HermanosK.Models.ViewModels
{
    public class Reserva
    {
        public int Id { get; set; } // Identificador único de la reserva
        public string Nombre { get; set; } // Nombre del lugar o servicio
        public decimal Precio { get; set; } // Precio de la reserva
        public string Categoria { get; set; } // Categoría (Ej: Tour, Hotel, Restaurante)
        public double Calificacion { get; set; } // Calificación promedio (1-5)
        public string Imagen { get; set; } // URL o nombre del archivo de imagen
    }
}