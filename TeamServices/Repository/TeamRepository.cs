using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamServices.Models;

namespace TeamServices.Repository
{
    public class TeamRepository : ITeamRepository
    {
        protected static ICollection<Team> _teams;

        public TeamRepository()
        {
            if (_teams == null)
            {
                _teams = new List<Team>();
            }
        }

        public TeamRepository(ICollection<Team> teams)
        {
            _teams = teams;
        }

        public void AddTeam(Team team)
        {
            _teams.Add(team);
        }

        public ICollection<Team> GetAllTeams()
        {
            Member goleiro = new Member();
            goleiro.FirstName = "Tiboult";
            goleiro.LastName = "Courtois";

            Member negueba = new Member();
            negueba.FirstName = "Vinicius";
            negueba.LastName = "Junior";

            List<Member> lista = new List<Member>();
            lista.Add(goleiro);
            lista.Add(negueba);

            Team team = new Team();
            team.Name = "Real Madrid";
            team.Members = lista;

            _teams.Add(team);
            return _teams;
        }
    }
}
