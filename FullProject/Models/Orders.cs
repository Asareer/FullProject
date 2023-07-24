using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FullProject.Models
{
    public class Orders
    {
        [Key]
        
        public int Id_Orders { get; set; }
        [Required(ErrorMessage = "يجب ادخال رقم الطلب")]
        public int Num_Order { get; set; }
        public int Num_Process { get; set; }
        public string? States { get; set; } = "قيد الإعداد";
        public string? Reason { get; set; }  
        public string? Notes { get; set; } 
        public string? Paper_Pledge { get; set; }    
      
        // اضافة ربط جدول الطلبات بجدول المشاريع
        [InverseProperty("Order")]
        public virtual ICollection<Projects>? Projects { get; set; }

        // اضافة ربط جدول الطلبات بجدول بدءالنشاط
        //[InverseProperty("Order")]
        //public virtual ICollection<StartActivity>? StartActivity { get; set; }

        // اضافة ربط جدول الطلبات بجدول تفتيش وتقييم المنشات
        //[InverseProperty("Order")]
        //public virtual ICollection<Processes2>? Process2 { get; set; }

        //// اضافة ربط جدول الطلبات بجدول المشاريع
        //[InverseProperty("Order")]
        //public virtual ICollection<Processes3>? Process3 { get; set; }

        //[NotMapped]
        //public IFormFile ClientFile { get; set; }






    }
}
