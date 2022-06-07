using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEccommerce_Admin.Models;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public class PublisherRepository: IPublisherRepository
    {

        private readonly BookEcommerceContext _context;

        public PublisherRepository()
        {
            _context = new BookEcommerceContext();
        }
        public PublisherRepository(BookEcommerceContext context)
        {
            _context = context;
        }

        public List<Publisher> getAllPublisher()
        {
            List<Publisher> pubs = _context.Publishers.ToList();
            return pubs;
        }

        public Publisher getPublisher(int pubId)
        {
            Publisher publisher = _context.Publishers.Find(pubId);
            return publisher;
        }

        public void AddPublisher(Publisher newpub)
        {
            try
            {
                _context.Publishers.Add(newpub);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        public bool DeletePublisher(int publisherId)
        {
            Publisher publisher = _context.Publishers.Find(publisherId);
            if (publisher != null)
            {
                try
                {
                    _context.Publishers.Remove(publisher);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
            return false;
        }
    }
}
