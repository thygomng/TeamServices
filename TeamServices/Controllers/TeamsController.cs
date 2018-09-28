using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamServices.Models;

namespace TeamServices.Controllers
{
    public class TeamsController : Controller
    {
        public List<Team> GetAllTeams()
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

            List<Team> listaTeam = new List<Team>();
            listaTeam.Add(team);
            return listaTeam;
        }
    }
}
