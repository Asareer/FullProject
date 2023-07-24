using Microsoft.AspNetCore.Mvc;
//using Microsoft.Build.Evaluation;
using Microsoft.EntityFrameworkCore;
using FullProject.Data;
using FullProject.Models;

namespace FullProject.Controllers
{
    public class ActionsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ActionsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(int Id_Projects)
        {
            var project_found= _db.Project.Find(Id_Projects);
            if (project_found == null)
            {
                TempData["ErrorData"] = "المعذرة,المشروع المطلوب غير موجود حاليا , الرجاء المحاولة لاحقا";
                
                return RedirectToAction("Index", "ProjectOrder");
            }

            var action_found = _db.Action.FirstOrDefault(a=>a.Id_projects == Id_Projects);
            if(action_found == null)
            {
                var new_action = new Actions
                {
                    Id_projects = Id_Projects,
                    Action1_Status = false,
                    Action2_Status = false,
                };
                await _db.Action.AddAsync(new_action);
                    await _db.SaveChangesAsync();
                return View(new_action);
            }
            else
            {
                return View(action_found);
            }
            //var ActionList = _db.Action.ToList();
            

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Actions actions1_Note)
        {
            var project_found = _db.Project.Find(actions1_Note.Id_projects);
            if (project_found == null)
            {
                TempData["ErrorData"] = "المعذرة,المشروع المطلوب غير موجود حاليا , الرجاء المحاولة لاحقا";

                return RedirectToAction("Index", "ProjectOrder");
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "حصل خطأ ما أثناء إضافة الملاحظة الرجاء تعبئة ملاحظة وصول طلب المشروع";
                    return RedirectToAction("Index", new { Id_Projects = actions1_Note.Id_projects });
                }
                else
                {
                    var action = await _db.Action.FindAsync(actions1_Note.Id_Actions);
                    if (action == null)
                    {
                        TempData["ErrorData"] = "المعذرة, يجب بدأ إجراءات المشروع من أول خطوة";
                        return RedirectToAction("Index", "ProjectOrder");
                    }
                    else
                    {
                        if(action.Action1_Note == null)
                        {
                            action.Action1_Note = actions1_Note.Action1_Note;
                            _db.Action.Update(action);
                            await _db.SaveChangesAsync();
                            TempData["Note_Success"] = "تم إضافة ملاحظة وصول طلب المشروع بنجاح";
                            return RedirectToAction("Index", new { Id_Projects = actions1_Note.Id_projects });
                        }

                        else if(action.Action1_Note == actions1_Note.Action1_Note)
                        {
                            TempData["Note_Success"] = "لم يتم تغيير الملاحظة";
                            return RedirectToAction("Index", new { Id_Projects = actions1_Note.Id_projects });
                        }
                        else
                        {
                            action.Action1_Note = actions1_Note.Action1_Note;
                            _db.Action.Update(action);
                            await _db.SaveChangesAsync();
                            TempData["Note_Success"] = "تم تعديل ملاحظة وصول طلب المشروع بنجاح";
                            return RedirectToAction("Index", new { Id_Projects = actions1_Note.Id_projects });
                        }
                    }
                }
            }
            catch (Exception)
            {
                TempData["ErrorData"] = "المعذرة, حصل خطأ ما الرجاء المحاولة مرة أخرى";
                return RedirectToAction("Index", "ProjectOrder");
            }
        }
         
        //Get
        public async Task<IActionResult> Action2(int Id_Projects)
        {
            var project_found = _db.Project.Find(Id_Projects);
            if (project_found == null)
            {
                TempData["ErrorData"] = "المعذرة,المشروع المطلوب غير موجود حاليا , الرجاء المحاولة لاحقا";

                return RedirectToAction("Index", "ProjectOrder");
            }

            var action_found = _db.Action.FirstOrDefault(a => a.Id_projects == Id_Projects);
            if (action_found == null)
            {
                TempData["ErrorData"] = "المعذرة, يجب بدأ إجراءات المشروع من أول خطوة";

                return RedirectToAction("Index", "ProjectOrder");
            }
            else
            {
                if (action_found.Action1_Status == true)
                {
                    return View(action_found);
                }
                action_found.Action1_Status = true;
                _db.Action.Update(action_found);
                await _db.SaveChangesAsync();
                TempData["Action2_Success_Data"] = "تم تأكيد وصول طلب المشروع بنجاح";
                return View(action_found);
            }
                


        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Action2(Actions actions2_Note)
        {
            var project_found = _db.Project.Find(actions2_Note.Id_projects);
            if (project_found == null)
            {
                TempData["ErrorData"] = "المعذرة,المشروع المطلوب غير موجود حاليا , الرجاء المحاولة لاحقا";

                return RedirectToAction("Index", "ProjectOrder");
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "حصل خطأ ما أثناء إضافة الملاحظة الرجاء تعبئة ملاحظة الموافقة المبدئية";
                    return RedirectToAction("Action2", new { Id_Projects = actions2_Note.Id_projects });
                }
                else
                {
                    var action = await _db.Action.FindAsync(actions2_Note.Id_Actions);
                    if (action == null)
                    {
                        TempData["ErrorData"] = "المعذرة, يجب بدأ إجراءات المشروع من أول خطوة";
                        return RedirectToAction("Index", "ProjectOrder");
                    }
                    else
                    {
                        if (action.Action2_Note == null)
                        {
                            action.Action2_Note = actions2_Note.Action2_Note;
                            _db.Action.Update(action);
                            await _db.SaveChangesAsync();
                            TempData["Note_Success"] = "تم إضافة ملاحظة الموافقة المبدئية بنجاح";
                            return RedirectToAction("Action2", new { Id_Projects = actions2_Note.Id_projects });
                        }

                        else if (action.Action2_Note == actions2_Note.Action2_Note)
                        {
                            TempData["Note_Success"] = "لم يتم تغيير الملاحظة";
                            return RedirectToAction("Action2", new { Id_Projects = actions2_Note.Id_projects });
                        }
                        else
                        {
                            action.Action2_Note = actions2_Note.Action2_Note;
                            _db.Action.Update(action);
                            await _db.SaveChangesAsync();
                            TempData["Note_Success"] = "تم تعديل ملاحظة الموافقة المبدئية بنجاح";
                            return RedirectToAction("Action2", new { Id_Projects = actions2_Note.Id_projects });
                        }
                    }
                }
            }
            catch (Exception)
            {
                TempData["ErrorData"] = "المعذرة, حصل خطأ ما الرجاء المحاولة مرة أخرى";
                return RedirectToAction("Index", "ProjectOrder");
            }
        }

        public async Task<IActionResult> Action3(int Id_Projects)
        {
            var project_found = _db.Project.Find(Id_Projects);
            if (project_found == null)
            {
                TempData["ErrorData"] = "المعذرة,المشروع المطلوب غير موجود حاليا , الرجاء المحاولة لاحقا";

                return RedirectToAction("Index", "ProjectOrder");
            }

            var action_found = _db.Action.FirstOrDefault(a => a.Id_projects == Id_Projects);
            if (action_found == null)
            {
                TempData["ErrorData"] = "المعذرة, يجب بدأ إجراءات المشروع من أول خطوة";

                return RedirectToAction("Index", "ProjectOrder");
            }
            else
            {
                if(action_found.Action1_Status == true)
                {
                    if(action_found.Action2_Status == true)
                    {
                        return View(action_found);
                    }
                    action_found.Action2_Status = true;
                    _db.Action.Update(action_found);
                    await _db.SaveChangesAsync();
                    TempData["Action2_Success_Data"] = "تم تأكيد الموافقة المبدئية بنجاح";
                    return View(action_found);
                }
                TempData["ErrorData"] = "المعذرة, يجب الموافقة على وصول طلب مشروع أولا";
                return View("Index",action_found);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Action3(Actions actions3_Note)
        {
            var project_found = _db.Project.Find(actions3_Note.Id_projects);
            if (project_found == null)
            {
                TempData["ErrorData"] = "المعذرة,المشروع المطلوب غير موجود حاليا , الرجاء المحاولة لاحقا";

                return RedirectToAction("Index", "ProjectOrder");
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["Error"] = "حصل خطأ ما أثناء إضافة الملاحظة الرجاء تعبئة ملاحظة استلام ورقة التعهد";
                    return RedirectToAction("Action3", new { Id_Projects = actions3_Note.Id_projects });
                }
                else
                {
                    var action = await _db.Action.FindAsync(actions3_Note.Id_Actions);
                    if (action == null)
                    {
                        TempData["ErrorData"] = "المعذرة, يجب بدأ إجراءات المشروع من أول خطوة";
                        return RedirectToAction("Index", "ProjectOrder");
                    }
                    else
                    {
                        if (action.Action3_Note == null)
                        {
                            action.Action3_Note = actions3_Note.Action3_Note;
                            _db.Action.Update(action);
                            await _db.SaveChangesAsync();
                            TempData["Note_Success"] = "تم إضافة ملاحظة استلام ورقة التعهد بنجاح";
                            return RedirectToAction("Action3", new { Id_Projects = actions3_Note.Id_projects });
                        }

                        else if (action.Action3_Note == actions3_Note.Action3_Note)
                        {
                            TempData["Note_Success"] = "لم يتم تغيير الملاحظة";
                            return RedirectToAction("Action3", new { Id_Projects = actions3_Note.Id_projects });
                        }
                        else
                        {
                            action.Action3_Note = actions3_Note.Action3_Note;
                            _db.Action.Update(action);
                            await _db.SaveChangesAsync();
                            TempData["Note_Success"] = "تم تعديل ملاحظة استلام ورقة التعهد بنجاح";
                            return RedirectToAction("Action3", new { Id_Projects = actions3_Note.Id_projects });
                        }
                    }
                }
            }
            catch (Exception)
            {
                TempData["ErrorData"] = "المعذرة, حصل خطأ ما الرجاء المحاولة مرة أخرى";
                return RedirectToAction("Index", "ProjectOrder");
            }
        }

        public IActionResult paper(int Id_Projects)
        {
            var project_found = _db.Project.Find(Id_Projects);

            if (project_found == null)
            {
                TempData["ErrorData"] = "المعذرة,المشروع المطلوب غير موجود حاليا , الرجاء المحاولة لاحقا";

                return RedirectToAction("Index", "ProjectOrder");
            }

            var action_found = _db.Action.FirstOrDefault(a => a.Id_projects == Id_Projects);

            if (action_found == null)
            {
                TempData["ErrorData"] = "المعذرة, يجب بدأ إجراءات المشروع من أول خطوة";

                return RedirectToAction("Index", "ProjectOrder");
            }

            if(action_found.Action1_Status !=true || action_found.Action2_Status != true)
            {
                TempData["ErrorData"] = "المعذرة, يجب تأكيد وصول طلب المشروع وتأكيد الموافقة المبدئية أولا";
                return RedirectToAction("Index", "ProjectOrder");
            }
            else
            {
                var full_action = _db.Action.Include(e=>e.Project).FirstOrDefault(a => a.Id_projects == Id_Projects);

                var order = _db.Order.FirstOrDefault(o => o.Id_Orders == project_found.Id_Orders);
                TempData["Order_Id"] = order.Num_Order;
                return View(full_action);
            }
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> paper([Bind("Id_Actions,Action3_Paper")] Actions actions)
        {
            try
            {

                var fileName = Request.Form.Files[0].FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\paper\", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    await this.Request.Form.Files[0].CopyToAsync(stream);
                }
                actions.Action3_Paper = "/paper/" + fileName;

                 var action_found = _db.Action.FirstOrDefault(a=>a.Id_Actions == actions.Id_Actions);
                if (action_found == null)
                {
                    TempData["ErrorData"] = "المعذرة, يجب بدأ إجراءات المشروع من أول خطوة";

                    return RedirectToAction("Index", "ProjectOrder");
                }

                if (action_found.Action1_Status != true || action_found.Action2_Status != true)
                {
                    TempData["ErrorData"] = "المعذرة, يجب تأكيد وصول طلب المشروع وتأكيد الموافقة المبدئية أولا";
                    return RedirectToAction("Index", "ProjectOrder");
                }

                else
                {
                    action_found.Action3_Paper =actions.Action3_Paper;
                    _db.Action.Update(action_found);
                    await _db.SaveChangesAsync();
                    TempData["paper_Success_Data"] = "تم إستلام ورقة التعهد بنجاح";
                    return RedirectToAction("Action4",new { id =action_found.Id_Actions });
                    
                }

            }
            catch (Exception )
            {
                TempData["ErrorData"] = "المعذرة, حصل خطأ ما, الرجاء المحاولة لاحقا";
                return RedirectToAction("Index", "ProjectOrder");

            }
        }

        public IActionResult Action4(int id)
        {
            var found = _db.Action.Find(id);
            if (found == null)
            {
                TempData["ErrorData"] = "المعذرة, الإجراء المطلوب غير موجود, الرجاء المحاولة مرة أخرى";

                return RedirectToAction("Index", "ProjectOrder");
            }
            return View(found);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Action4(Actions actions)
        {
            var action_found = await _db.Action.FindAsync(actions.Id_Actions);

            if(action_found == null)
            {
                TempData["ErrorData"] = "المعذرة, يجب بدأ إجراءات المشروع من أول خطوة";

                return RedirectToAction("Index", "ProjectOrder");
            }

            if(action_found.Action1_Status !=true || action_found.Action2_Status !=true || action_found.Action3_Paper == null)
            {
                TempData["ErrorData"] = "المعذرة, يجب تأكيد وصول طلب المشروع وتأكيد الموافقة المبدئية وإرفاق ورقة التعهد أولا";
                return RedirectToAction("Index", "ProjectOrder");
            }

            var project_found = await _db.Project.FindAsync(action_found.Id_projects);

            if (project_found == null)
            {
                TempData["ErrorData"] = "المعذرة,المشروع المطلوب غير موجود حاليا , الرجاء المحاولة لاحقا";

                return RedirectToAction("Index", "ProjectOrder");
            }

            var order_found = await _db.Order.FindAsync(project_found.Id_Orders);

            if (order_found == null)
            {
                TempData["ErrorData"] = "المعذرة,يبدو أن رقم الطلب غير موجود لهذا المشروع, الرجاء المحاولة لاحقا";

                return RedirectToAction("Index", "ProjectOrder");
            }

            if(actions.Accepted_Note != null && actions.Rejected_Note == null)
            {
                action_found.Accepted_Note = actions.Accepted_Note;
                _db.Action.Update(action_found);
                await _db.SaveChangesAsync();

                order_found.States = "1";
                await _db.SaveChangesAsync();
                TempData["successData"] = "تمت عملية إضافة الإجراءات الأولية و الموافقة عليها بنجاح";
                return RedirectToAction("Index", "StartProcess");
            }
            
            else if(actions.Accepted_Note == null && actions.Rejected_Note != null)
            {
                action_found.Rejected_Note = actions.Rejected_Note;
                _db.Action.Update(action_found);
                await _db.SaveChangesAsync();

                order_found.States = "0";
                await _db.SaveChangesAsync();
                TempData["successData"] = "تمت عملية إضافة الإجراءات الأولية بنجاح و تعديل حالة المشروع إلى مرفوض";
                return RedirectToAction("Index", "FinishProject");
            }
            else
            {
                TempData["Error"] = "يجب تعبئة سبب قبول الإجراءات او الرفض فقط , وليس كليهما معا";
                return View();
                
            }

            
            
        }

    }
}
