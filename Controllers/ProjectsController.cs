using Microsoft.AspNetCore.Mvc;
using MVCTaskManager.Model;

namespace MVCTaskManager.Controller
{
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        [Route("api/projects")]
        public List<Project> Get()
        {
            TaskManagerDbContext db = new TaskManagerDbContext();
            List<Project> projects = db.Projects.ToList();
            return projects;
        }
    }
}
