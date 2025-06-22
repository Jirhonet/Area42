using A42.Planning.Data.Abstractions;
using A42.Planning.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace A42.Planning.WebApp.Pages
{
    public class IndexModel : AreaPageModel
    {
        private readonly ITeamService _teamService;
        private readonly ILocationService _locationService;
        private readonly IPlanningService _planningService;

        public IndexModel(ITeamService teamService, ILocationService locationService, IPlanningService planningService)
        {
            _teamService = teamService;
            _locationService = locationService;
            _planningService = planningService;
        }

        [BindProperty(SupportsGet = true)]
        public DateTime SelectedDate { get; set; } = DateTime.Today;

        [BindProperty(SupportsGet = true)]
        public int? SelectedTeamId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedLocationId { get; set; }

        [BindProperty]
        public int? SelectedPlanningItemId { get; set; }

        public Domain.Planning Planning { get; set; }
        public SelectList Teams { get; set; }
        public SelectList Locations { get; set; }

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

        public void OnPost(string title, DateTime start, DateTime end)
        {
            try
            {
                if (!SelectedTeamId.HasValue || !SelectedLocationId.HasValue)
                    return;

                Location location = _locationService.GetById(SelectedLocationId.Value);

                PlanningItem planningItem = new PlanningItem(
                    id: 0,
                    title: title,
                    location: location,
                    start: TimeOnly.FromDateTime(start),
                    end: TimeOnly.FromDateTime(end)
                );

                Team team = _teamService.GetById(SelectedTeamId.Value);
                Domain.Planning planning = _planningService.Get(DateOnly.FromDateTime(SelectedDate), team);

                _planningService.Add(planning, planningItem);

                Load();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void OnPostSelect(int selectedPlanningItemId, int? selectedTeamId, DateTime selectedDate)
        {
            try
            {
                SelectedPlanningItemId = selectedPlanningItemId;
                SelectedTeamId = selectedTeamId;
                SelectedDate = selectedDate;

                Load();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void OnPostDelete(int? selectedPlanningItemId)
        {
            try
            {
                if (!SelectedTeamId.HasValue)
                    return;

                if (selectedPlanningItemId.HasValue)
                {
                    Team team = _teamService.GetById(SelectedTeamId.Value);
                    Domain.Planning planning = _planningService.Get(DateOnly.FromDateTime(SelectedDate), team);

                    PlanningItem planningItem = planning.Items.First(pi => pi.Id == selectedPlanningItemId.Value);

                    _planningService.Remove(planningItem);
                }

                Load();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void Load()
        {
            IEnumerable<Team> teams = _teamService.Get();
            Teams = new SelectList(teams, nameof(Team.Id), nameof(Team.Name), SelectedTeamId);

            IEnumerable<Location> locations = _locationService.Get();
            Locations = new SelectList(locations, nameof(Location.Id), nameof(Location.Name), SelectedLocationId);

            if (SelectedTeamId.HasValue)
            {
                Team? team = teams.FirstOrDefault(t => t.Id == SelectedTeamId.Value);
                if (team != null)
                {
                    Planning = _planningService.Get(DateOnly.FromDateTime(SelectedDate), team);
                }
            }
        }

        public override void ShowError(Exception ex)
        {
            base.ShowError(ex);

            IEnumerable<Team> teams = _teamService.Get();
            Teams = new SelectList(teams, nameof(Team.Id), nameof(Team.Name), SelectedTeamId);

            IEnumerable<Location> locations = _locationService.Get();
            Locations = new SelectList(locations, nameof(Location.Id), nameof(Location.Name), SelectedLocationId);
        }
    }
}
