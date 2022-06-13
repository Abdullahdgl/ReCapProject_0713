﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAcces.Abstract
{
	public interface IEntityRepository<T> where T: class , IEntity , new()
	{
		List<T> GetAll(Expression<Func<T, bool>> filter = null); // bir listelemenin hepsini getirebilir. tümünü getir
		T Get(Expression<Func<T, bool>> filter);

		void Add(T entity);
		void Delete(T entity);
		void Update(T entity);

	
	}
}
