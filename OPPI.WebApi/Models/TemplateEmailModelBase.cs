using OPPI.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OPPI.WebApi.Models
{
    public abstract class TemplateEmailModelBase : ITemplateEmail
    {
        public string Id => this.GetType().Name;
    }
}
