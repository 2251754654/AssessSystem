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

        public List<RoleModel> GetAllRole()
        {
            DB_StaffEvaluationEntities dB_StaffEvaluationEntities = new DB_StaffEvaluationEntities();
            var query = from role in dB_StaffEvaluationEntities.TB_Role
                        select new RoleModel()
                        {
                            RoleID = role.RoleID,
                            RoleName = role.RoleName,
                            RoleDetails = role.RoleDetails,
                        };
            return query.ToList();
        }

        public int UpdateRole(RoleModel roleModel)
        {
            DB_StaffEvaluationEntities dB_StaffEvaluationEntities = new DB_StaffEvaluationEntities();
            var query = dB_StaffEvaluationEntities.TB_Role.Where(o => o.RoleID == roleModel.RoleID);
            query.Single().RoleName = roleModel.RoleName;
            query.Single().RoleDetails = roleModel.RoleDetails;
                        
            return dB_StaffEvaluationEntities.SaveChanges();
        }

        public int DeleteRole(int []roleArr)
        {
            DB_StaffEvaluationEntities dB_StaffEvaluationEntities = new DB_StaffEvaluationEntities();
            foreach (var id in roleArr)
            {
                var query = dB_StaffEvaluationEntities.TB_Role.Find(id);
                dB_StaffEvaluationEntities.TB_Role.Remove(query);
            }
            return dB_StaffEvaluationEntities.SaveChanges();
        }

        public int InsertRole(RoleModel roleModel)
        {
            DB_StaffEvaluationEntities dB_StaffEvaluationEntities = new DB_StaffEvaluationEntities();
            dB_StaffEvaluationEntities.TB_Role.Add(new TB_Role() {
                 RoleName = roleModel.RoleName,
                  RoleDetails = roleModel.RoleDetails,
            });
            return dB_StaffEvaluationEntities.SaveChanges();
        }
    }
}