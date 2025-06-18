using A42.Planning.Data.Abstractions;
using A42.Planning.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A42.Planning.WebApp.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly ITeamService _teamService;

        public IndexModel(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [BindProperty]
        public IEnumerable<Team> Teams { get; private set; } = [];

        [BindProperty]
        public int? SelectedTeamId { get; set; }

        public void OnGet()
        {
            Load();
        }

        public void OnPost(string name)
        {
            Team team = new Team(0, name, []);

            _teamService.Add(team);

            Load();
        }

        public void OnPostSelect(int selectedTeamId)
        {
            SelectedTeamId = selectedTeamId;

            Load();
        }

        public void OnPostDelete(int? selectedTeamId)
        {
            if (selectedTeamId.HasValue)
                _teamService.Remove(selectedTeamId.Value);

            Load();
        }

        public void Load()
        {
            Teams = _teamService.Get();
        }
    }
}
