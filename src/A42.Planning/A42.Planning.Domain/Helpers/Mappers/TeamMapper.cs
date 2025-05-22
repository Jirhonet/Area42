using A42.Planning.Data.Dtos;

namespace A42.Planning.Domain.Helpers.Mappers
{
    internal static class TeamMapper
    {
        internal static TeamDto ToDto(this Team team)
        {
            TeamDto teamDto = new TeamDto()
            {
                Name = team.Name,
            };

            return teamDto;
        }

        internal static Team ToDomain(this TeamDto teamDto)
        {
            Team team = new Team(
                name: teamDto.Name,
                employees: []
            );

            return team;
        }
    }
}
