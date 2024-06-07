using System.Text.Json;

namespace SVC.Models
{
    public class VacantPosition
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ExpectedSalary { get; set; }
        public string Forms { get; set; }
    }
}