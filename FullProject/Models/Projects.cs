using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullProject.Models
{
    public class Projects
    {
        [Key]
        public int Id_Projects { get; set; }

        [Required(ErrorMessage ="يجب ادخال اسم المشروع")]
        public string Name_Project { get; set; }
        [Required(ErrorMessage = "يجب ادخال تاريخ تسجيل المشروع")]
        public DateTime Date_Project { get; set; }
        [Required(ErrorMessage = "يجب ادخال نوع المشروع")]
        public string Type_Project { get; set; }
        [Required(ErrorMessage = "يجب ادخال موقع المشروع")]
        public string Locate_Project { get; set; }
        [Required(ErrorMessage = "يجب ادخال مساحة المشروع")]
        public string area_Project { get; set; }
        [Required(ErrorMessage = "يجب ادخال نوع ملكية المشروع")]
        public string  Property_Project { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم مالك المشروع")]
        public string Owner_Project { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم المفوض بالمعاملة")]
        public string Owner2_Project { get; set; }
        [Required(ErrorMessage = "يجب ادخال رقم الهاتف ")]
        public string  Num_Phone { get; set; }
        [Required(ErrorMessage = "يجب ادخال رقم الطلب ")]
        public int Id_Orders { get; set; }

        [DisplayName("Id_Orders")]
         [ForeignKey("Id_Orders")]
         public virtual Orders? Order { get; set; }


        [InverseProperty("Project")]
        public virtual ICollection<Actions>? Action { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<StartProcesses>? StartProcesses  { get; set; }



    }
}
