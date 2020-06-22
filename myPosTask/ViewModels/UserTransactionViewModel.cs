using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myPosTask.Models;

namespace myPosTask.ViewModels
{
    public class UserTransactionViewModel
    {
        public ApplicationUser CurrentUser { get; set; }
        public IEnumerable<Transaction> UserTransactions { get; set; }
    }
}