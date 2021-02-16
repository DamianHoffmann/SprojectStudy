using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class EfRepository
    {
        protected readonly IApplicationDbContext Context;


        public EfRepository(IApplicationDbContext context)
        {
            Context = context;
        
        }
    }
}

   

