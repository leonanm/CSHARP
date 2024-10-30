using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ProjetoFinalAPI.Models;
using ProjetoFinalAPI.Data;


namespace ProjetoFinalAPI.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly AppDbContext _context;

        public PublisherRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Publisher> GetAllPublishers() => _context.Publishers.ToList();

        public Publisher GetPublisherById(int id) => _context.Publishers.FirstOrDefault(p => p.Id == id);

        public void AddPublisher(Publisher publisher) => _context.Publishers.Add(publisher);

        public void UpdatePublisher(Publisher publisher) => _context.Publishers.Update(publisher);

        public void DeletePublisher(int id) => _context.Publishers.Remove(new Publisher { Id = id });
    }
}
