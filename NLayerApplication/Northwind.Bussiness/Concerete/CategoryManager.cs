using Northwind.Bussiness.Abstract;
using Northwind.Entities.Concerete;
using Nothwind.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Bussiness.Concerete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }
        public List<Category> GetAll()
        {
            return _categoryDAL.GetAll();
        }
    }
}
