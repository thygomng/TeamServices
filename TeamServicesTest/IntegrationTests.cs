using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TeamServices;
using TeamServices.Models;
using Xunit;

namespace TeamServicesTest
{
    public class IntegrationTests
    {
        private readonly TestServer testServer;
        private readonly HttpClient testClient;

        private readonly Team teamTest;

        public IntegrationTests()
        {
            this.testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            this.testClient = testServer.CreateClient();

            teamTest = this.CreateTeam();
        }

        [Fact]
        public async void TestTeamPostAndGet()
        {
            StringContent stringContent = new StringContent(
            JsonConvert.SerializeObject(teamTest), UnicodeEncoding.UTF8,"application/json");

            HttpResponseMessage postResponse =  await testClient.PostAsync("/addTeam", stringContent);
            postResponse.EnsureSuccessStatusCode();
            var getResponse = await testClient.GetAsync("/getAllTeams");
            getResponse.EnsureSuccessStatusCode();

            string raw = await getResponse.Content.ReadAsStringAsync();
            List<Team> teams = JsonConvert.DeserializeObject<List<Team>>(raw);
            Console.WriteLine(teams[0].ID);
            Console.WriteLine(teamTest.ID);
            Console.WriteLine(teams.Count);
            //Assert.Single(teams);
            Assert.Equal("Real Madrid", teams[0].Name);
            Assert.Equal(teamTest.ID, teams[0].ID);

        }


        private Team CreateTeam()
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

            Team teamResp = new Team
            {
                //ID = Guid.NewGuid(),
                Name = "Real Madrid",
                Members = lista
            };

            return teamResp;
        }
    }
}
