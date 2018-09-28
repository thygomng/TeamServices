using System;
using System.Collections.Generic;
using System.Text;
using TeamServices.Controllers;
using TeamServices.Models;
using Xunit;

namespace TeamServicesTest
{
    
    public class TeamControllerTest
    {
        [Fact]
        public void QueryTeamListReturnsCorrectTeams()
        {
            TeamsController _teamController = new TeamsController();
            //TeamsController controller = new TeamsController(new TestMemoryTeamRepository());
            //var rawTeams = (IEnumerable<Team>)(controller.GetAllTeams() as ObjectResult).Value;
            //List<Team> teams = new List<Team>(rawTeams);
            //Assert.Equal(teams.Count, 2);
            //Assert.Equal(teams[0].Name, "one");
            //Assert.Equal(teams[1].Name, "two");
            List<Team> teams = new List<Team>( _teamController.GetAllTeams() );
        }
    }
}
