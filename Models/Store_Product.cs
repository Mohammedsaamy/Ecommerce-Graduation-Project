namespace Group_4_Intake_44.Models;

[Table("Store Product")]
public partial class Store_Product
{
    [Key]
    public int ID { get; set; }

    public int? StoreID { get; set; }
    public virtual Store Store { get; set; } = null!;

    public int? ProductID { get; set; }
    public virtual Product Product { get; set; } = null!;

    public int? Quantity { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<Store> Stores { get; set; }

    //[ForeignKey("ProductID")]
    //[InverseProperty("Store_Products")]

    //[ForeignKey("StoreID")]
    //[InverseProperty("Store_Products")]

}