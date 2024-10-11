namespace Group_4_Intake_44.Models;

[Table("OrderHeader")]
public partial class OrderHeader
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    public string PickupName { get; set; }
    public string? PickupPhone { get; set; }
    public string PickupEmail { get; set; }

    [StringLength(50)]
    public string Adderss { get; set; }
    public int? UserID { get; set; }

    public string ApplicationUserId { get; set; }
    [ForeignKey("ApplicationUserId")]
    public ApplicationUser User { get; set; }
    public double OrderTotal { get; set; }

    public DateTime? OrderDate { get; set; }
    [StringLength(50)]
    public string Status { get; set; }
    public int? TotalItems { get; set; }
    public string? StripePaymentIntelID { get; set; }

    public int StoreID { get; set; }


    [InverseProperty("OrederHearder")]
    public virtual ICollection<Order_Item> Order_Items { get; set; } = new List<Order_Item>();
}