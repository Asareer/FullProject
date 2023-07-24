using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FullProject.Models
{
    public class StartProcesses
    {
        [Key]
        public int Id_SProcess { get; set; }

        public string Status { get; set; } = "0";
        /// <summary>
        /// آي دي المشروع 
        /// </summary>
        public int Id_projects { get; set; }

        [DisplayName("Id_projects")]
        [ForeignKey("Id_projects")]
        public virtual Projects? Project { get; set; }

        [InverseProperty("StartProcess")]
        public virtual ICollection<TaxPayerData>? taxPayerData { get; set; }

        [InverseProperty("StartProcess")]
        public virtual ICollection<StartActivity>? startActivity { get; set; }

        [InverseProperty("StartProcess")]
        public virtual ICollection<Processes2>? processes2 { get; set; }

    }
}
