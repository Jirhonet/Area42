using A42.Planning.Data.Dtos;
using A42.Planning.Data.Repositories;
using A42.Planning.Domain.Abstractions.Interfaces;
using A42.Planning.Domain.Helpers.Mappers;

namespace A42.Planning.Domain.Services
{
    public class TeamService : ITeamService, IService
    {
        private readonly TeamRepository _teamRepository;

        public TeamService(TeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public IEnumerable<Team> Get()
        {
            IEnumerable<TeamDto> teamDtos = _teamRepository.Get();
            return teamDtos.Select(teamDto => teamDto.ToDomain());
        }

        public void Add(Team team)
        {
            TeamDto teamDto = team.ToDto();
            _teamRepository.Insert(teamDto);
        }
    }
}
