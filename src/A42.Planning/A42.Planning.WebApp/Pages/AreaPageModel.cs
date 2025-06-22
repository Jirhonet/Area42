using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace A42.Planning.WebApp.Pages
{
    public class AreaPageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? Error { get; set; }

        public virtual void ShowError(Exception ex)
        {
            Error = ex.Message;
        }
    }
}
