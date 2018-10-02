using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamServices.Models;
using TeamServices.Repository;
using TeamServices.VO;

namespace TeamServices.Controllers
{
    public class TeamsController : Controller
    {
        private ITeamRepository _teamRepository;

        public TeamsController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet("api/getAllTeams")]
        public IActionResult GetAllTeams()
        {
            ICollection <Team> collectionTeams = _teamRepository.GetAllTeams();
            if (collectionTeams == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(collectionTeams);
            }
        }

        [HttpPost("api/addTeam")]
        public IActionResult AddTeam([FromBody] TeamVO teamVO)
        {

            try
            {
                if (teamVO == null)
                {
                    return BadRequest();
                }

                List<Member> listaMembros = new List<Member>();
                foreach (MemberVO memberVO in teamVO.Members)
                {
                    Models.Member members = new Models.Member
                    {
                        FirstName = memberVO.FirstName,
                        LastName = memberVO.LastName
                    };

                    listaMembros.Add(members);
                }


                Models.Team newTeam = new Models.Team
                {
                    Members = listaMembros,
                    Name = teamVO.Name
                };

                _teamRepository.AddTeam(newTeam);

                return Ok(newTeam);
            }
            catch (Exception e)
            {
                return BadRequest();
                throw e;

            }

        }
    }
}
