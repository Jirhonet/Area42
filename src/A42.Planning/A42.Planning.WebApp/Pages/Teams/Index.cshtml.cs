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
        public string Name { get; set; } = string.Empty;

        public void OnGet()
        {
            Load();
        }

        public void OnPost()
        {
            Team team = new Team(
                id: 0,
                name: Name,
                employees: []
            );

            _teamService.Add(team);

            ResetForm();
            Load();
        }

        public void Load()
        {
            Teams = _teamService.Get();
        }

        private void ResetForm()
        {
            Name = string.Empty;
        }
    }
}
