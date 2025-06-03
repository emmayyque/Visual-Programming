namespace InventoryManagementSystem.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? Description { get; set; }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
    }
}
