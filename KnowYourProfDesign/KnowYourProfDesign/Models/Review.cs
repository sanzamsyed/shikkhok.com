using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowYourProfDesign.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public int UserID { get; set; }
        public int TeacherID { get; set; }

        public string Username { get; set; }
        public string TeacherName { get; set; }

        public DateTime ReviewDate { get; set; }

        public string ReviewText { get; set; }
    }
}