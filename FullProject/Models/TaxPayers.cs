using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullProject.Models
{
    public class TaxPayers
    {
        [Key]
        public int Id_TaxPayers { get; set; }

        /// <summary>
        /// اسم المكلف
        /// </summary>
        [Required(ErrorMessage = "يجب كتابة اسم المكلف")]
        public string? Name_TaxPayers { get; set; }

        /// <summary>
        /// رقم تكليف الهيئة
        /// </summary>
        [Required(ErrorMessage = "يجب كتابة رقم رقم تكليف الهيئة")]
        [DataType(DataType.PhoneNumber)]
        public int Num_TaxPayers { get; set; }

        /// <summary>
        /// التاريخ
        /// </summary>
         [Required(ErrorMessage ="يجب إختيار التاريخ")]
         [DataType(DataType.Date,ErrorMessage ="يجب إختيار التاريخ")]
        public DateTime Date_H { get; set; }

        
        /// <summary>
        /// اليوم
        /// </summary>
        [Required(ErrorMessage = "يجب كتابة اليوم")]
        public string? Day_TaxPayers { get; set; }

        /// <summary>
        /// الموافق
        /// </summary>
        [Required(ErrorMessage = "يجب كتابة التاريخ الموافق بالهجري")]
        public string? Date_M { get; set; }

        /// <summary>
        /// الساعة
        /// </summary>
        [Required(ErrorMessage ="يجب إختيار الساعة")]
        [DataType(DataType.Time,ErrorMessage ="يجب إختيار الساعة")]
        public DateTime Time_TaxPayers { get; set; }

        public int Id_Processes2 { get; set; }
        [DisplayName("Id_Processes2")]
        [ForeignKey("Id_Processes2")]
        public virtual Processes2? Processes2 { get; set; }
    }
}
