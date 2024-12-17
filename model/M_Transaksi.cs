using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBO_PROJECT_B3.model
{
    internal class M_Transaksi
    {
        [Key]
        public int id { get; set; }
        [Required]


        public DateTime tanggal_transaksi { get; set; }

        [ForeignKey("M_Administrator")]
        public int id_admin { get; set; }
        


    }
}
