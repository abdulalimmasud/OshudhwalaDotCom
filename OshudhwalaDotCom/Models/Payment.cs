using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OshudhwalaDotCom.Models
{
    public class Payment
    {
        public int UserId { get; set; }
        [DisplayName("Transition No")]
        [Required(ErrorMessage ="Please Enter your payment transition no")]
        public string  TransitionId { get; set; }
    }
}