namespace Group_4_Intake_44.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
    }
}
