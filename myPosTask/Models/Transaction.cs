using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace myPosTask.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Sender { get; set; }

        [Required]
        public ApplicationUser Receiver { get; set; }

        [StringLength(200, ErrorMessage = "The message is too long")]
        public string Message { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter value bigger than 0")]
        public int Amount { get; set; }

        public Transaction()
        {
            Message = "Empty";
        }
    }
}