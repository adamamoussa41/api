namespace Crud_api.Models
{
    public class Material
    {
        public long Id { get; set; }
        // public long TaskId { get; set; }
        public string? PartNumber { get; set; }
        public int ManufacturerCode { get; set; }
        public int Price { get; set; }
        public string? unitOfIssue { get; set; }

        // public List<MyTask>? MyTasks { get; set; }
        
    }
}