using System.Data.Entity;

namespace lulophotos.Models
{
    public class GalleryEntities : DbContext
    {
        public DbSet<Gallery> Galleries {get; set; }
        public DbSet<GalleryItem> GalleryItems { get; set; }
    }
}