using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectLaundry.Models
{
    [Table("paket", Schema = "public")]
    public class paketClass
    {
        [Key]
        public int id_paket { get; set; }
        [Required]
        public string nama_paket { get; set; }
        public string keterangan { get; set; }
        public int harga { get; set; }
    }
}