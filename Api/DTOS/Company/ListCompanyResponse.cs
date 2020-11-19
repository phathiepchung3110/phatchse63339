using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOS.Company
{
	public class ListCompanyResponse
	{
		public IList<CompanyResponse> listResponse { get; set; }
	}
}
