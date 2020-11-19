using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Service.Services
{
	public interface IBaseService<TEntity, TKey> where TEntity : class
	{
		IEnumerable<TEntity> GetAll();

		public TEntity Insert(TEntity entity);

		public TEntity Update(TEntity entity);

		TEntity GetJobById(TKey id);

		public TEntity SelectJobById(TKey id);

		IEnumerable<TEntity> SelectJobByName(Expression<Func<TEntity, bool>> name);
		void Commit();


	}
	public class BaseService<TEntity, TKey> : IBaseService<TEntity,TKey> where TEntity : class
	{
		SWDContext _context;

		DbSet<TEntity> _dbset;
		public BaseService(SWDContext context)
		{
			_context = context;
			_dbset = _context.Set<TEntity>();
		}
		public IEnumerable<TEntity> GetAll()
		{
			return _dbset;
		}

		public TEntity Insert(TEntity entity)
		{
			_dbset.Add(entity);
			return entity;
		}

		public void Commit()
		{
			_context.SaveChanges();
		}

		public TEntity Update(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			return entity;
		}

		public TEntity GetJobById(TKey id)
		{
			return _dbset.Find(id);
		}

		public TEntity SelectJobById(TKey id)
		{
			var jobSelectedById = GetJobById(id);
			if (id != null)
			{
				return jobSelectedById;
			}
			return null;
		}

		public IEnumerable<TEntity> SelectJobByName(Expression<Func<TEntity, bool>> name)
		{
			var result = _dbset.Where(name);
			return result;
		}
	}
}
