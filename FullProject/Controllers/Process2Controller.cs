using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullProject.Data;
using FullProject.Models;

namespace FullProject.Controllers
{
    public class Process2Controller : Controller
    {
        private readonly ApplicationDbContext _db;
        public Process2Controller(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add(int Id_SProcess)
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
                return RedirectToAction("Data", "StartActivity", new { Id_SProcess = Id_SProcess });
            }

            var process2 = await _db.Process2.FirstOrDefaultAsync(p=>p.Id_Processes2==Id_SProcess);
            if (process2 is not null)
            {
                var taxpayer = await _db.TaxPayer.FirstOrDefaultAsync(t => t.Id_Processes2 == process2.Id_Processes2);
                if (taxpayer is null)
                {
                    //var new_Taxpayer = new TaxPayers
                    //{
                    //    Id_Processes2 = process2.Id_Processes2,
                    //};
                    //await _db.TaxPayer.AddAsync(new_Taxpayer);
                    //await _db.SaveChangesAsync();
                    TempData["Id_Process2"] = process2.Id_Processes2;
                    return View();
                }
                else
                {
                    TempData["found_Pocess2"] = "true";
                    TempData["Id_Process2"] = process2.Id_Processes2;
                    return View(taxpayer);
                }
            }
            else
            {
                var new_Process2 = new Processes2
                {
                    id_SProcess = Id_SProcess,
                };
                await _db.Process2.AddAsync(new_Process2);
                await _db.SaveChangesAsync();
                TempData["Id_Process2"] = new_Process2.Id_Processes2;
                return View();
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(TaxPayers taxPayers)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(taxPayers);
                }
                else
                {
                    var check = await _db.TaxPayer.FirstOrDefaultAsync(t => t.Id_Processes2 == taxPayers.Id_Processes2);
                    if (check == null)
                    {
                        await _db.TaxPayer.AddAsync(taxPayers);
                        await _db.SaveChangesAsync();
                        TempData["Tax_Payer_Success"] = "تم إضافة بيانات النزول بنجاح";
                    }
                    return RedirectToAction("Add2", "Process2", new { Id_Process2 = taxPayers.Id_Processes2 });
                }
            }
            catch (Exception)
            {
                TempData["Error"] = "المعذرة, حصل خطأ ما , الرجاء المحاولة لاحقا";
                return RedirectToAction("Index", "Home");
            }
            
        }

        public IActionResult Add2()
        {
            return View();
        }

        public IActionResult Add3()
        {
            return View();
        }
    }
}
