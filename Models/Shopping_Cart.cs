namespace Group_4_Intake_44.Models;

[Table("Shopping Cart")]
public partial class Shopping_Cart
{
    [Key]
    public int ID { get; set; }

    public string? UserID { get; set; }

    [InverseProperty("ShoppingCart")]
    public virtual ICollection<Cart_Item> Cart_Items { get; set; } = new List<Cart_Item>();

    //Not Create Table In Db
    [NotMapped]
    public double CartTotal { get; set; }
    [NotMapped]
    public string StripPaymentIntenId { get; set; }
    [NotMapped]
    public string ClientSecret { get; set; }

}