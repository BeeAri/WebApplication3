using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult Index()
        {
            ChinookContext cnt = new ChinookContext();

            return View(cnt.Artists.ToList());
        }

        public IActionResult AlbumsByArtists(int id)
        {
            ChinookContext cnt = new ChinookContext();
            List<Album> albums = cnt.Albums.Where(x => x.ArtistId == id).ToList();
            return View(albums);
        }
        // HTTP GET VERSION
        public IActionResult Create()
        {
            return View();
        }

        // HTTP POST VERSION  
        [HttpPost]
        public IActionResult Create(Artist artist)
        {
            ChinookContext context = new ChinookContext();
            context.Artists.Add(artist);
            context.SaveChanges();
            return View("Thanks", artist);
        }
        public IActionResult Update(string artname)
        {
            ChinookContext context = new ChinookContext();
            Artist artist = context.Artists.Where(e => e.Name == artname).FirstOrDefault();
            return View(artname);
        }

        [HttpPost]
        public IActionResult Update(Artist artist, string artname)
        {
            ChinookContext context = new ChinookContext();
            Artist a= context.Artists.Where(x => x.Name == artname).FirstOrDefault();    
            a.Name = artist.Name;
            context.SaveChanges();
            return RedirectToAction("Index");  
        }

        // Removed for clarity
        [HttpPost]
        public IActionResult Delete(string artname)
        {
            ChinookContext context = new ChinookContext();
            Artist artist = context.Artists.Where(e => e.Name == artname).FirstOrDefault();
            context.Remove(artist);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
