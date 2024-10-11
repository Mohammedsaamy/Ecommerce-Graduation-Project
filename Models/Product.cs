namespace Group_4_Intake_44.Models;

[Table("Product")]
public partial class Product
{
    [Key]
    public int ID { get; set; }

    public string Name { get; set; }

    public int? CategoryID { get; set; }

    public int? BrandID { get; set; }

    public string? SpecialTag { get; set; }

    public double? Price { get; set; }

    public string Image { get; set; }

    public string? Description { get; set; }
    public int? Quantity { get; set; }
    public virtual Brand Brand { get; set; }
    public virtual Category Category { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<Cart_Item> Cart_Items { get; set; } = new List<Cart_Item>();
    public virtual ICollection<Store_Product> Store_Products { get; set; }

    //[ForeignKey("Category")]
    //[InverseProperty("Products")]
    //public virtual Category CategoryNavigation { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<Order_Item> Order_Items { get; set; } = new List<Order_Item>();

    //[InverseProperty("Product")]
    //public virtual ICollection<Store_Product> Store_Products { get; set; } = new List<Store_Product>();

}