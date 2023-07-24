using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullProject.Data;

namespace FullProject.Controllers
{
    public class FinishProjectController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FinishProjectController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            //IEnumerable<Projects> ProjectOrderList = _db.Project.ToList();
            var ProjectOrderList = _db.Project.Include(p => p.Order).Where(e=>e.Order.States!="1").ToList();
            return View(ProjectOrderList);


        }

        //GET
        public IActionResult ShowProject(int? Id_Projects)
        {
            if (Id_Projects == null || Id_Projects == 0)
            {
                return NotFound();
            }
            var projects = _db.Project.Find(Id_Projects);
            if (projects == null)
            {
                return NotFound();
            }
            return View(projects);




        }
    }
}
