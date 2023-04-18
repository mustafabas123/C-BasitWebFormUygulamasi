using Northwind.Entities.Concerete;
using Nothwind.DataAccess.Abstract;
using Nothwind.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nothwind.DataAccess.Concerete.EntityFramework
{
    public class EFCategoryDAL:EFEntityRepositoryBase<Category,NothwindContext>,ICategoryDAL
    {
    }
}
