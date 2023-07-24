using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullProject.Models
{
    public class Processes3 
    {
        [Key]
        public int Id_Processes3 { get; set; }
        public string Result3 { get; set; }
        public string Final_Report { get; set; }

        public int Id_Orders { get; set; }
        [DisplayName("Id_Orders")]
        [ForeignKey("Id_Orders")]
        public virtual Orders? Order { get; set; }

        // اضافة ربط جدول تفتيش وتقييم العينات بجدول بيانات المنتجات
        [InverseProperty("Processes3")]
        public virtual ICollection<ProductDatas>? ProductData { get; set; }
    }
}
;