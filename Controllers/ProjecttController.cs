using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_assissignment.Models;
using Web_assissignment.ViewModels;

namespace Web_assissignment.Controllers
{
    public class ProjecttController : Controller
    {
        private readonly MyAppContext appContext;

        public ProjecttController(MyAppContext conn) { appContext = conn; }

        [HttpGet]
        public IActionResult Display_All_Projects()
        {
            var projects = appContext.Projects.ToList();
            return View(projects);
        }

        // add

        [HttpGet]
        public IActionResult Create_project()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create_project(Projectt pro)
        {
            appContext.Projects.Add(pro);
            appContext.SaveChanges();
            return RedirectToAction("Display_All_Projects");
        }

        // delete

        [HttpGet]
        public IActionResult Delete_project(int id)
        {
            var proj = appContext.Projects.FirstOrDefault(x => x.Project_id == id);
            if (proj == null)
            {
                return BadRequest("Not found this Project");
            }
            return View(proj);
        }

        [HttpPost]
        public IActionResult Delete_project(Projectt pro)
        {
            appContext.Projects.Remove(pro);
            appContext.SaveChanges();
            return RedirectToAction("Display_All_Projects");
        }

        // Update 

        [HttpGet]
        public IActionResult Update_project(int id)
        {
            var proj = appContext.Projects.FirstOrDefault(x => x.Project_id == id);
            if (proj == null)
            {
                return BadRequest("Not found this Project");
            }
            return View(proj);
        }

        [HttpPost]
        public IActionResult Update_project(Projectt pro)
        {
            appContext.Projects.Update(pro);
            appContext.SaveChanges();
            return RedirectToAction("Display_All_Projects");
        }

        // Details

        [HttpGet]
        public IActionResult Get_Project_Details(int id)
        {
            var pro = appContext.Projects.FirstOrDefault(x =>x.Project_id == id);
            var tasks = appContext.Tasks.Include(x => x.TeamMember).Where(x => x.Project_id == id).ToList();
            Project_DetailsViewModel Pvm = new Project_DetailsViewModel()
            {
                Proj = pro,
                Tasks_list = tasks
            };

            return View(Pvm);
        }


    }
}
