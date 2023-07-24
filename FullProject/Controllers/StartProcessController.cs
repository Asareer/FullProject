using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullProject.Data;
using FullProject.Models;
using FullProject.ViewModels;

namespace FullProject.Controllers
{
    public class StartProcessController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StartProcessController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var ProjectOrderList = _db.Project.Include(p=>p.Order).Where(p=>p.Order.States!= "0");

            if (ProjectOrderList.Any())
            {
                return View(ProjectOrderList);
            }
            else
            {
                TempData["Error"] = "المعذرة, لا يوجد حاليا أي مشروع موافق عليه (مقبول) كي تبدأ العمليات عليه";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> StartProcess(int Id_Projects)
        {
            var Project =  _db.Project.Where(e=>e.Id_Projects==Id_Projects).Include(p => p.Order).Where(p => p.Order.States != "0");

            if (Project !=null)
            {
                var process = await _db.StartProcess.FirstOrDefaultAsync(p=>p.Id_projects==Id_Projects);
                if (process == null) {
                    // لأن المشروع ليس لديه عمليات من قبل , نذهب و ننشئ له في جدول العمليات
                    var new_process = new StartProcesses
                    {
                        Id_projects = Id_Projects,
                    };
                    await _db.StartProcess.AddAsync(new_process);
                    await _db.SaveChangesAsync();
                    //var sActivity = new StartActivity
                    //{
                    //    id_SProcess = new_process.Id_SProcess,
                    //    Description =""
                    //};

                    
                    //await _db.StartActivity.AddAsync(sActivity);
                    //await _db.SaveChangesAsync();
                    TempData["New"] = "New Process";
                    return View(new_process);
                }
                else
                {
                    var taxPayer1 = await _db.TaxPayerData.Where(p=>p.Num_Process==1).FirstOrDefaultAsync(t=>t.id_SProcess == process.Id_SProcess);
                    if ( taxPayer1 == null)
                    {
                        
                        TempData["New"] = "New Process";
                        return View(process);
                    }
                    //else
                    //{
                    //    if(taxPayer1.Name_TaxPayers == null)
                    //    {
                    //        TempData["New"] = "New Process";
                    //        return View(process);
                    //    }
                    //}
                    TempData["New"] = "New Process";
                    return View(process);
                }
            }
            else
            {
                TempData["Error"] = "المعذرة, المشروع الحالي غير موافق عليه او أنه غير موجود";
                return RedirectToAction("Index", "Home");
            }

            

        }

        public async Task<IActionResult> StartProcess2(int Id_SProcess)
        {
            var check = new Process_Check
            {
                Id_SProcess = Id_SProcess,
            };
            var process = await _db.StartProcess.FindAsync(Id_SProcess);
            
            if (process == null)
            {
                TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                return RedirectToAction("Index", "Home");
            }

            var activity = await _db.StartActivity.FirstOrDefaultAsync(s=>s.id_SProcess==Id_SProcess);
            if(activity == null)
            {
                TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                return RedirectToAction("Index", "Home");
            }

            if (activity != null)
            {
                if (activity.Confirm == null)
                {
                    TempData["Activity_Not_Confirmed"] = "true";
                    
                }
                else
                {
                    TempData["Activity_Confirmed"] = "true";
                }
            }

            

            return View(check);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> StartProcess2(Process_Check check)
        {
            if(check.Activity_Check is not null)
            {
                var confirm = await _db.StartActivity.FirstOrDefaultAsync(s => s.id_SProcess == check.Id_SProcess);
                if(confirm == null)
                {
                    TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    confirm.Confirm = "1";
                    _db.StartActivity.Update(confirm);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("StartProcess2", new { Id_SProcess = check.Id_SProcess });
                }
            }

            return View();
        }

        public async Task<IActionResult> Show(int Id_SProcess)
        {
            var process = await _db.StartProcess.FindAsync(Id_SProcess);

            if (process == null)
            {
                TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                return RedirectToAction("Index", "Home");
            }

            var check_TaxPayer = await _db.TaxPayerData.FirstOrDefaultAsync(p=>p.id_SProcess == Id_SProcess);
            if (check_TaxPayer is null)
            {
                TempData["Error"] = "المعذرة, لا توجد بيانات مكلفون لهذا المشروع, الرجاء البدء من أول خطوة";
                return RedirectToAction("Index", "Home");
            }

            var check_Activity = await _db.StartActivity.FirstOrDefaultAsync(p => p.id_SProcess == Id_SProcess);
            if (check_Activity is null)
            {
                TempData["Error"] = "المعذرة, لا توجد بيانات نزول لهذا المشروع, الرجاء البدء من أول خطوة";
                return RedirectToAction("Index", "Home");
            }
            if (check_Activity.Result is null)
            {
                TempData["Error2"] = " يجب إضافة بيانات النزول لعرض بيانات بدء النشاط";
                return RedirectToAction("Data","StartActivity", new { Id_SProcess = Id_SProcess });
            }
                var show = await _db.TaxPayerData.FirstOrDefaultAsync(p=>p.id_SProcess ==Id_SProcess);
                return View(show);

        }

        public async Task<IActionResult> ShowResult(int Id_SProcess)
        {

            var process = await _db.StartProcess.FindAsync(Id_SProcess);


            if (process == null)
            {
                TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                return RedirectToAction("Index", "Home");
            }

            var check_TaxPayer = await _db.TaxPayerData.FirstOrDefaultAsync(p => p.id_SProcess == Id_SProcess);
            if (check_TaxPayer is null)
            {
                TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                return RedirectToAction("Index", "Home");
            }

            var check_Activity = await _db.StartActivity.FirstOrDefaultAsync(p => p.id_SProcess == Id_SProcess);
            if (check_Activity is null)
            {
                TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                return RedirectToAction("Index", "Home");
            }
            if (check_Activity.Result is null)
            {
                TempData["Error2"] = " يجب إضافة بيانات النزول لعرض بيانات بدء النشاط";
                return RedirectToAction("Data", "StartActivity", new { Id_SProcess = Id_SProcess });
            }
            var show = await _db.StartActivity.FirstOrDefaultAsync(a => a.id_SProcess == Id_SProcess);
            return View(show);

        }

        public IActionResult StartProcess3()
        {

            return View();

        }

    }
}
