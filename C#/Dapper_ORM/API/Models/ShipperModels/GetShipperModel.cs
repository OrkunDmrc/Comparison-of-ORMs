namespace API.Models.ShipperModels
{
    public class GetShipperModel
    {
        public int ShipperID { get; set; }

        public string CompanyName { get; set; } = null!;

        public string? Phone { get; set; }
    }
}
