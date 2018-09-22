using Domains;
using Models;
using System;
using System.Web.Mvc;

namespace Views.Controllers
{
    public abstract class AbstractAdminController : Controller
    {
        public readonly IDomainRole domainRole;

        public AbstractAdminController(IDomainRole _domainRole)
        {
            this.domainRole = _domainRole ?? throw new ArgumentNullException(nameof(domainRole));
        }
      
    }
}