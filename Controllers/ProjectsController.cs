using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MVCTaskManager.Model;

namespace MVCTaskManager.Controller
{
    public class ProjectsController : ControllerBase
    {

        [HttpGet]
        [Route("api/projects")]
        [EnableCors("OpenCORSPolicy")]
        public List<Project> Get()
        {
            TaskManagerDbContext db = new TaskManagerDbContext();
            List<Project> projects = db.Projects.ToList();
            return projects;
        }

        [HttpPost]
        [Route("api/projects")]
        [EnableCors("OpenCORSPolicy")]
        public Project Post([FromBody] Project project)
        {
            TaskManagerDbContext db = new TaskManagerDbContext();
            db.Projects.Add(project);
            db.SaveChanges();
            return project;
        }

        [HttpPut]
        [Route("api/projects")]
        [EnableCors("OpenCORSPolicy")]
        public Project Put([FromBody] Project project)
        {
            TaskManagerDbContext db = new TaskManagerDbContext();
            Project existingproject = db.Projects.Where(x => x.ProjectId == project.ProjectId).FirstOrDefault();
            if (existingproject != null)
            {
                existingproject.ProjectName = project.ProjectName;
                existingproject.DateOfStart = project.DateOfStart;
                existingproject.TeamSize = project.TeamSize;
                db.SaveChanges();
                return existingproject;
            }
            else
            {
                return null;
            }


        }

        [HttpDelete]
        [Route("api/projects")]
        [EnableCors("OpenCORSPolicy")]
        public int Delete(int ProjectID)
        {
            TaskManagerDbContext db = new TaskManagerDbContext();
            Project existingproject = db.Projects.Where(x => x.ProjectId == ProjectID).FirstOrDefault();
            if (existingproject != null)
            {
                db.Projects.Remove(existingproject);
                db.SaveChanges();
                return ProjectID;
            }
            else
            {
                return -1;
            }


        }

        [HttpGet]
        [Route("api/projects/search/{searchby}/{searchtext}")]
        [EnableCors("OpenCORSPolicy")]
        public List<Project> Search(string searchBy,string searchText)
        {
            TaskManagerDbContext db = new TaskManagerDbContext();
            List<Project> projects = null;

            if(searchBy == "ProjectID")
            {
                projects = db.Projects.Where(x=>x.ProjectId.ToString().Contains(searchText)).ToList();
            }
            else if (searchBy == "ProjecName")
            {
                projects = db.Projects.Where(x => x.ProjectName.ToString().Contains(searchText)).ToList();
            }
            else if (searchBy == "DateOfStart")
            {
                projects = db.Projects.Where(x => x.DateOfStart.ToString().Contains(searchText)).ToList();
            }
            else if (searchBy == "TeamSize")
            {
                projects = db.Projects.Where(x => x.TeamSize.ToString().Contains(searchText)).ToList();
            }

            return projects;
        }

    }
}
