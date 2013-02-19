using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lulophotos.Models
{
    public class Gallery
    {
        public int Id { get; set; }
        public UserProfile User { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime TimeStamp { get; set; }
        public List<GalleryItem> GalleryItems { get; set; }

    }
}