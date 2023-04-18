using Ninject.Modules;
using Northwind.Bussiness.Abstract;
using Northwind.Bussiness.Concerete;
using Nothwind.DataAccess.Abstract;
using Nothwind.DataAccess.Concerete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bussiness.DependencyReselvors.Ninject
{
    public class BussinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductManager>();
            Bind<IProductDAL>().To<EFProductDAL>();

            Bind<ICategoryService>().To<CategoryManager>();
            Bind<ICategoryDAL>().To<EFCategoryDAL>();


        }
    }
}
