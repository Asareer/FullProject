using FullProject.Data;
using FullProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullProject.Controllers
{
    public class ProjectOrderController : Controller
    {

        private readonly ApplicationDbContext _db;
        public ProjectOrderController(ApplicationDbContext db)
        {
            _db = db;
        }
     
        public IActionResult Index()
        {

            //IEnumerable<Projects> ProjectOrderList = _db.Project.ToList();
            var ProjectOrderList = _db.Project.ToList();
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


        //GET
        public IActionResult AddFullProjectroject()
        {
       
            return View();  

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFullProjectroject(Projects projects)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(projects);

                }
                else
                {
                    var found = _db.Order.Where(o => o.Id_Orders == projects.Id_Orders);
                    if (found.Any())
                    {
                        TempData["ErrorData"] = "المعذرة, رقم الطلب هذا موجود من قبل , يرجى إختيار رقم طلب آخر";
                        return RedirectToAction("Index");
                    }
                    Orders order = new Orders
                    {
                        Num_Order = projects.Id_Orders
                    };

                    await _db.Order.AddAsync(order);
                    await _db.SaveChangesAsync();
                    projects.Id_Orders = order.Id_Orders;
                    await _db.Project.AddAsync(projects);
                    await _db.SaveChangesAsync();
                    TempData["successData"] = " تم إضافة بيانات المشروع بنجاح";
                    return RedirectToAction("Index");
                }
            }
           catch
            {
                TempData["vailddata"]=(" يوجد هناك مشكلة يرجى المحاولة لاحقاً") ;
                return View(projects);
            }
        }

        //GET
        public IActionResult EditFullProjectroject(int? Id_Projects)
        {
            if(Id_Projects == null || Id_Projects == 0)
            {
                return NotFound();
            }
            var projects = _db.Project.Find(Id_Projects);
            if(projects == null)
            {
                return NotFound();
            }
            return View(projects);

        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditFullProjectroject(Projects projects)
        {
            _db.Project.Update(projects);
            _db.SaveChanges();
            TempData["successData"] = " تم تحديث بيانات المشروع بنجاح";
            return RedirectToAction("Index");


        }

        //GET
        public IActionResult DeleteFullProjectroject(int? Id_Projects)
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

        //POST
        [HttpPost , ActionName("DeleteFullProjectroject")]
        [ValidateAntiForgeryToken]
        public IActionResult Deleteproject(int? Id_Projects)
        {

            var projects = _db.Project.Find(Id_Projects);
            if ( projects == null)
            {
                return NotFound();
            }
            _db.Remove(projects); 
            _db.SaveChanges();
            TempData["successData"] = " تم حذف المشروع بنجاح";
            return RedirectToAction("Index");


        }


       

    
}
}

