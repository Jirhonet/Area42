﻿using A42.Planning.Data.Dtos;

namespace A42.Planning.Domain.Helpers.Mappers
{
    internal static class TeamMapper
    {
        internal static TeamDto ToDto(this Team team)
        {
            TeamDto teamDto = new TeamDto()
            {
                Id = team.Id,
                Name = team.Name,
            };

            return teamDto;
        }

        internal static Team ToDomain(this TeamDto teamDto)
        {
            Team team = new Team(
                id: teamDto.Id,
                name: teamDto.Name,
                employees: []
            );

            return team;
        }
    }
}
