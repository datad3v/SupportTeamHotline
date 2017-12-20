using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupportTeamHotline.Models
{
    public class SupportTicketRepository
    {
        private SupportTicketDataContext db = new SupportTicketDataContext();

        //
        // Query Methods

        public IQueryable<SupportTicket> FindAllSupportTickets()
        {
            return db.SupportTickets;
        }
        
        public SupportTicket GetSupportTicket(int id)
        {
            return db.SupportTickets.SingleOrDefault(d => d.TicketId == id);
        }

        //
        // Insert/Delete Methods

        public void Add(SupportTicket supportTicket)
        {
            db.SupportTickets.InsertOnSubmit(supportTicket);
        }

        public void Delete(SupportTicket supportTicket)
        {
            db.SupportTickets.DeleteOnSubmit(supportTicket);
        }

        //
        // Persistence

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}