using A42.Planning.Data.Abstractions;
using A42.Planning.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace A42.Planning.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITeamService _teamService;
        private readonly IPlanningService _planningService;

        public IndexModel(ITeamService teamService, IPlanningService planningService)
        {
            _teamService = teamService;
            _planningService = planningService;
        }

        #region Properties
        [BindProperty(SupportsGet = true)]
        public DateTime SelectedDate { get; set; } = DateTime.Today;

        [BindProperty(SupportsGet = true)]
        public int? SelectedTeamId { get; set; }

        public SelectList Teams { get; set; }
        public Domain.Planning Planning { get; set; }
        #endregion

        public void OnGet()
        {
            var teams = _teamService.Get();
            Teams = new SelectList(teams, nameof(Team.Id), nameof(Team.Name), SelectedTeamId);

            if (SelectedTeamId.HasValue)
            {
                var team = teams.FirstOrDefault(t => t.Id == SelectedTeamId.Value);
                if (team != null)
                {
                    Planning = _planningService.Get(DateOnly.FromDateTime(SelectedDate), team);
                }
            }
        }
    }
}
