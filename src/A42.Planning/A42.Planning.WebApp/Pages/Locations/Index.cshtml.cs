using A42.Planning.Domain;
using A42.Planning.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A42.Planning.WebApp.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private readonly LocationService _locationService;

        public IndexModel(LocationService locationService)
        {
            _locationService = locationService;
        }

        [BindProperty]
        public IEnumerable<Location> Locations { get; private set; } = [];

        public void OnGet()
        {
            Locations = _locationService.Get();
        }

        public void OnPost()
        {
            //_locationService.AddLocation();
        }
    }
}
