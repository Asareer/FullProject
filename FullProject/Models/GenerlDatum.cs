using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FullProject.Models
{
    public partial class GenerlDatum
    {
        [Key]
        [Column("Id_GeneralDatas")]
        public int IdGeneralDatas { get; set; }
        [Column("Name_Origin")]
        public string NameOrigin { get; set; } = null!;
        [Column("Owner_Origin")]
        public string OwnerOrigin { get; set; } = null!;
        [Column("Addrees_Origin")]
        public string AddreesOrigin { get; set; } = null!;
        [Column("P_B")]
        public int PB { get; set; }
        public int Telephone { get; set; }
        public int Cellphone { get; set; }
        public string Fax { get; set; } = null!;
        public string Telecis { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
