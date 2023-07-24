using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullProject.Models
{
    public class Actions
    {
        [Key]
        ///<summary>
        ///آي دي الإجراءات (المفتاح الرئيسي لجدول الإجراءات
        ///</summary>
        public int Id_Actions { get; set; }
        //public int Num_Actions { get; set; }


        ///<summary>
        ///    حالة وصول طلب المشروع
        ///    </summary>
        public bool Action1_Status { get; set; } = false;

        /// <summary>
        /// ملاحظة وصول طلب المشروع
        /// </summary>
        public string? Action1_Note { get; set; }

        /// <summary>
        /// حالة الموافقة المبدئية
        /// </summary>
        public bool Action2_Status { get; set; } = false;

        /// <summary>
        /// ملاجظة الموافقة المبدئية
        /// </summary>
        public string? Action2_Note { get; set; }

        /// <summary>
        /// ورقة التعهد . وتكون
        /// قيمتها نل إذا كانت فاضية
        /// </summary>
        public string? Action3_Paper { get; set; }

        /// <summary>
        /// ملاجظة ورقة التعهد
        /// </summary>
        public string? Action3_Note { get; set; }

        /// <summary>
        /// ملاحظة رفض الإجراء نضيفها إذا كانت حالة المشروع مقبول
        /// </summary>
        public string? Rejected_Note { get; set; }

        // <summary>
        /// ملاحظة قبول الإجراء نضيفها إذا كانت حالة المشروع مقبول
        /// </summary>
        public string? Accepted_Note { get; set; }

        /// <summary>
        /// رقم المشروع الذي نطبق عليه الإجراء
        /// </summary>
        public int Id_projects { get; set; }

        [DisplayName("Id_projects")]
        [ForeignKey("Id_projects")]
        public virtual Projects? Project { get; set; }

        //[DisplayName("Id_Orders")]
        //[ForeignKey("Id_Orders")]
        //public virtual Orders? Order { get; set; }
        //public int Id_Orders { get; set; }

        // اضافة ربط جدول الاجراءات بجدول انواع الاجراءات
        //[InverseProperty("Actions")]
        //public virtual ICollection<ActionsTypes>? ActionType { get; set; }
    }
}
