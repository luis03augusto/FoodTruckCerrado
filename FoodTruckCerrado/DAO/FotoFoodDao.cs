using FoodTruckCerrado.Azure;
using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.DAO
{
    public class FotoFoodDao
    {
        BlobAzure blob;
        public FotoFoodDao()
        {
            blob = new BlobAzure();
        }

        public void AddFoto(FotosFood foto, HttpPostedFileBase file)
        {
            using (var contexto = new Contexto())
            {
                if (file != null)
                {
                    string nomeFile = Path.GetFileName(file.FileName);
                    Stream imgStream = file.InputStream;
                    var result = blob.UploadBlob(nomeFile, imgStream);
                    if (result != null)
                    {
                        var newFoto = new FotosFood();
                        newFoto.Id = foto.Id;
                        newFoto.Url = result.Uri.ToString();
                        newFoto.FoodTruckId = foto.FoodTruckId;
                        contexto.FotosFood.Add(newFoto);
                        contexto.SaveChanges();
                    }
                }
            }
        }

        public FotosFood BuscarPorID(int Id)
        {
            using (var contexto = new Contexto())
            {
                return contexto.FotosFood.FirstOrDefault(f => f.Id == Id);
            }
        }

        public void Deleta(FotosFood foto)
        {
            using (var contexto = new Contexto())
            {
                string BlobNameToDelete = foto.Url.Split('/').Last();
                blob.DeletaBlob(BlobNameToDelete);
                contexto.FotosFood.Remove(foto);
                contexto.SaveChanges();
            }
        }


        public IList<FotosFood> ListaFotos(int IdFood)
        {
            using (var contexto = new Contexto())
            {
                return contexto.FotosFood.Where(f => f.FoodTruckId == IdFood).ToList();
            }
        }

        public void Remover(FotosFood foto)
        {
            using (var contexto = new Contexto())
            {
                string BlobNameToDelete = foto.Url.Split('/').Last();
                blob.DeletaBlob(BlobNameToDelete);
                contexto.FotosFood.Remove(foto);
                contexto.SaveChanges();

            }
        }

        public int IdUser(int id)
        {
            using (var contexto = new Contexto())
            {
                var query = contexto.FoodTrucks.FirstOrDefault(f => f.Id == id);

                if (query != null)
                {
                    int ID = Convert.ToInt32(query.ProprietarioId);
                    return ID;
                }
                return 0;
            }
        }
    }
}