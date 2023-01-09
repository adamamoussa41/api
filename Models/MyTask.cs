namespace Crud_api.Models
{
    public class MyTask
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int totalDuration { get; set; }
        public int? Amount { get; set; }
        public string? UnitOfMeasurement { get; set; }

        public long MaterialId { get; set; }
        public string? Material { get; set; }
        // public Material? Material { get; set; }
    }
}