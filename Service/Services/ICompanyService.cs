using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
	public interface ICompanyService : IBaseService<Company, int>
	{
		IEnumerable<Company> GetAllCompany();

		Company InsertCompany(Company _entity);

		Company UpdateCompany(Company _entity);

		Company GetCompanyById(int id);

		Company SelectCompanyById(int id);

		IEnumerable<Company> SelectCompanyByName(string name);

		public class CompanyService : BaseService<Company, int>, ICompanyService
		{
			public CompanyService(SWDContext context) : base(context)
			{
			}

			public IEnumerable<Company> GetAllCompany()
			{
				return GetAll();
			}

			public Company GetCompanyById(int id)
			{
				return GetCompanyById(id);
			}

			public Company InsertCompany(Company _entity)
			{
				return Insert(_entity);
			}

			public Company SelectCompanyById(int id)
			{
				return SelectCompanyById(id);
			}

			public IEnumerable<Company> SelectCompanyByName(string name)
			{
				throw new NotImplementedException();
			}

			public Company UpdateCompany(Company _entity)
			{
				throw new NotImplementedException();
			}
		}
	}
}
