using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using myPosTask.Models;
using myPosTask.ViewModels;

namespace myPosTask.Controllers
{
    public class DashboardController : Controller
    {
        private ApplicationDbContext _context;

        public DashboardController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(u => u.Id == userId);
            var viewModel = new DashboardViewModel
            {
                UserTransaction = new UserTransactionViewModel {
                    CurrentUser = user
                },
                SendGift = new SendGiftViewModel {
                    
                }
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult MakeGift( SendGiftViewModel sendGift)
        {
            if ( !ModelState.IsValid)
            {
                //error
                return RedirectToAction("Index");
            }

            var userId = User.Identity.GetUserId();
            var sender = _context.Users.Single(u => u.Id == userId);
            if (sender.Credits < sendGift.Credits)
            {
                //error
                return RedirectToAction("Index");
            }
            sender.Credits -= sendGift.Credits;

            var receiver = _context.Users.Single(u => u.PhoneNumber == sendGift.PhoneNumber);
            receiver.Credits += sendGift.Credits;

            Transaction transaction = new Transaction
            {
                Receiver = receiver,
                Sender = sender,
                Message = sendGift.Message,
                Amount = sendGift.Credits
            };
            _context.Transactions.Add( transaction );

            _context.SaveChanges();
            return RedirectToAction( "Index" );
        }
    }
}