using Microsoft.AspNetCore.Mvc;
using Web_assissignment.Models;
using Web_assissignment.ViewModels;

namespace Web_assissignment.Controllers
{
    public class TaskkController : Controller
    {
        private readonly MyAppContext appContext;

        public TaskkController(MyAppContext conn) { appContext = conn; }

        [HttpPost]
        public IActionResult Update_Task(int id)
        {
            var task = appContext.Tasks.FirstOrDefault(x => x.Task_id == id);

            if (task == null)
            {
                return BadRequest("Task not found");
            }
            TaskUpdateViewModel up = new TaskUpdateViewModel()
            {
                Task = task,
                Priority_list = new List<string>() { "Low", "Medium", "High" },
                Status_list = new List<string>() { "Pending", "In Progress", "Completed" },
                Projects_list = appContext.Projects.ToList(),
                Team_members_list = appContext.TeamMembers.ToList(),
            };
            return View(up);
        }

        //

        [HttpPost]
        public IActionResult Update_Task_red(TaskUpdateViewModel TaskVM)
        {
            var task = TaskVM.Task;
            //var tas = appContext.Tasks.FirstOrDefault(x => x.Task_id == task.Task_id);
            if (task == null)
            {
                return BadRequest("Task not found");
            }

            appContext.Tasks.Update(task);
            appContext.SaveChanges();
            return RedirectToAction( "Display_All_Projects" , "Projectt");
        }


    }
}
