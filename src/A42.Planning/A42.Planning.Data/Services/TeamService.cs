using A42.Planning.Data.Abstractions;
using A42.Planning.Data.Dtos;
using A42.Planning.Data.Repositories;
using A42.Planning.Domain.Helpers.Mappers;

namespace A42.Planning.Domain.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamRepository _teamRepository;

        public TeamService(TeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        /// <inheritdoc />
        public IEnumerable<Team> Get()
        {
            IEnumerable<TeamDto> teamDtos = _teamRepository.Get();
            return teamDtos.Select(teamDto => teamDto.ToDomain());
        }

        /// <inheritdoc />
        public Team GetById(int id)
        {
            TeamDto teamDto = _teamRepository.GetById(id);
            return teamDto.ToDomain();
        }

        /// <inheritdoc />
        public void Add(Team team)
        {
            TeamDto teamDto = team.ToDto();
            _teamRepository.Insert(teamDto);
        }

        /// <inheritdoc />
        public void Remove(int teamId)
        {
            _teamRepository.Delete(teamId);
        }
    }
}
