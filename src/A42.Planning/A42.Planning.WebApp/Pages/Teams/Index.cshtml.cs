using A42.Planning.Data.Abstractions;
using A42.Planning.Domain;
using Microsoft.AspNetCore.Mvc;

namespace A42.Planning.WebApp.Pages.Teams
{
    public class IndexModel : AreaPageModel
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
                Team team = new Team(0, name, []);

                _teamService.Add(team);

                Load();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void OnPostSelect(int selectedTeamId)
        {
            try
            {
                SelectedTeamId = selectedTeamId;

                Load();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void OnPostDelete(int? selectedTeamId)
        {
            try
            {
                if (selectedTeamId.HasValue)
                    _teamService.Remove(selectedTeamId.Value);

                Load();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void Load()
        {
            Teams = _teamService.Get();
        }
    }
}
