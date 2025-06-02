using System.Text;
using A42.Planning.Domain;

namespace A42.Planning.WebApp.Helpers
{
    public static class Formatting
    {
        public static string Display(this Domain.Planning planning)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Planning for {planning.Date.ToString("yyyy-MM-dd")}");
            sb.AppendLine($"Team: {planning.Team.Name}");

            foreach (PlanningItem item in planning.Items)
            {
                sb.AppendLine($"{item.Start.ToString("HH:mm")} - {item.End.ToString("HH:mm")} {item.Title}");
            }

            return sb.ToString();
        }
    }
}
