using System;
using System.Collections.Generic;

#nullable disable

namespace BookEccommerce_Admin.Models
{
    public partial class Book
    {
        public Book()
        {
            Carts = new HashSet<Cart>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Bookname { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int StorageQuantity { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
