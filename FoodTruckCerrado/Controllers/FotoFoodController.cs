using FoodTruckCerrado.Azure;
using FoodTruckCerrado.DAO;
using FoodTruckCerrado.Models;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace FoodTruckCerrado.Controllers
{
    public class FotoFoodController : Controller
    {
        FotoFoodDao dao;

        public FotoFoodController()
        {
            dao = new FotoFoodDao();
        }
        public ActionResult Index(int idFood)
        {
            var fotos = dao.ListaFotos(idFood);
            var Id = dao.IdUser(idFood);
            ViewBag.Id = Id;
            if (fotos.Count == 0)
            {
                return RedirectToAction("SemFotos", new { id = idFood, idUser = Id });
            }
            else
            {
                ViewBag.Foto = fotos;
                return View(fotos);
            }
            
        }
        public ActionResult SemFotos(int id, int idUser)
        {
            ViewBag.Id = idUser;
            var fotos = new FotosFood
            {
                FoodTruckId = id
            };
            return View(fotos);
        }
        public ActionResult Form(int idFood)
        {
            var fotos = new FotosFood
            {
                FoodTruckId = idFood
            };
            ViewBag.Foto = fotos; 
            return View(fotos);
        }

        [HttpPost]
        public ActionResult Form(FotosFood foto, HttpPostedFileBase file)
        {
            if (file != null)
            {
                dao.AddFoto(foto, file);
                return RedirectToAction("Index", new { idFood = foto.FoodTruckId} );
            }
            else
            {
                return RedirectToAction("Index", new { idFood = foto.FoodTruckId });
            }
        }

        public ActionResult Deleta(int idFoto)
        {
            var foto = dao.BuscarPorID(idFoto);
            dao.Deleta(foto);
            return RedirectToAction("Index", new { idFood = foto.FoodTruckId });
        }
    }   
}