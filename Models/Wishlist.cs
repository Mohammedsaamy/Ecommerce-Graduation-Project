namespace Group_4_Intake_44.Models
{
    public class Wishlist
    {
        [Key]
        public int WishListID { get; set; }
        public string? UserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<WishlistItems> WishListItems { get; set; }

    }
}
