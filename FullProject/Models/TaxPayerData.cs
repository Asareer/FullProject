using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullProject.Models
{
    public class TaxPayerData
    {
        [Key]
        public int Id_TaxPayerData { get; set; }

        /// <summary>
        /// رقم النزول إما الأول أو الثالث
        /// </summary>
        [Required]
        public int Num_Process { get; set; }

        //[Required(ErrorMessage = "الرجاء إختيار الوقت")]
        [DataType(DataType.Time)]
        public DateTime? Time { get; set; }

        //[Required(ErrorMessage = "الرجاء إختيار اليوم")]
        [DataType(DataType.Date)]
        public DateTime? Day { get; set; }

        /// <summary>
        /// تاريخ النزول
        /// </summary>
        //[Required(ErrorMessage = "الرجاء إختيار تاريخ النزول")]
        [DataType(DataType.DateTime)]
        public DateTime? Date_SProcess { get; set; }

        /// <summary>
        ///اسم المكلف
        /// </summary>
        [Required(ErrorMessage = "الرجاء إدخال اسم المكلف")]
        [DataType(DataType.Text)]
        public string? Name_TaxPayers { get; set; }

        /// <summary>
        ///صفة المكلف
        /// </summary>
        [Required(ErrorMessage = "الرجاء إدخال صفة المكلف")]
        [DataType(DataType.Text)]
        public string? Descrip_TaxPayers { get; set; }

        /// <summary>
        ///مكتب المكلف
        /// </summary>
        [Required(ErrorMessage = "الرجاء إدخال اسم مكتب المكلف")]
        [DataType(DataType.Text)]
        public string? Office { get; set; }

        /// <summary>
        /// آي دي بدء العمليات
        /// </summary>
        public int id_SProcess { get; set; }
        [DisplayName("id_SProcess")]
        [ForeignKey("id_SProcess")]
        public virtual StartProcesses? StartProcess { get; set; }

    }
}
