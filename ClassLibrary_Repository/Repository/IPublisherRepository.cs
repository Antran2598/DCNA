using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookEccommerce_Admin.Models;

namespace ClassLibrary_RepositoryDLL.Repository
{
    public interface IPublisherRepository
    {
        List<Publisher> getAllPublisher();
        Publisher getPublisher(int pubId);

        void AddPublisher(Publisher newpub);
        bool DeletePublisher(int publisherId);
    }
}
