using Evento.DOMAIN.Core.Entities;
using Evento.DOMAIN.Core.interfaces;
using Evento.DOMAIN.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evento.DOMAIN.Infraestructure.Repositories
{
    public class AttendeesRepository : IAttendeesRepository

    {
        private readonly EventManagementDbContext _dbContext;

        public AttendeesRepository(EventManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Attendees>> GetAttendeeses()
        {
            var data = new EventManagementDbContext();
            return await data.Attendees.ToListAsync();
        }


        public async Task Insert(Attendees attendees)
        {
            await _dbContext.Attendees.AddAsync(attendees);
            await _dbContext.SaveChangesAsync();
        }



        public async Task<bool> Delete(int id)
        {
            var attendees = await _dbContext.Attendees.FindAsync(id);
            if (attendees == null)
            {
                return false;
            }
            _dbContext.Attendees.Remove(attendees);
            int countRows = await _dbContext.SaveChangesAsync();
            return countRows > 0;


        }


    }
}
