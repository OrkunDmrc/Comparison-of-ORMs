namespace API.Models.CategoyModels
{
    public class UpdateCategoryModel
    {

        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }

        public byte[]? Picture { get; set; }
    }
}
