namespace Group_4_Intake_44.DTOS.Order
{
    public class OrderDetailsCreateDTO
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public required string ProductName { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
