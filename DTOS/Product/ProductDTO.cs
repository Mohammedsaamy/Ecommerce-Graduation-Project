namespace Group_4_Intake_44.DTOS.Product
{
    public class ProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? CategoryID { get; set; }
        public int? BrandID { get; set; }
        public string Description { get; set; }
        public string SpecialTag { get; set; }
        public double? Price { get; set; }
        public string? Image { get; set; }
        public int? Quantity { get; set; }   
    }
}
