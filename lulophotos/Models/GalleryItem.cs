using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lulophotos.Models
{
    public class GalleryItem
    {
        //Constants
        public static string CONTEXT_ITEM = "img_";

        //Variables
        public int Id { get; set; }
        public String FilePath {get ; set ; }
        public String Title { get; set; }
        public String Description { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool Delete { get; set; }
        
        
    }

}