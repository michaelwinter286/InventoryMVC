namespace InventoryMVC.Models
{
    public class Livestock
    {
        
        public Guid Id { get; set; }
        public string AnimalTagOrName { get; set; }
        public string Breed { get; set; }
        public string? Notes { get; set; }

    }
}

