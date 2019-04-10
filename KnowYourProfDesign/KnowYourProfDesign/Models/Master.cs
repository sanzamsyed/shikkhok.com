using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnowYourProfDesign.Models
{
    public class Master
    {
        [Key]
        public int MID { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Department { get; set; }
        public string Course { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}