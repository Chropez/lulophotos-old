using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using lulophotos.Models;
using lulophotos.ViewModels;

namespace lulophotos.Controllers
{
    public class GalleryController : Controller
    {
        private GalleryEntities db = new GalleryEntities();

        //
        // GET: /Gallery/

        public ActionResult Index()
        {
            return View(db.Galleries.ToList());
        }

        //
        // GET: /Gallery/Details/5

        public ActionResult Details(int id = 0)
        {
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        //
        // GET: /Gallery/Create

        public ActionResult Create()
        {
            GalleryViewModel Gallery = new GalleryViewModel
            {
                GalleryItemViewModels = new List<GalleryItemViewModel>()
                { 
                    new GalleryItemViewModel {
                        GalleryItem = new GalleryItem
                        {
                            Title = "My first Item",
                            Description = "THis is where I made my first Description" 
                        }
                    },
                    new GalleryItemViewModel {
                        GalleryItem = new GalleryItem
                        {
                            Title = "My second Item",
                            Description = "And this is a video" 
                        }
                    }
                }
            };

            return View(Gallery);
        }

        //public ActionResult AddGalleryItem(List<HttpPostedFileBase> Files)
        //{
        //    int amount = Files.Count();
        //    return View();
        //}

        //
        // POST: /Gallery/Create

        //[HttpPost]
        //public ActionResult Create(Gallery gallery)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        gallery.TimeStamp = DateTime.Now; 
        //        db.Galleries.Add(gallery);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(gallery);
        //}

        //
        // GET: /Gallery/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }

        //
        // POST: /Gallery/Edit/5
        [HttpPost]
        public ActionResult Edit(Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gallery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gallery);
        }

        //
        // GET: /Gallery/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Gallery gallery = db.Galleries.Find(id);
            if (gallery == null)
            {
                return HttpNotFound();
            }
            return View(gallery);
        }


        //
        // POST: /Gallery/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery gallery = db.Galleries.Find(id);
            db.Galleries.Remove(gallery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }




        //
        // Route View - Show GalleryId
        public String View(int Gallery)
        {
            return "Gallery/View/" + Gallery.ToString(); 
        }
        
        //
        // New Route Gallery/View/GalleryId/GalleryItemId

        public String View(int Gallery, int Item)
        {
            return "Gallery/View/" + Gallery.ToString() + "/" + Item.ToString(); 
        }

        public ActionResult AddItem(int GalleryId)
        {
            return View();
        }

        public ActionResult AddGalleryItem()
        {
            return PartialView("_AddGalleryItem", new GalleryItemViewModel());
        }

        [HttpPost]
        public ActionResult Create(GalleryViewModel model, List<HttpPostedFileBase> files)
        {
            int amount = files.Count();
            GalleryViewModel t = model;
            
            return View("Create");

        }

        //IEnumerable<HttpPostedFileBase> files
        /*'
         * @using (Html.BeginForm("CreateCL", "Gallery", FormMethod.Post,
        new { @encType = "multipart/form-data" }))*/
        [HttpPost]
        public String Upload(IEnumerable<HttpPostedFileBase> files)
        {

            if (files == null)
                return "FAIL";

           /* foreach (var file in files)
            {
                if (file.ContentLength > 0)
                {
                    GalleryItem galleryItem = new GalleryItem();
                    int lastId = db.GalleryItems.Count() > 0 ? 
                        db.GalleryItems.Max(item => item.Id +1) : 1;
                    string fileName = file.FileName ;
                    string fileExtension = Path.GetExtension(file.FileName) ;

                    string uploadedFileName = GalleryItem.CONTEXT_ITEM + lastId + fileExtension;
                    string path = Path.Combine(Server.MapPath("~/App_Data/uploads"), uploadedFileName);
                    bool FileNameExists = System.IO.File.Exists(path) ;
                    if (FileNameExists)
                    {
                        while(FileNameExists){
                            uploadedFileName = GalleryItem.CONTEXT_ITEM + Guid.NewGuid().ToString() + fileExtension;
                            path = Path.Combine(Server.MapPath("~/App_Data/uploads"), uploadedFileName);
                            FileNameExists = System.IO.File.Exists(path);
                        }

                    }
                        
                    file.SaveAs(path);

                }
            }*/
            return "Uploaded";
        }

    }
}