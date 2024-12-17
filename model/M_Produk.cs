using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBO_PROJECT_B3.model
{
    internal class M_Produk
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string nama_produk { get; set; }
        [Required]
        public int harga_produk{ get; set; }
        [Required]
        public int stok_produk { get; set; }
        [ForeignKey("M_Jenis_produk")]
        public int id_jenis_produk{ get; set; }
        [Required]
        public  DateTime tanggal_datang {  get; set; }
        [Required]
        public string gambar_produk { get; set; }

       
    }
}
