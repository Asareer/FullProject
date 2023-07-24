using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullProject.Models
{
    public class ProductTypes
    {
        [Key]
        public int Id_ProductTypes { get; set; }
        public int Num_Class { get; set; }
        public string Class_Product { get; set; }
        public string Brand { get; set; }
        public string productivity { get; set; }
        public int Num_Register { get; set; }
        public DateTime Date_Product { get; set; }

        public int Id_Processes2 { get; set; }
        [DisplayName("Id_Processes2")]
        [ForeignKey("Id_Processes2")]
        public virtual Processes2? Processes2 { get; set; }
    }
}
