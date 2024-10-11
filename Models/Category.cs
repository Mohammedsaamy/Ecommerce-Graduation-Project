namespace Group_4_Intake_44.Models;

[Table("Category")]
public partial class Category
{
    [Key]
    public int ID { get; set; }

    [StringLength(50)]
    public string Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } 

}