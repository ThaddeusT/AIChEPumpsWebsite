using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using PumpsProjectWebsite.Models;

namespace PumpsProjectWebsite.Repository
{
    /// <summary>
    /// Base repository for all repositories
    /// </summary>
    public class BaseRepository
    {
        protected Entities context;
        protected IPrincipal user;

        public BaseRepository(IPrincipal user)
        {
            this.context = new Entities();
            this.user = user;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }


    }
}