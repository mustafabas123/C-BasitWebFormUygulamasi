using Northwind.Entities.Abstract;
using Northwind.Entities.Concerete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nothwind.DataAccess.Abstract
{
    public interface IRepositoryDAL<T> where T : class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //Bir filtre uyguladık bir filtre gelmezse filteryi null al 
        T GetById(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
