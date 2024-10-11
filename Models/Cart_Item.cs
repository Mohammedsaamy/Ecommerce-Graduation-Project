namespace Group_4_Intake_44.Models;

[Table("Cart Items")]
public partial class Cart_Item
{
    [Key]
    public int ID { get; set; }

    public int Quantity { get; set; }

    public int? ProductID { get; set; }

    public int? ShoppingCartID { get; set; }

    [ForeignKey("ProductID")]
    [InverseProperty("Cart_Items")]
    public virtual Product Product { get; set; }

    [ForeignKey("ShoppingCartID")]
    [InverseProperty("Cart_Items")]
    public virtual Shopping_Cart ShoppingCart { get; set; }
}