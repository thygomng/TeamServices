using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamServices.Models;

namespace TeamServices.Repository
{
    public interface ITeamRepository
    {
        ICollection<Team> GetAllTeams();
        void AddTeam(Team team);
    }
}
