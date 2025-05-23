using A42.Planning.Domain;
using A42.Planning.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A42.Planning.WebApp.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly TeamService _teamService;

        public IndexModel(TeamService teamService)
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
