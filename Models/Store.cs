namespace Group_4_Intake_44.Models;

public partial class Store
{
    [Key]
    public int ID { get; set; }
    [StringLength(150)]
    public string Name { get; set; }

    [StringLength(500)]
    public string Address { get; set; }

    public double? Long { get; set; }

    public double? Lat { get; set; }

    public string? MobileNumber { get; set; }

    public string? whatsappNumber { get; set; }
    public string? FacebookLink { get; set; }

    public int? CarNumbers { get; set; }
    public virtual ICollection<Store_Product> Store_Products { get; set; }



    //[InverseProperty("Store")]
    //public virtual ICollection<Store_Product> Store_Products { get; set; } = new List<Store_Product>();

}