using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TeamServices.Controllers;
using TeamServices.Models;
using TeamServices.Repository;
using Xunit;

namespace TeamServicesTest
{
    
    public class TeamControllerTest
    {
        protected ITeamRepository _teamRepository;


        [Fact]
        public void QueryTeamListReturnsCorrectTeams()
        {
            
            var services = new ServiceCollection();
            services.AddTransient<ITeamRepository, TeamRepository>();
            var serviceProvider = services.BuildServiceProvider();
            _teamRepository = serviceProvider.GetService<ITeamRepository>();
            //TeamsController teamsController = new TeamsController(_teamRepository);

            //TeamsController controller = new TeamsController(new TestMemoryTeamRepository());
            //var rawTeams = (IEnumerable<Team>)(controller.GetAllTeams() as ObjectResult).Value;
            //List<Team> teams = new List<Team>(rawTeams);
            //Assert.Equal(teams.Count, 2);
            //Assert.Equal(teams[0].Name, "one");
            //Assert.Equal(teams[1].Name, "two");
            List<Team> teams = new List<Team>(_teamRepository.GetAllTeams() );
        }

        [Fact]
        public void CreateTeams()
        {
           TeamsController teamsController = this.CreateController();

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

            _teamRepository.AddTeam(team);
        }

        private TeamsController CreateController()
        {
            var services = new ServiceCollection();
            services.AddTransient<ITeamRepository, TeamRepository>();
            var serviceProvider = services.BuildServiceProvider();
            _teamRepository = serviceProvider.GetService<ITeamRepository>();
            TeamsController teamsController = new TeamsController(_teamRepository);

            return teamsController;
        }
    }
}
