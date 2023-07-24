using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FullProject.Models
{
    public class StartActivity
    {
        [Key]
        public int Id_StartActivity { get; set; }

        //[Required(ErrorMessage ="الرجاء إدخال الغرض")]
        /// <summary>
        /// الغرض
        /// </summary>
        public string? Purpose { get; set; }

        //[Required(ErrorMessage = "الرجاء إدخال الوصف")]
        /// <summary>
        /// الوصف
        /// </summary>
        public string? Description { get; set; }

        //[Required(ErrorMessage = "الرجاء إدخال النتيجة")]
        /// <summary>
        /// النتيجة
        /// </summary>
        public string? Result { get; set; }


        ///<summary>
        /// تأكيد إكمال بدء النشاط
        /// </summary>
        
        public string? Confirm { get; set; }

        /// <summary>
        /// آي دي بدء العمليات
        /// </summary>
        public int id_SProcess { get; set; }
        [DisplayName("id_SProcess")]
        [ForeignKey("id_SProcess")]

        
        
        public virtual StartProcesses? StartProcess { get; set; }

        //public int Id_Orders { get; set; }

        //[DisplayName("Id_Orders")]
        //[ForeignKey("Id_Orders")]
        //public virtual Orders? Order { get; set; }

    }
}
