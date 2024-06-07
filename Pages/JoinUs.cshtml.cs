using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SVC.Models;
using SVC.Services;

namespace SVC.Pages
{
    public class JoinUsModel : PageModel
    {
        public JsonFileVacantPositionService positionService;

        public JoinUsModel(JsonFileVacantPositionService service)
        {
            positionService = service;
        }

        public string GetDescription(VacantPosition pos)
        {
            string description = pos.Description;
            description = description.Replace("/n", "<br/>");
            return description;
        }
    }
}
