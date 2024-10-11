namespace Group_4_Intake_44.DTOS.Product
{
    public class CreateProductDTO
    {
        [Required]
        public string Name { get; set; }
        public int? CategoryID { get; set; }
        public int? BrandID { get; set; }
        public string Description { get; set; }
        public string SpecialTag { get; set; }

        [Range(1, int.MaxValue)]
        public double? Price { get; set; }
        public string? Image { get; set; }
        public int Quantity { get; set; }
    }
}
