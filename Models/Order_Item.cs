namespace Group_4_Intake_44.Models;

[Table("Order Items")]
public partial class Order_Item
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    public string ProductName { get; set; }

    public double? Price { get; set; }

    public int? Quantity { get; set; }

    public int? ProductID { get; set; }

    public int? OrederHearderID { get; set; }

    [ForeignKey("OrederHearderID")]
    [InverseProperty("Order_Items")]
    public virtual OrderHeader OrederHearder { get; set; }

    [ForeignKey("ProductID")]
    [InverseProperty("Order_Items")]
    public virtual Product Product { get; set; }
}