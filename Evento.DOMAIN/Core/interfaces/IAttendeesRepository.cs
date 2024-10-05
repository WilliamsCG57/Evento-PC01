using Evento.DOMAIN.Core.Entities;

namespace Evento.DOMAIN.Core.interfaces
{
    public interface IAttendeesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Attendees>> GetAttendeeses();
        Task Insert(Attendees attendees);
    }
}