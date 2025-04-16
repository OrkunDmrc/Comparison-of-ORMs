namespace API.Models.CategoyModels
{
    public class GetCategoryModel
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }

        public byte[]? Picture { get; set; }
    }
}
