using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using lulophotos.Models;

namespace lulophotos.ViewModels
{
    public class GalleryItemViewModel 
    {
        public GalleryItem GalleryItem { get; set; }
        public HttpPostedFileBase File { get; set; }
    }


}