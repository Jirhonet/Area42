using A42.Planning.Data.Abstractions;
using A42.Planning.Domain;
using Microsoft.AspNetCore.Mvc;

namespace A42.Planning.WebApp.Pages.Locations
{
    public class IndexModel : AreaPageModel
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
            try
            {
                Load();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void OnPost(string name)
        {
            try
            {
                Location location = new Location(0, name);

                _locationService.Add(location);

                Load();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void OnPostSelect(int selectedLocationId)
        {
            try
            {
                SelectedLocationId = selectedLocationId;

                Load();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void OnPostDelete(int? selectedLocationId)
        {
            try
            {
                if (selectedLocationId.HasValue)
                    _locationService.Remove(selectedLocationId.Value);

                Load();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void Load()
        {
            Locations = _locationService.Get();
        }
    }
}
