using Prova.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Prova.Context
{
    public class Contexto : DbContext
    {
        public Contexto() : base("DBCliente")
        {
        }

        public DbSet<ClienteModel> Cliente { get; set; }
    }
}