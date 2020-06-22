using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myPosTask.ViewModels
{
    public class DashboardViewModel
    {
        public UserTransactionViewModel UserTransaction { get; set; }
        public SendGiftViewModel SendGift { get; set; }
    }
}