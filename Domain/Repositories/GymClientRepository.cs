using GymApi.Data;
using GymApi.Domain.Models;
using GymApi.Domain.Repositories.Interfaces;

namespace GymApi.Domain.Repositories
{
    public class GymClientRepository : IGymClientRepository
    {
        private readonly GymContext _context;
        public GymClientRepository(GymContext context)
        {
            _context = context;
        }


        public GymClient Create(GymClient gymClient)
        {
            _context.GymClients.Add(gymClient);
            _context.SaveChanges();
            return gymClient;
        }

        public void Delete(GymClient gymClient)
        {
            _context.GymClients.Remove(gymClient);
            _context.SaveChanges();
        }

        public ICollection<GymClient> FindAll()
        {
            return _context.GymClients.ToList();
        }

        public GymClient? FindById(int id)
        {
            return _context.GymClients.FirstOrDefault(x => x.Id == id);
        }

        public GymClient Update(GymClient gymClient)
        {
            throw new NotImplementedException();
        }
    }
}
