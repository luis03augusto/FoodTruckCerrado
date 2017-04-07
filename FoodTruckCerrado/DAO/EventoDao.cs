using FoodTruckCerrado.Azure;
using FoodTruckCerrado.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FoodTruckCerrado.DAO
{
    public class EventoDao
    {
        BlobAzure blob;
        public EventoDao()
        {
            blob = new BlobAzure();
        }

        public void Adicionar(Evento evento, HttpPostedFileBase file)
        {
            using(var contexto = new Contexto())
            {
                if (file != null)
                {
                    string nomeFile = Path.GetFileName(file.FileName);
                    Stream imagemStrem = file.InputStream;
                    var result = blob.UploadBlob(nomeFile, imagemStrem);

                    if (result != null)
                    {
                        Evento eventoDao = new Evento();
                        eventoDao.Id = evento.Id;
                        eventoDao.Nome = evento.Nome;
                        eventoDao.Data = evento.Data;
                        eventoDao.Descricao = evento.Descricao;
                        eventoDao.Cidade = evento.Cidade; 
                        eventoDao.FotoCapa = result.Uri.ToString();
                        contexto.Eventos.Add(eventoDao);
                        contexto.SaveChanges();
                    }
                }

            }
        }

        public Evento BuscarPorId(int id)
        {
            using (var contexto = new Contexto())
            {
                return contexto.Eventos.FirstOrDefault(e => e.Id == id);
            }
        }

        public IList<Evento> ListarTodos()
        {
            using(var contexto = new Contexto())
            {
                return contexto.Eventos.OrderBy(e => e.Data).ToList();
            }
        }

        public void Atualizar(Evento evento, HttpPostedFileBase file)
        {
            using (var contexto = new Contexto())
            {
                var original = contexto.Eventos.FirstOrDefault(e => e.Id == evento.Id);

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
                            original.Nome = evento.Nome;
                            original.FotoCapa = result.Uri.ToString();
                            original.Descricao = evento.Descricao;
                            original.Data = evento.Data;
                            original.Cidade = evento.Cidade;
                            contexto.SaveChanges();

                        }
                    }
                }
                original.Nome = evento.Nome;
                original.Descricao = evento.Descricao;
                original.Data = evento.Data;
                original.Cidade = evento.Cidade;
                contexto.SaveChanges();
            }
        }

        public void Deletar(Evento evento)
        {
            using(var contexto = new Contexto())
            {
                string BlobNameToDelete = evento.FotoCapa.Split('/').Last();
                blob.DeletaBlob(BlobNameToDelete);
                contexto.Eventos.Remove(evento);
                contexto.SaveChanges();
            }
        }
    }
}