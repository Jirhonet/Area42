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
        public int? SelectedLocationId { get; set; }

        public void OnGet()
        {
            Load();
        }

        public void OnPost(string name)
        {
            Location location = new Location(0, name);

            _locationService.Add(location);

            Load();
        }

        public void OnPostSelect(int selectedLocationId)
        {
            SelectedLocationId = selectedLocationId;

            Load();
        }

        public void OnPostDelete(int? selectedLocationId)
        {
            if (selectedLocationId.HasValue)
                _locationService.Remove(selectedLocationId.Value);

            Load();
        }

        public void Load()
        {
            Locations = _locationService.Get();
        }
    }
}
