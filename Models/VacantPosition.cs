using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Text.Json;

namespace SVC.Models
{
    public class VacantPosition
    {
        public string Title { get; set; }
        public string Deadline {  get; set; }
        public IEnumerable<string> Education { get; set; }
        public string Shift { get; set; }
        public IEnumerable<string> Experience { get; set; }
        public IEnumerable<string> Skills { get; set; }
        public IEnumerable<string> Responsibilites { get; set; }
        public string Description { get; set; }
        public string Forms { get; set; }
    }
}