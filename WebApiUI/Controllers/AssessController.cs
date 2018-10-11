using Domains.AssessTerritory;
using Infrastructure.Dto;
using Repositorys.DataAccess.UserModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiUI.Models.DbContext;

namespace WebApiUI.Controllers
{
    public class AssessController : ApiController
    {

        private IAssessDomain   assessDomain;

        public AssessController(IAssessDomain  assessDomain )
        {
            this.assessDomain = assessDomain;
        }

        // GET api/values
        public List<AssessDto> Get()
        {
            assessDomain.InitDbContext(DbContextFactory.GetDbContext());
            var result = assessDomain.Get().ToList();
            return result;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
