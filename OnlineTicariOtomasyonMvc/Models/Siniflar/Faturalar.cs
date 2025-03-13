using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyonMvc.Models.Siniflar
{
    public class Faturalar
    {

        [Key]
        public int FaturaID { get; set; }
        
        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string FaturaSeriNo { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string FaturaSıraNo { get; set; }
        public DateTime FaturaTarih { get; set; }
        public DateTime FaturaSaat { get; set; }
        
        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string VergiDairesi { get; set; }
       
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimEden { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string TeslimAlan { get; set; }
        public ICollection<FaturaKalem> FaturaKalems { get; set; }

    }
}