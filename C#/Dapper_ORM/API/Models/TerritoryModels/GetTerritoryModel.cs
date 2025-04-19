namespace API.Models.TerritoryModels
{
    public class GetTerritoryModel
    {
        public string TerritoryID { get; set; } = null!;

        public string TerritoryDescription { get; set; } = null!;

        public int RegionID { get; set; }
    }
}
