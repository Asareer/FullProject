using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullProject.Models
{
    public class GenerlDatas
    {
        [Key]
        public int Id_GeneralDatas { get; set; }
        public string Name_Origin { get; set; }
        public string Owner_Origin { get; set; }
        public string Addrees_Origin { get; set; }
        public int P_B { get; set; }
        public int Telephone { get; set; }
        public int Cellphone { get; set; }
        public string Fax { get; set; }
        public string Telecis { get; set; }
        public string Email { get; set; }
        public int Id_Processes2 { get; set; }
        [DisplayName("Id_Processes2")]
        [ForeignKey("Id_Processes2")]
        public virtual Processes2? Processes2 { get; set; }
    }
}
