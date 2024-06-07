using SVC.Models;
using System.Text.Json;

namespace SVC.Services
{
    public class JsonFileVacantPositionService
    {

        public VacantPosition[] VacantPositions { get; set; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "vacantpositions.json");

        public JsonFileVacantPositionService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;

            using var jsonFileReader = File.OpenText(JsonFileName);
            VacantPositions = JsonSerializer.Deserialize<VacantPosition[]>(jsonFileReader.ReadToEnd(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (VacantPositions == null)
            {
                throw new Exception("Unable to get album data!");
            }
        }

        public IWebHostEnvironment WebHostEnvironment { get; }


        public IEnumerable<VacantPosition> GetVacantPositions()
        {
            return VacantPositions;
        }
    }
}