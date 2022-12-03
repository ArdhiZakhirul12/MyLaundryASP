using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectLaundry.Models
{
    [Table("transaksi", Schema = "public")]
    public class transaksiClass
    {
        [Key]
        public int id_transaksi { get; set; }
        [Required]
        public DateTime tgl_transaksi { get; set; }
        public int kuantitas { get; set; }
        [ForeignKey("paketClass")]
        public int paket_id { get; set; }
        public paketClass? paketClass { get; set; }
        [ForeignKey("adminClass")]
        public int admin_id { get; set; }
        public adminClass? adminClass { get; set; }
        [ForeignKey("custClass")]
        public int cust_id { get; set; }
        public custClass? custClass { get; set; }
        public DateTime tgl_diambil { get; set; }   
       

    }
}