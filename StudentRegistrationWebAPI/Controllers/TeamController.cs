using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationWebAPI.Data;
using StudentRegistrationWebAPI.Models;

namespace StudentRegistrationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public TeamController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public IEnumerable<Teams> GetAllTeams()
        {
            var teams = _db.Teams.ToList();
            List<Teams> teamsList = new List<Teams>();

            foreach (var team in teams)
            {
                Teams obj = new Teams
                {
                    TeamId = team.TeamId,
                    TeamName = team.TeamName,
                };
                teamsList.Add(obj);
            }
            return teamsList;   
        }

        [HttpPost("AddTeams")]
        public Teams AddTeam(Teams newTeam)
        {
            Teams newTeams = new Teams
            {
                TeamId = newTeam.TeamId,
                TeamName = newTeam.TeamName,
            };
            _db.Teams.Add(newTeams);
            _db.SaveChanges();
            return newTeams;

        }
    }
}
