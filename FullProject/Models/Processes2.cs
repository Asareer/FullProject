using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullProject.Models
{
    public class Processes2 
    {
        [Key]
        public int Id_Processes2 { get; set; }
        //public int Id_Orders { get; set; }
        //[DisplayName("Id_Orders")]
        //[ForeignKey("Id_Orders")]
        //public virtual Orders? Order { get; set; }

        /// <summary>
        /// آدي دي بدء العمليات
        /// </summary>
        public int id_SProcess { get; set; }
        [DisplayName("id_SProcess")]
        [ForeignKey("id_SProcess")]
        public virtual StartProcesses? StartProcess { get; set; }

        // اضافة ربط جدول تفتيش وتقييم المنشأت بجدول المكلفون
        [InverseProperty("Processes2")]
        public virtual ICollection<TaxPayers>? TaxPayer { get; set; }

        // اضافة ربط جدول تفتيش وتقييم المنشأت بجدول البيانات العامة
        [InverseProperty("Processes2")]
        public virtual ICollection<GenerlDatas>? GenerlData { get; set; }

        // اضافة ربط جدول تفتيش وتقييم المنشأت بجدول انواع المنتجات
        [InverseProperty("Processes2")]
        public virtual ICollection<ProductTypes>? ProductType { get; set; }
    }
}
