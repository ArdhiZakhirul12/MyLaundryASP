using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectLaundry.Models
{
    [Table("admin",Schema="public")]
    public class adminClass
    {
        [Key]
        public int id_admin { get; set; }
        [Required]
        public string nama_admin { get; set; }
        public string alamat_admin { get; set; }
        public string no_telp { get; set; }
        //[Required(ErrorMessage ="Username harus diisi")]
        public string username_admin { get; set; }
        //[Required(ErrorMessage ="Password harus diisi")]
        [DataType(DataType.Password)]
        public string password_admin { get; set; }

        //public string loginErrorMessage { get; set; }
    }
}