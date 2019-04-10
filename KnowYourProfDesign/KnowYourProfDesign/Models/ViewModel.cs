using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowYourProfDesign.Models
{
    public class ViewModel
    {
        public IEnumerable<Master> MasterVM { get; set; }
        public IEnumerable<Review> ReviewVM { get; set; }
    }
}