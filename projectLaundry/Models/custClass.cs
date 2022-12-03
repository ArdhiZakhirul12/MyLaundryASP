using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectLaundry.Models
{
    [Table("customer",Schema="public")]
    public class custClass
    {
        [Key]
        public int id_cust { get; set; }
        [Required]
        public string nama_cust { get; set; }
        public string alamat_cust { get; set; }
        public string no_cust { get; set; }

    }
}