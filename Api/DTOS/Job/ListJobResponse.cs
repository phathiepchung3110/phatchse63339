using System.Collections.Generic;

namespace Api.DTOS.Job
{
    public class ListJobResponse
    {
        public IList<JobResponse> listResponse { get; set; }
    }
}