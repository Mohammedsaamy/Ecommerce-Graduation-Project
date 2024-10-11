namespace Group_4_Intake_44.Models
{
    public class WishlistItems
    {
        [Key] 
        public int ID { get; set; }
        public int WishListID { get; set; }
        public int ProductId { get; set; }
        public DateTime AddedDate { get; set; }
        public Wishlist WishList { get; set; }
        public Product Product { get; set; }
    }
}
