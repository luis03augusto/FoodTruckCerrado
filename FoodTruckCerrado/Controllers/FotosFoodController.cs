using FoodTruckCerrado.Azure;
using FoodTruckCerrado.DAO;
using FoodTruckCerrado.Models;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace FoodTruckCerrado.Controllers
{
    public class FotosFoodController : Controller
    {
        private BlobAzure blob;
        private Contexto contex;
        public FotosFoodController()
        {
            blob = new BlobAzure();
            contex = new Contexto();
        }
        // GET: Fotos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adiciona(int FoodTruckId)
        {
            var fotos = new FotosFood()
            {
                FoodTruckId = FoodTruckId
            };
            ViewBag.fotosFood = fotos;
            return View(fotos);
        }
        [HttpPost]
        public ActionResult Adiciona(int FoodTruckId, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file = file ?? Request.Files["file"];
                    string nomeFile = Path.GetFileName(file.FileName);
                    Stream imagenStrem = file.InputStream;
                    var result = blob.UploadBlob(nomeFile, imagenStrem);
                    if (result != null)
                    {
                        FotosFood foto = new FotosFood();
                        foto.Url = result.Uri.ToString();
                        foto.FoodTruckId = FoodTruckId;
                        contex.FotosFood.Add(foto);
                        contex.SaveChanges();
                        return View();
                    }
                }
                return RedirectToAction("Index");
            }
            return View("Form");
        }
      
    }
}