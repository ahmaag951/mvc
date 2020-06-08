using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class EntityBase<T> where T : class
    {
        //private UnitOfWork _dataDa = new UnitOfWork();

        internal EntityDaBase<T> _dataDa;
        public EntityBase()
        {
            _dataDa = new EntityDaBase<T>();//;(_unitOfWork);
        }
        //public EntityDaBase DB
        //{
        //    get { return _dataDa; }
        //    set
        //    {
        //        _dataDa = value;
        //    }
        //}

        public virtual int Add(T data)
        {
            _dataDa.Add(data);
            return _dataDa.Save();
        }

        public virtual int Update(T data)
        {
            _dataDa.Update(data);
            return _dataDa.Save();
        }

        public virtual int Delete(T data)
        {
            _dataDa.Delete(data);
            return _dataDa.Save();
        }
        public virtual IEnumerable<T> Items
        {
            get { return _dataDa.Items; }
        }

        public virtual IEnumerable<T> SearchBy(Expression<Func<T, bool>> predicate)
        {
            return _dataDa.SearchBy(predicate);
        }
        public virtual T GetById(long id)
        {
            return GetById(id, new List<string>());

        }
        public virtual T GetById(long id, List<string> Includes)
        {
            return _dataDa.Find(@"Id=" + id.ToString(), Includes).FirstOrDefault<T>();

        }

        public virtual T GetById(string filterExpression, List<string> Includes)
        {
            return _dataDa.GetItemById(filterExpression, Includes);

        }

        public virtual IEnumerable<T> FindRange(string FilterExp, string SortExp, int startindex, int count, List<string> Includes)
        {
            return _dataDa.FindRange(FilterExp, SortExp, startindex, count, Includes);
        }
        public virtual IEnumerable<T> FindRange(string FilterExp, Expression<Func<T, bool>> predicate, string SortExp, int startindex, int count, List<string> Includes)
        {
            return _dataDa.FindRange(FilterExp, predicate, SortExp, startindex, count, Includes);
        }
        //public Dictionary<long, string> Lookup(string FilterExp)
        //{
        //    //Dictionary<long, string> lookup = new Dictionary<long, string>();
        //    //foreach (T t in FindRange(FilterExp, "", 0, 0, null))
        //    //    lookup.Add(t.Id, t.Name);
        //    //return lookup;
        //    //_dataDa.Items.ToLookup<long,string>(d=>d=new()
        //}
        public virtual int GetCount(string filterExpression)
        {
            return _dataDa.GetCount(filterExpression);
        }
        public virtual int GetCount(string filterExpression, Expression<Func<T, bool>> predicate)
        {
            return _dataDa.GetCount(filterExpression, predicate);
        }        //public virtual T GetByKey<KeyT>(KeyT key)
        //{
        //    return _dataDa.SearchBy(n=>n.
        //    _dataDa.Delete(data);
        //    return _dataDa.SaveChanges();
        //}
        //}
        //public virtual IEnumerable<T> GetPage()
        //{
        //    return new Enumerable<T>();
        //}

    }
}
