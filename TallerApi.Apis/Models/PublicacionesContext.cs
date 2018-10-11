using Libreria.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TallerApi.Apis.Models
{
    class PublicacionContext : DbContext
    {
        public PublicacionContext() : base("PublicacionConnection") { }
        public DbSet<Publicacion> Publicaciones { get; set; } //aqui estoy creando una tabla en la base de datos con el contexto del modelo
    }
}