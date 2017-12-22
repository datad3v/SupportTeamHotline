using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SupportTeamHotline.Models;

namespace SupportTeamHotline.Controllers
{
    public class SupportTicketsController : Controller
    {
        SupportTicketRepository supportTicketRepository = new SupportTicketRepository();

        //
        // HTTP-GET: /SupportTickets/

        public ActionResult Index()
        {
            var supportTickets = supportTicketRepository.FindAllSupportTickets().ToList();
            return View("Index", supportTickets);
        }

        //
        // HTTP-Get: /SupportTickets/Details/2

        public ActionResult Details(int id)
        {
            SupportTicket supportTicket = supportTicketRepository.GetSupportTicket(id);

            if (supportTicket == null)
                return View("NotFound");
            else
                return View("Details", supportTicket);
        }

        //
        // GET: /SupportTickets/Create

        public ActionResult Create()
        {
            
            SupportTicket supportTicket = new SupportTicket()
            {
                
            };

            return View(supportTicket);
        }

        //
        // GET: /SupportTickets/Edit/2

        public ActionResult Edit(int id)
        {
            SupportTicket supportTicket = supportTicketRepository.GetSupportTicket(id);
            return View(supportTicket);
        }

        //
        // POST: /SupportTickets/Create

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create()
        {
            SupportTicket supportTicket = new SupportTicket();

            try
            {
                UpdateModel(supportTicket);

                supportTicketRepository.Add(supportTicket);
                supportTicketRepository.Save();

                return RedirectToAction("Details", new { id = supportTicket.TicketId });
            }
            catch
            {
                //
                return View(supportTicket);
            }
        }

    }
}