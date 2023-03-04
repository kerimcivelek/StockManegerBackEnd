using Application.Abstract;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Concrete
{
    public class TechnicalServiceRepository : RepositoryBase<TechnicalService>, ITechnicalServiceRepository
    {
        public TechnicalServiceRepository(PbysContext context) : base(context)
        {
        }
    }
}
