using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBO_PROJECT_B3.model
{
    internal class M_Detail_transaksi
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int jumlah_produk { get; set; }
        [Required]
        public int sub_total { get; set; }
        [ForeignKey("M_Produk")]
        public int id_produk { get; set; }
        [ForeignKey("M_Transaksi")]
        public int id_transaksi { get; set; }

    }
}
