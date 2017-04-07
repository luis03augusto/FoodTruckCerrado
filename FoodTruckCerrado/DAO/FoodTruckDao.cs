using FoodTruckCerrado.Azure;
using FoodTruckCerrado.Models;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;

namespace FoodTruckCerrado.DAO
{
    public class FoodTruckDao
    {
        BlobAzure blob;
        public FoodTruckDao()
        {
            blob = new BlobAzure();
        }
        public void SalvarFood(FoodTruck foodTruck, HttpPostedFileBase file)
        {
            using(var contexto = new Contexto()) {
                if (file != null)
                {
                    MembershipUser mu = Membership.GetUser();
                    int propId = Convert.ToInt32(mu.ProviderUserKey.ToString());
                    string nomeFile = Path.GetFileName(file.FileName);
                    Stream imagenStrem = file.InputStream;
                    var result = blob.UploadBlob(nomeFile, imagenStrem);
                    if (result != null)
                    {
                        FoodTruck food = new FoodTruck();
                        food.Id = foodTruck.Id;
                        food.Nome = foodTruck.Nome;
                        food.Descricao = foodTruck.Descricao;
                        food.Categoria = foodTruck.Categoria;
                        food.Cidade = foodTruck.Cidade;
                        food.FotoCapa = result.Uri.ToString();
                        food.ProprietarioId = propId;
                        contexto.FoodTrucks.Add(food);
                        contexto.SaveChanges();
                    }
                }
                
            }
        }

        public IList<FoodTruck> BuscarPorProprietario()
        {
            using (var contexto = new Contexto())
            {
                MembershipUser mu = Membership.GetUser();
                int propId = Convert.ToInt32(mu.ProviderUserKey.ToString());

                return contexto.FoodTrucks.Where(f => f.ProprietarioId == propId).ToList();
            }
        }

        public FoodTruck BuscarPorId(int id)
        {
            using (var contexto = new Contexto())
            {
                return contexto.FoodTrucks.FirstOrDefault(f => f.Id == id);
            }
        }
        public void Remover(FoodTruck foodTruck)
        {
            using (var contexto = new Contexto())
            {
                string BlobNameToDelete = foodTruck.FotoCapa.Split('/').Last();
                blob.DeletaBlob(BlobNameToDelete);
                contexto.FoodTrucks.Remove(foodTruck);
                contexto.SaveChanges();
                
            }
        }
        public IList<FoodTruck> Lista()
        {
            using (var contexto = new Contexto())
            {
                var food = contexto.FoodTrucks.Include(f => f.FotosFood);
                return food.ToList();
            }
        }
        public void Atualizar(FoodTruck foodTruck, HttpPostedFileBase file)
        {
            using(var contexto = new Contexto())
            {
                var original = contexto.FoodTrucks.FirstOrDefault(f => f.Id == foodTruck.Id);

                if (original != null)
                {
                    if (file != null)
                    {
                        string BlobNameToDelete = original.FotoCapa.Split('/').Last();
                        blob.DeletaBlob(BlobNameToDelete);
                        string nomeFile = Path.GetFileName(file.FileName);
                        Stream imagenStrem = file.InputStream;
                        var result = blob.UploadBlob(nomeFile, imagenStrem);
                        if (result != null)
                        {
                            original.Nome = foodTruck.Nome;
                            original.Descricao = foodTruck.Descricao;
                            original.Categoria = foodTruck.Categoria;
                            original.Cidade = foodTruck.Cidade;
                            original.FotoCapa = result.Uri.ToString();
                            contexto.SaveChanges();
                        }
                    }
                    original.Nome = foodTruck.Nome;
                    original.Descricao = foodTruck.Descricao;
                    original.Categoria = foodTruck.Categoria;
                    original.Cidade = foodTruck.Cidade;
                    original.Id = foodTruck.Id;
                    contexto.SaveChanges();
                }   
            }
        }
    }
}