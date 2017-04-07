using FoodTruckCerrado.Azure;
using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.DAO
{
    public class PratoDao
    {
        BlobAzure blob;
        public PratoDao()
        {
            blob = new BlobAzure();
        }

        public void Adciona(Prato prato, HttpPostedFileBase file)
        {
            using (var contex = new Contexto())
            {
                if (file != null)
                {
                    string nomeFilem = Path.GetFileName(file.FileName);
                    Stream imgStrem = file.InputStream;
                    var resul = blob.UploadBlob(nomeFilem, imgStrem);
                    if (resul != null)
                    {
                        Prato pratoBlob = new Prato();
                        pratoBlob.Id = prato.Id;
                        pratoBlob.Nome = prato.Nome;
                        pratoBlob.Descricao = prato.Descricao;
                        pratoBlob.Preco = prato.Preco;
                        pratoBlob.FoodTruckId = prato.FoodTruckId;
                        pratoBlob.FotoPrato = resul.Uri.ToString();
                        contex.Pratos.Add(pratoBlob);
                        contex.SaveChanges();
                    }
                } 
            }
        }

        public Prato BuscaProId(int id)
        {
            using (var context = new Contexto()) { 
            return context.Pratos.FirstOrDefault(p => p.Id == id);
            }
        }

        public IList<Prato> BuscaProFood(int id)
        {
            using (var context = new Contexto())
            {
                return context.Pratos.Where(p => p.FoodTruckId == id).ToList();
            }
        }

        public void Deletar(Prato prato)
        {
            using (var context = new Contexto()) {
            string BlobNameToDelete = prato.FotoPrato.Split('/').Last();
            blob.DeletaBlob(BlobNameToDelete);
            context.Pratos.Remove(prato);
            context.SaveChanges();
            }
        }

        public void Atualizar(Prato prato, HttpPostedFileBase file)
        {
            using (var context = new Contexto())
            {
                var original = context.Pratos.FirstOrDefault(p => p.Id == prato.Id);

                if (original != null)
                {
                    if (file != null)
                    {
                        string BlobNameToDelete = original.FotoPrato.Split('/').Last();
                        blob.DeletaBlob(BlobNameToDelete);
                        string nomeFile = Path.GetFileName(file.FileName);
                        Stream imagenStrem = file.InputStream;
                        var result = blob.UploadBlob(nomeFile, imagenStrem);
                        if (result != null)
                        {
                            original.Nome = prato.Nome;
                            original.Descricao = prato.Descricao;
                            original.Preco = prato.Preco;
                            original.FotoPrato = result.Uri.ToString();
                            context.SaveChanges();
                        }                        
                    }
                    original.Nome = prato.Nome;
                    original.Descricao = prato.Descricao;
                    original.Preco = prato.Preco;
                    context.SaveChanges();
                }
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