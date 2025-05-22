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

        public void OnGet()
        {
            Load();
        }

        public void OnPost()
        {
            //_teamService.AddTeam();
            Load();
        }

        public void Load()
        {
            Teams = _teamService.Get();
        }
    }
}
