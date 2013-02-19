using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using lulophotos.Models;
using lulophotos.ViewModels;

namespace lulophotos.ViewModels
{
    public class GalleryViewModel
    {
        public Gallery Gallery { get; set; }
        public IEnumerable<GalleryItemViewModel> GalleryItemViewModels { get; set; }
        


    }
}