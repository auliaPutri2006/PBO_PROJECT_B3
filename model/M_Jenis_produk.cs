using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBO_PROJECT_B3.model
{
    internal class M_Jenis_produk
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nama_jenis_produk { get; set; }
    }
}
