using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace myPosTask.ViewModels
{
    public class SendGiftViewModel
    {
        [Required]
        public int Credits { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }
    }
}