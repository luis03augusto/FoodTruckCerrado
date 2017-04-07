namespace FoodTruckCerrado.Models
{
    public class FotosPrato :Fotos
    {
        public virtual int PratoId { get; set; }

        public virtual Prato Prato { get; set; }
    }
}