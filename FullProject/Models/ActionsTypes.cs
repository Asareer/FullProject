using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullProject.Models
{
    public class ActionsTypes
    {
        [Key]
        public int Id_ActionsTypes { get; set; }
        public string? Level { get; set; }
        public string? Actions1 { get; set; }
        public string? Actions2 { get; set; }
        public string? Actions3 { get; set; }

        //[DisplayName("Id_Actions")]
        //[ForeignKey("Id_Actions")]
        //public virtual Actions? Action { get; set; }
        //public int Id_Actions { get; set; }
    }
}
