namespace Group_4_Intake_44.DTOS.Store
{
    public class CreateStoreDTO
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public double Long { get; set; }

        public double Lat { get; set; }

        public string? MobileNumber { get; set; }

        public string? whatsappNumber { get; set; }

        public string? FacebookLink { get; set; }

        public int CarNumbers { get; set; }
    }
}
