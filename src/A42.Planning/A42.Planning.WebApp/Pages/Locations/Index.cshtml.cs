using A42.Planning.Data.Abstractions;
using A42.Planning.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A42.Planning.WebApp.Pages.Locations
{
    public class IndexModel : PageModel
    {
        private readonly ILocationService _locationService;

        public IndexModel(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [BindProperty]
        public IEnumerable<Location> Locations { get; private set; } = [];

        [BindProperty]
        public string Name { get; set; } = string.Empty;

        public void OnGet()
        {
            Load();
        }

        public void OnPost()
        {
            Location location = new Location(0, Name);

            _locationService.Add(location);

            ResetForm();
            Load();
        }

        public void Load()
        {
            Locations = _locationService.Get();
        }

        private void ResetForm()
        {
            Name = string.Empty;
        }
    }
}
