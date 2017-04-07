using FoodTruckCerrado.Azure;
using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.DAO
{
    public class FotoEventoDao
    {
        BlobAzure blob;

        public FotoEventoDao()
        {
            blob = new BlobAzure();
        }

        public void AddFoto(FotosEventos foto, HttpPostedFileBase file)
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
                        var newFoto = new FotosEventos();
                        newFoto.Id = foto.Id;
                        newFoto.Url = result.Uri.ToString();
                        newFoto.EventoId = foto.EventoId;
                        contexto.FotosEvento.Add(newFoto);
                        contexto.SaveChanges();
                    }
                }
            }
        }
        public IList<FotosEventos> Listar(int idEvento)
        {
            using (var contexto = new Contexto())
            {
                return contexto.FotosEvento.Where(f => f.EventoId == idEvento).ToList();
            }
        }

        public FotosEventos BuscarPorId(int idFoto)
        {
            using (var contexto = new Contexto())
            {
                return contexto.FotosEvento.FirstOrDefault(f => f.Id == idFoto);
            }
        }
        public void Deleta(FotosEventos foto)
        {
            using (var contexto = new Contexto())
            {
                string BlobNameToDelete = foto.Url.Split('/').Last();
                blob.DeletaBlob(BlobNameToDelete);
                contexto.FotosEvento.Remove(foto);
                contexto.SaveChanges();
            }
        }
    }

}