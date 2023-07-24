using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullProject.Models
{
    public class ProductDatas
    {
        [Key]
        public int Id_ProductDatas { get; set; }
        public int Num_Product { get; set; }
        public string Item_Type { get; set; }
        public string Name_Trande { get; set; }
        public string Name_Company { get; set; }
        public string Country_Origin { get; set; }
        public int Num_Batch { get; set; }
        public string Type_Package { get; set; }
        public DateTime Date_production { get; set; }
        public DateTime Date_Expiration { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }
        public double Size2 { get; set; }
        public int Numper { get; set; }
        public string Quantity { get; set; }
        public string match_Statment { get; set; }
        public string match_Periods { get; set; }
        public int Num_Sample { get; set; }
        public int Num_Report { get; set; }
        public DateTime Date_Report { get; set; }
        public string Result_Report { get; set; }
        // الفحص الظاهري
        public string Taste { get; set; }
        public string Smell { get; set; }
        public string Homogeneity { get; set; }
        public int Id_Processes3 { get; set; }
        [DisplayName("Id_Processes3")]
        [ForeignKey("Id_Processes3")]
        public virtual Processes3? Processes3 { get; set; }
    }
}
