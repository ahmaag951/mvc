using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Company_DAL;


namespace Company_BLL
{
    public class EntityDaBase<T> where T : class
    {
        internal CompanyEntities _db = new CompanyEntities();

        public virtual void Add(T entity)
        {
            _db.Set<T>().Add(entity);

        }

        public virtual void Update(T entity)
        {
            var fqen = GetEntityName<T>();

            object originalItem;
            EntityKey key = ((IObjectContextAdapter)_db).ObjectContext.CreateEntityKey(fqen, entity);
            if (((IObjectContextAdapter)_db).ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                ((IObjectContextAdapter)_db).ObjectContext.ApplyCurrentValues(key.EntitySetName, entity);
            }

            //_db.Set<T>().Attach(entity);
            //_db.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            var fqen = GetEntityName<T>();

            object originalItem;
            EntityKey key = ((IObjectContextAdapter)_db).ObjectContext.CreateEntityKey(fqen, entity);
            if (((IObjectContextAdapter)_db).ObjectContext.TryGetObjectByKey(key, out originalItem))
            {
                ((IObjectContextAdapter)_db).ObjectContext.DeleteObject(originalItem);
            }
            //_db.Set<T>().Attach(entity);
            //_db.Entry(entity).State = EntityState.Deleted;
        }

        public int Save()
        {
            return _db.SaveChanges();
        }

        public virtual IEnumerable<T> Items
        {
            get { return _db.Set<T>().AsNoTracking(); }
        }
        public virtual IEnumerable<T> GetAll(List<string> includes)
        {
            return _db.Set<T>().AsNoTracking().WithIncludes(includes);
        }
        public virtual IEnumerable<T> SearchBy(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().AsNoTracking().Where(predicate);
        }

        //public virtual IEnumerable<T>  Find(string filterExpression)
        //{
        //    return _db.Set<T>().AsNoTracking();
        //}
        //public virtual IEnumerable<T> FindRange(string filterExpression, string sortingExpression, int startIndex, int count)
        //{
        //    return _db.Set<T>().AsNoTracking();
        //}
        //public virtual int GetCount(string filterExpression)
        //{
        //    return _db.Set<T>().AsNoTracking().Count();
        //}


        public virtual IEnumerable<T> Find(string filterExpression, List<string> includes)
        {
            if (!String.IsNullOrWhiteSpace(filterExpression))
                return _db.Set<T>().AsNoTracking().WithIncludes(includes).Where(filterExpression);

            else
                return _db.Set<T>().AsNoTracking().WithIncludes(includes);

        }

        public virtual IEnumerable<T> FindRange(string filterExpression, string sortingExpression, int startIndex, int count, List<string> includes)
        {
            if (!String.IsNullOrWhiteSpace(filterExpression))

                return _db.Set<T>().AsNoTracking()
                    .WithIncludes(includes)
                    .Where(filterExpression)
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
            else
                return _db.Set<T>().AsNoTracking()
                    .WithIncludes(includes)
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
        }
        public virtual IEnumerable<T> FindRange(string filterExpression, Expression<Func<T, bool>> predicate, string sortingExpression, int startIndex, int count, List<string> includes)
        {
            if (!String.IsNullOrWhiteSpace(filterExpression) && predicate != null)

                return _db.Set<T>().AsNoTracking()
                    .WithIncludes(includes)
                    .Where(filterExpression).Where(predicate)
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
            else if (!String.IsNullOrWhiteSpace(filterExpression))

                return _db.Set<T>().AsNoTracking()
                    .WithIncludes(includes)
                    .Where(filterExpression)
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
            else if (predicate != null)
                return _db.Set<T>().AsNoTracking()
                    .WithIncludes(includes)
                    .Where(predicate)
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
            else
                return _db.Set<T>().AsNoTracking()
                    .WithIncludes(includes)
                    .OrderBy(sortingExpression)
                    .Skip(startIndex)
                    .Take(count);
        }
        public virtual T GetItemById(string filterExpression, List<string> includes)
        {
            return _db.Set<T>().AsNoTracking().Where(filterExpression)
                .WithIncludes(includes)
                .FirstOrDefault();

        }

        public virtual int GetCount(string filterExpression)
        {
            if (!String.IsNullOrWhiteSpace(filterExpression))
                return _db.Set<T>().AsNoTracking().Where(filterExpression).Count();
            else
                return _db.Set<T>().AsNoTracking().Count();
        }

        public virtual int GetCount(string filterExpression, Expression<Func<T, bool>> predicate)
        {
            if (predicate != null && !String.IsNullOrWhiteSpace(filterExpression))
                return _db.Set<T>().AsNoTracking().Where(filterExpression).Where(predicate).Count();
            else if (!String.IsNullOrWhiteSpace(filterExpression))
                return _db.Set<T>().AsNoTracking().Where(filterExpression).Count();
            else if (predicate != null)
                return _db.Set<T>().AsNoTracking().Where(predicate).Count();
            else
                return _db.Set<T>().AsNoTracking().Count();
        }
        private string GetEntityName<T>() where T : class
        {
            // PluralizationService pluralizer = PluralizationService.CreateService(CultureInfo.GetCultureInfo("en"));
            // return string.Format("{0}.{1}", ((IObjectContextAdapter)DbContext).ObjectContext.DefaultContainerName, pluralizer.Pluralize(typeof(TEntity).Name));

            // Thanks to Kamyar Paykhan -  http://huyrua.wordpress.com/2011/04/13/entity-framework-4-poco-repository-and-specification-pattern-upgraded-to-ef-4-1/#comment-688
            string entitySetName = ((IObjectContextAdapter)_db).ObjectContext
                .MetadataWorkspace
                .GetEntityContainer(((IObjectContextAdapter)_db).ObjectContext.DefaultContainerName, System.Data.Metadata.Edm.DataSpace.CSpace)
                                    .BaseEntitySets.Where(bes => bes.ElementType.Name == typeof(T).Name).First().Name;
            return string.Format("{0}.{1}", ((IObjectContextAdapter)_db).ObjectContext.DefaultContainerName, entitySetName);
        }
    }
}
