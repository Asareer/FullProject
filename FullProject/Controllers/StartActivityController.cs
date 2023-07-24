using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FullProject.Data;
using FullProject.Models;

namespace FullProject.Controllers
{
    public class StartActivityController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StartActivityController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Data(int Id_SProcess)
        {
            var process = await _db.StartProcess.FindAsync(Id_SProcess);
            if (process == null)
            {
                TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                return RedirectToAction("Index", "Home");
            }

            var found = await _db.TaxPayerData.Where(t => t.Num_Process == 1).FirstOrDefaultAsync(s => s.id_SProcess == Id_SProcess);
            if (found != null)
            {
                if (found.Day != null && found.Time != null && found.Date_SProcess != null)
                {
                    TempData["found1"] = "true";
                }
                TempData["Process1"] = Id_SProcess;
                
                return View(found);
            }
            else
            {
                TempData["Error1"] = " يجب إضافة بيانات المكلفون أولا";
                return RedirectToAction("AddTaxpayer", new { Id_SProcess = Id_SProcess });
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Data(TaxPayerData tax)
        {
            try
            {
                


                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, " الرجاء تعبئة بيانات النزول كاملة");
                    TempData["Process1"] = tax.id_SProcess;
                    return View(tax);
                }

                else if (tax.Day == null || tax.Time == null || tax.Date_SProcess == null)
                {
                    
                        ModelState.AddModelError(string.Empty, " الرجاء تعبئة بيانات النزول كاملة");
                        TempData["Process1"] = tax.id_SProcess;
                        return View(tax);
                }

                else
                {
                    var found = await _db.TaxPayerData.Where(t => t.Num_Process == 1).FirstOrDefaultAsync(s => s.id_SProcess == tax.id_SProcess);
                    if (found == null)
                    {
                        TempData["Error1"] = " يجب إضافة بيانات المكلفون أولا";
                        return RedirectToAction("AddTaxpayer", new { Id_SProcess = tax.id_SProcess });
                    }

                    else
                    {
                        if(found.Name_TaxPayers==null || found.Descrip_TaxPayers==null ||  found.Office == null)
                        {
                            TempData["Error1"] = " يجب إضافة بيانات المكلفون كاملة";
                            return RedirectToAction("AddTaxpayer", new { Id_SProcess = tax.id_SProcess });
                        }
                        else
                        {
                            
                            found.Day = tax.Day;
                            found.Time = tax.Time;
                            found.Date_SProcess = tax.Date_SProcess;
                             _db.TaxPayerData.Update(found);
                            await _db.SaveChangesAsync();
                            TempData["successData1"] = " تم إضافة بيانات المكلفون بنجاح";
                            return RedirectToAction("AddPurpose", new { Id_SProcess = tax.id_SProcess });
                        }
                        
                    }
                }
            }
            catch (Exception)
            {
                TempData["Error"] = "المعذرة, حصل خطأ ما الرجاء المحاولة لاحقا";
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> AddTaxpayer(int Id_SProcess)
        {
            var process = await _db.StartProcess.FindAsync(Id_SProcess);
            if(process == null)
            {
                TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                return RedirectToAction("Index", "Home");
            }

            var found = await _db.TaxPayerData.Where(t=>t.Num_Process==1).FirstOrDefaultAsync(s => s.id_SProcess == Id_SProcess);
            if (found != null)
            {
                TempData["found"] = "true";
                TempData["Process"] = Id_SProcess;
                return View(found);
            }
            TempData["Process"] = Id_SProcess;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTaxpayer(TaxPayerData tax)
        {
            try
            {


                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "حدث خطأ ما, الرجاء تعبئة البيانات كاملة");
                    TempData["Process"] = tax.id_SProcess;
                    return View(tax);
                }
                else
                {
                    var found = await _db.TaxPayerData.Where(t => t.Num_Process == 1).FirstOrDefaultAsync(s => s.id_SProcess == tax.id_SProcess);
                    if (found == null)
                    {
                        tax.Num_Process = 1;
                        await _db.TaxPayerData.AddAsync(tax);
                        await _db.SaveChangesAsync();
                        TempData["Success"] = " تم إضافة بيانات المكلفون بنجاح";
                        return RedirectToAction("Data", new { Id_SProcess = tax.id_SProcess });
                    }
                    //TempData["Success"] = " تم إضافة بيانات المكلفون بنجاح";
                    //_db.TaxPayerData.Update(tax);
                    //await _db.SaveChangesAsync();
                    return RedirectToAction("Data", new { Id_SProcess = tax.id_SProcess });
                }
            }
            catch (Exception)
            {
                TempData["Error"] = "المعذرة, حصل خطأ ما الرجاء المحاولة لاحقا";
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> AddPurpose(int Id_SProcess)
        {
            var process = await _db.StartProcess.FindAsync(Id_SProcess);
            if (process == null)
            {
                TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                return RedirectToAction("Index", "Home");
            }

            var found = await _db.TaxPayerData.Where(t => t.Num_Process == 1).FirstOrDefaultAsync(s => s.id_SProcess == Id_SProcess);
            if(found == null)
            {
                TempData["Error1"] = " يجب إضافة بيانات المكلفون أولا";
                return RedirectToAction("AddTaxpayer", new { Id_SProcess = Id_SProcess });
            }

            else if (found.Day.ToString() == null || found.Time.ToString() == null || found.Date_SProcess.ToString() == null)
            {
                TempData["Error2"] = " يجب إضافة بيانات النزول لإضافة الغرض";
                return RedirectToAction("Data", new { Id_SProcess = Id_SProcess });
            }

            else
            {
                TempData["Process2"] = Id_SProcess;
                var activity_Found = await _db.StartActivity.FirstOrDefaultAsync(s=>s.id_SProcess==Id_SProcess);
                if(activity_Found == null)
                {
                    return View();
                }
                else if(activity_Found.Purpose == null)
                {
                    return View();
                }
                else
                {
                    TempData["found2"] = "true";
                    return View(activity_Found);
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPurpose(StartActivity activity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, " الرجاء تعبئة الغرض");
                    TempData["Process2"] = activity.id_SProcess;
                    return View();
                }
                else
                {
                    if(activity.Purpose == null)
                    {
                        ModelState.AddModelError(string.Empty, " الرجاء تعبئة الغرض");
                        TempData["Process2"] = activity.id_SProcess;
                        return View();
                    }
                    else
                    {
                        await _db.StartActivity.AddAsync(activity);
                        await _db.SaveChangesAsync();
                        TempData["successData2"] = " تم إضافة الغرض بنجاح";
                        return RedirectToAction("AddDescription", new { Id_SProcess = activity.id_SProcess });
                    }
                }
            }
            catch (Exception)
            {
                TempData["Error"] = "المعذرة, حصل خطأ ما الرجاء المحاولة لاحقا";
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> AddDescription(int Id_SProcess)
        {
            var process = await _db.StartProcess.FindAsync(Id_SProcess);
            if (process == null)
            {
                TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                return RedirectToAction("Index", "Home");
            }

            var found = await _db.TaxPayerData.Where(t => t.Num_Process == 1).FirstOrDefaultAsync(s => s.id_SProcess == Id_SProcess);
            if (found == null)
            {
                TempData["Error1"] = " يجب إضافة بيانات المكلفون أولا";
                return RedirectToAction("AddTaxpayer", new { Id_SProcess = Id_SProcess });
            }

            else if (found.Day.ToString() == null || found.Time.ToString() == null || found.Date_SProcess.ToString() == null)
            {
                TempData["Error2"] = " يجب إضافة بيانات النزول لإضافة الغرض";
                return RedirectToAction("Data", new { Id_SProcess = Id_SProcess });
            }

            else
            {
                TempData["Process3"] = Id_SProcess;
                var activity_Found = await _db.StartActivity.FirstOrDefaultAsync(s => s.id_SProcess == Id_SProcess);
                if (activity_Found == null)
                {
                    TempData["Error3"] = " يجب إضافة الغرض ";
                    return RedirectToAction("AddPurpose", new { Id_SProcess = Id_SProcess });
                }
                else if (activity_Found.Purpose == null)
                {
                    TempData["Error3"] = " يجب إضافة الغرض ";
                    return RedirectToAction("AddPurpose", new { Id_SProcess = Id_SProcess });
                }
                else if(activity_Found.Description == null)
                {
                    return View(activity_Found);
                }

                else{
                    TempData["found3"] = "true";
                    return View(activity_Found);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddDescription(StartActivity activity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, " الرجاء تعبئة الوصف");
                    TempData["Process3"] = activity.id_SProcess;
                    return View();
                }
                else
                {
                    if (activity.Description == null)
                    {
                        ModelState.AddModelError(string.Empty, " الرجاء تعبئة الوصف");
                        TempData["Process3"] = activity.id_SProcess;
                        return View();
                    }
                    else
                    {
                        var this_Activity = await _db.StartActivity.Where(s => s.id_SProcess == activity.id_SProcess).FirstOrDefaultAsync();
                        if (this_Activity == null)
                        {
                            TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            this_Activity.Description = activity.Description;
                            _db.StartActivity.Update(this_Activity);
                            await _db.SaveChangesAsync();
                            TempData["successData3"] = " تم إضافة الوصف بنجاح";
                            return RedirectToAction("AddResult", new { Id_SProcess = activity.id_SProcess });
                        }
                    }
                }
            }
            catch (Exception)
            {
                TempData["Error"] = "المعذرة, حصل خطأ ما الرجاء المحاولة لاحقا";
                return RedirectToAction("Index", "Home");
            }
        }
        public async Task<IActionResult> AddResult(int Id_SProcess)
        {
            var process = await _db.StartProcess.FindAsync(Id_SProcess);
            if (process == null)
            {
                TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                return RedirectToAction("Index", "Home");
            }

            var found = await _db.TaxPayerData.Where(t => t.Num_Process == 1).FirstOrDefaultAsync(s => s.id_SProcess == Id_SProcess);
            if (found == null)
            {
                TempData["Error1"] = " يجب إضافة بيانات المكلفون أولا";
                return RedirectToAction("AddTaxpayer", new { Id_SProcess = Id_SProcess });
            }

            else if (found.Day.ToString() == null || found.Time.ToString() == null || found.Date_SProcess.ToString() == null)
            {
                TempData["Error2"] = " يجب إضافة بيانات النزول لإضافة الغرض";
                return RedirectToAction("Data", new { Id_SProcess = Id_SProcess });
            }

            else
            {
                TempData["Process4"] = Id_SProcess;
                var activity_Found = await _db.StartActivity.FirstOrDefaultAsync(s => s.id_SProcess == Id_SProcess);
                if (activity_Found == null)
                {
                    TempData["Error3"] = " يجب إضافة الغرض ";
                    return RedirectToAction("AddPurpose", new { Id_SProcess = Id_SProcess });
                }
                else if (activity_Found.Purpose == null)
                {
                    TempData["Error3"] = " يجب إضافة الغرض ";
                    return RedirectToAction("AddPurpose", new { Id_SProcess = Id_SProcess });
                }
                else if (activity_Found.Description == null)
                {
                    TempData["Error4"] = " يجب إضافة الوصف ";
                    return RedirectToAction("AddDescription", new { Id_SProcess = Id_SProcess });
                }

                else if (activity_Found.Result == null)
                {
                    return View();
                }
                else
                {
                    TempData["found4"] = "true";
                    return View(activity_Found);
                }
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddResult(StartActivity activity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, " الرجاء تعبئة النتيجة");
                    TempData["Process4"] = activity.id_SProcess;
                    return View();
                }
                else
                {
                    if (activity.Result == null)
                    {
                        ModelState.AddModelError(string.Empty, " الرجاء تعبئة النتيجة");
                        TempData["Process4"] = activity.id_SProcess;
                        return View();
                    }
                    else
                    {
                        var this_Activity = await _db.StartActivity.Where(s => s.id_SProcess == activity.id_SProcess).FirstOrDefaultAsync();
                        if (this_Activity == null)
                        {
                            TempData["Error"] = "المعذرة, لا توجد عمليات لهذا المشروع, الرجاء البدء من أول خطوة";
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            this_Activity.Result = activity.Result;
                            _db.StartActivity.Update(this_Activity);
                            await _db.SaveChangesAsync();
                            TempData["Process5"] = activity.id_SProcess;
                            TempData["successData4"] = " تم إضافة الوصف بنجاح";
                            return RedirectToAction("StartProcess2", "StartProcess", new { Id_SProcess = activity.id_SProcess });
                        }
                    }
                }
            }
            catch (Exception)
            {
                TempData["Error"] = "المعذرة, حصل خطأ ما الرجاء المحاولة لاحقا";
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
