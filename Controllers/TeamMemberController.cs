using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_assissignment.Models;

namespace Web_assissignment.Controllers
{
    public class TeamMemberController : Controller
    {
        private readonly MyAppContext appContext;
        public TeamMemberController(MyAppContext conn) { appContext = conn; }

        [HttpGet]
        public IActionResult Get_TeamMember_details(int id)
        {
            var mem = appContext.TeamMembers.FirstOrDefault(x => x.TeamMember_id == id);
            if (mem == null)
            {
                return BadRequest("member not found");
            }

            var tasks = appContext.Tasks.Include(x => x.Project).Where(x => x.TeamMember_id == id).ToList();

            TeamMember_DetailsViewModel TM = new TeamMember_DetailsViewModel()
            {
                member = mem,
                Tasks_list = tasks
            };

            return View(TM);
        }

        // Delete 

        [HttpGet]
        public IActionResult Delete_teamMember(int id)
        {
            var del = appContext.TeamMembers.FirstOrDefault(x => x.TeamMember_id == id);
            if (del == null)
            {
                return BadRequest("Team member not found");
            }
            return View(del);
        }

        [HttpPost]
        public IActionResult Delete_teamMember(TeamMember team)
        {
            appContext.TeamMembers.Remove(team);
            appContext.SaveChanges();
            return RedirectToAction("Display_All_Projects", "Projectt");
        }

        // update
        [HttpGet]
        public IActionResult Update_TeamMember(int id)
        {
            var mem = appContext.TeamMembers.FirstOrDefault(x => x.TeamMember_id == id);
            if (mem == null)
            {
                return BadRequest("Team member not found");
            }
            return View(mem);
        }

        [HttpPost]
        public IActionResult Update_TeamMember(TeamMember member)
        {
            appContext.TeamMembers.Update(member);
            appContext.SaveChanges();
            return RedirectToAction("Display_All_Projects", "Projectt");
        }


    }
}
