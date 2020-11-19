using Data.Entities;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Services
{
	public interface IJobService : IBaseService<Job, int>
	{
		IEnumerable<Job> GetAllJob();

		Job InsertJob(Job _entity);

		Job UpdateJob(Job _entity);

		Job GetById(int id);

		Job SelectById(int id);

		IEnumerable<Job> SelectByName(string name);
	}
	public class JobService : BaseService<Job , int>, IJobService
	{
		public JobService(SWDContext context) : base(context)
		{
		}

		public IEnumerable<Job> GetAllJob()
		{
			return GetAll();
		}

		public Job GetById(int id)
		{
			return GetJobById(id);
		}

		public Job InsertJob(Job _entity)
		{
			return Insert(_entity);
		}

		public Job SelectById(int id)
		{
			return SelectById(id);
		}

		public IEnumerable<Job> SelectByName(string name)
		{
			return SelectJobByName(a => a.Name.Contains(name));
		}

		public Job UpdateJob(Job _entity)
		{
			return Update(_entity);
		}
	}
}
