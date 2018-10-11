using Repositorys.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiUI.Models.DbContext
{
    public class DbContextFactory
    {
        public static DBContext GetDbContext()
        {
            var dbContext = HttpContext.Current.Items["dbContext"] as DBContext;
            if (dbContext == null)
            {
                dbContext = new DBContext();
                HttpContext.Current.Items["dbContext"] = dbContext;
            }
            return dbContext;
        }
    }
}