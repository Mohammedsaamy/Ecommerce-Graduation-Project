namespace Group_4_Intake_44.Models
{
    public class Brand
    {
        [Key]
        public int Brand_ID { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
