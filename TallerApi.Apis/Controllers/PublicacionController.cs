using Libreria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TallerApi;
using TallerApi.Apis.Models;

namespace TallerApi.Apis.Controllers
{
    public class PublicacionController : ApiController
    {
        public IEnumerable<Publicacion> Get() {
            using (var context = new PublicacionContext() ) {
                return context.Publicaciones.ToList();
            }
        }

        [HttpGet] //lo usamos para buscar
        public Publicacion Get(int id) 
        {
            using (var context = new PublicacionContext())
            {
                
                return context.Publicaciones.FirstOrDefault(x => x.id == id);//ese elemento publicaciones es la tabla de la base de datos asignada en publcacionescontext
            }
        }

        //usando la base de datos buscar un producto por id
        [HttpPost] //lo utilizamos para insertar
        public Publicacion Post(Publicacion publicacion) 
        {
            using (var context = new PublicacionContext())
            {
                context.Publicaciones.Add(publicacion);
                context.SaveChanges(); //hacer el cambio en la base de datos
                return publicacion;
            }
        }
        [HttpPut] //lo utilizamos para actualizar
        public Publicacion Put(Publicacion publicacion)  
        {
            using (var context = new PublicacionContext())
            {
                var publicacionactualizar = context.Publicaciones.FirstOrDefault(x => x.id == publicacion.id);
                publicacionactualizar.Usuario = publicacion.Usuario;
                publicacionactualizar.MeGusta = publicacion.MeGusta;
                publicacionactualizar.MeDisgusta = publicacion.MeDisgusta;
                publicacionactualizar.FechaPublicacion = publicacion.FechaPublicacion;
                publicacionactualizar.EsPrivado = publicacion.EsPrivado;
                publicacionactualizar.VecesCompartido = publicacion.VecesCompartido;
                context.SaveChanges(); 
                return publicacionactualizar;
            }
        }

        [HttpDelete] //lo utilizamos para eliminar
        public bool Delete(int id) 
        {
            using (var context = new PublicacionContext())
            {
                var publiacioneliminar = context.Publicaciones.FirstOrDefault(x => x.id == id);
                context.Publicaciones.Remove(publiacioneliminar);
                context.SaveChanges();
                return true;
            }
        }
    }


}