using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using myPosTask.Models;
using myPosTask.ViewModels;
using System.Data.Entity;

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
            var transactions = _context.Transactions
                .Include(t => t.Receiver)
                .Include(t => t.Sender)
                .Where( t => t.Receiver.Id == user.Id || t.Sender.Id == user.Id ).ToList();
            var viewModel = new DashboardViewModel
            {
                UserTransaction = new UserTransactionViewModel {
                    CurrentUser = user,
                    UserTransactions = transactions
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
                var error = new ErrorViewModel
                {
                    ErrorMessage = "Not valid fields"
                };
                return View("ErrorPage", error);
            }

            var userId = User.Identity.GetUserId();
            var sender = _context.Users.Single(u => u.Id == userId);
            if (sender.Credits < sendGift.Credits)
            {
                var error = new ErrorViewModel
                {
                    ErrorMessage = "Not enough credits"
                };
                return View("ErrorPage", error);
            }
            sender.Credits -= sendGift.Credits;

            var receiver = _context.Users.SingleOrDefault(u => u.PhoneNumber == sendGift.PhoneNumber);
            if (receiver == null)
            {
                var error = new ErrorViewModel
                {
                    ErrorMessage = "No such user"
                };
                return View("ErrorPage", error);
            }
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

        [Authorize(Roles = "Administrator")]
        public ActionResult AllTransactions()
        {
            var userId = User.Identity.GetUserId();
            var user = _context.Users.Single(u => u.Id == userId);
            var transactions = _context.Transactions
                .Include(t => t.Receiver)
                .Include(t => t.Sender).ToList();
            var viewModel = new DashboardViewModel
            {
                UserTransaction = new UserTransactionViewModel
                {
                    CurrentUser = user,
                    UserTransactions = transactions
                },
                SendGift = new SendGiftViewModel
                {

                }
            };
            return View( "Index",viewModel);
        }
    }
}