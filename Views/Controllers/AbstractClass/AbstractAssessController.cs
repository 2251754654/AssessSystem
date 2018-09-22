using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public abstract class AbstractAssessController : Controller
    {
        /// <summary>
        /// 自评
        /// </summary>
        public readonly IDomainOneselfAssess domainOneselfAssess;
        /// <summary>
        /// 他评
        /// </summary>
        public readonly IDomainOtherAssess domainOtherAssess;

        public AbstractAssessController(IDomainOneselfAssess domainOneselfAssess, IDomainOtherAssess domainOtherAssess) : this(domainOneselfAssess)
        {
            this.domainOtherAssess = domainOtherAssess ?? throw new ArgumentNullException(nameof(domainOtherAssess));
        }

        public AbstractAssessController(IDomainOneselfAssess domainOneselfAssess)
        {
            this.domainOneselfAssess = domainOneselfAssess ?? throw new ArgumentNullException(nameof(domainOneselfAssess));
        }

        public AbstractAssessController(IDomainOtherAssess domainOtherAssess)
        {
            this.domainOtherAssess = domainOtherAssess ?? throw new ArgumentNullException(nameof(domainOtherAssess));
        }
    }
}