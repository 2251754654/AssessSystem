using Models;
using Repositorys.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositorys
{
    public class RoleRepository
    {
        public RoleRepository()
        {
        }

        public List<ModelRole> GetAllRole()
        {
            DBContext dbContext = new DBContext();
            var query = from role in dbContext.TB_Role
                        select new ModelRole()
                        {
                            RoleID = role.RoleID,
                            RoleName = role.RoleName,
                            RoleDetails = role.RoleDetails,
                        };
            return query.ToList();
        }

        public int UpdateRole(ModelRole roleModel)
        {
            DBContext dbContext = new DBContext();
            var query = dbContext.TB_Role.Where(o => o.RoleID == roleModel.RoleID);
            query.Single().RoleName = roleModel.RoleName;
            query.Single().RoleDetails = roleModel.RoleDetails;
                        
            return dbContext.SaveChanges();
        }

        public int DeleteRole(int []roleArr)
        {
            DBContext dbContext = new DBContext();
            foreach (var id in roleArr)
            {
                var query = dbContext.TB_Role.Find(id);
                dbContext.TB_Role.Remove(query);
            }
            return dbContext.SaveChanges();
        }

        public int InsertRole(ModelRole roleModel)
        {
            DBContext dbContext = new DBContext();
            dbContext.TB_Role.Add(new TB_Role() {
                 RoleName = roleModel.RoleName,
                  RoleDetails = roleModel.RoleDetails,
            });
            return dbContext.SaveChanges();
        }
    }
}