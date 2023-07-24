using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FullProject.Models
{
    public partial class ProductDatum
    {
        [Key]
        [Column("Id_ProductDatas")]
        public int IdProductDatas { get; set; }
        [Column("Num_Product")]
        public int NumProduct { get; set; }
        [Column("Item_Type")]
        public string ItemType { get; set; } = null!;
        [Column("Name_Trande")]
        public string NameTrande { get; set; } = null!;
        [Column("Name_Company")]
        public string NameCompany { get; set; } = null!;
        [Column("Country_Origin")]
        public string CountryOrigin { get; set; } = null!;
        [Column("Num_Batch")]
        public int NumBatch { get; set; }
        [Column("Type_Package")]
        public string TypePackage { get; set; } = null!;
        [Column("Date_production")]
        public DateTime DateProduction { get; set; }
        [Column("Date_Expiration")]
        public DateTime DateExpiration { get; set; }
        public double Size { get; set; }
        public double Weight { get; set; }
        public double Size2 { get; set; }
        public int Numper { get; set; }
        public string Quantity { get; set; } = null!;
        [Column("match_Statment")]
        public string MatchStatment { get; set; } = null!;
        [Column("match_Periods")]
        public string MatchPeriods { get; set; } = null!;
        [Column("Num_Sample")]
        public int NumSample { get; set; }
        [Column("Num_Report")]
        public int NumReport { get; set; }
        [Column("Date_Report")]
        public DateTime DateReport { get; set; }
        [Column("Result_Report")]
        public string ResultReport { get; set; } = null!;
    }
}
