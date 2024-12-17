using Npgsql;
using NpgsqlTypes;
using PBO_PROJECT_B3.core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PBO_PROJECT_B3.model
{
    internal class M_Administrator
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string username_admin { get; set; }
        [Required]
        public string pass_admin { get; set; }

        [ForeignKey("M_Status")]
        public int status_id { get; set; }

        //constructor
        //public M_Administrator(int Id, string username_Admin, string pass_Admin, int status_Id)
        //{
        //    id = Id;
        //    username_admin = username_Admin;
        //    pass_admin = pass_Admin;
        //    status_id = status_Id;
        //}

        //// Overriding ToString for ComboBox binding
        //public override string ToString()
        //{
        //    return username_admin;
        //}

    }
   

}
