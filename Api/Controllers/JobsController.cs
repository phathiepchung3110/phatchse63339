using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Api.DTOS.Job;
using AutoMapper;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
//GOODJOB
namespace Api.Controllers
{
	[Route("api/jobs")]
	[ApiController]
	public class JobsController : ControllerBase
	{
		private readonly IJobService _service;
		private readonly SWDContext _context;
		private readonly IMapper _mapper;

		public JobsController(SWDContext context, IJobService service, IMapper mapper)
		{
			_context = context;
			_service = service;
			_mapper = mapper;
		}
		// GET: api/jobs
		[HttpGet]
		public IActionResult Get()
		{
			var listJobs = _service.GetAllJob();
			IList<JobResponse> listJobResponse = new List<JobResponse>();
			ListJobResponse response = new ListJobResponse();

			if (listJobs != null)
			{
				foreach (var item in listJobs)
				{
					var temp = _mapper.Map<JobResponse>(item);
					listJobResponse.Add(temp);
				}
				response.listResponse = listJobResponse;

				return Ok(response);
			}
			return NoContent();
		}

		//GET api/jobs/name
		[HttpGet("name/{name}")]
		public IActionResult SearchByName(string name)
		{
			var job = _service.SelectByName(name).ToList();
			List<JobResponse> jobResponse = new List<JobResponse>();
			foreach (var item in job)
			{
				var temp = _mapper.Map<JobResponse>(item);
				jobResponse.Add(temp);
			}
			if (job == null)
			{
				return NoContent();
			}
			return Ok(jobResponse);
		}

		// GET: api/jobs/id
		[HttpGet("{inId}")]
		public IActionResult GetJobById(string inId)
		{
			int id = int.Parse(inId);
			var job = _service.SelectJobById(id);
			var jobResponse = _mapper.Map<JobResponse>(job);
			if (job == null)
			{
				return NotFound("Can not find your requested job");
			}
			return Ok(jobResponse);
		}

		// POST: api/jobs
		[HttpPost]
		public IActionResult InsertJob(JobRequest jobRequest)
		{
			var job = _mapper.Map<Job>(jobRequest);
			if (job == null)
			{
				return NoContent();
			}

			_service.InsertJob(job);
			_service.Commit();

			return CreatedAtAction("InsertJob", new { id = job.Id, message = "Created Success" }, job);
		}

		//PUT: api/jobs/id
		[HttpPut("{inId}")]

		public IActionResult UpdateJob(string inId, JobRequest jobRequest)
		{
			int id = int.Parse(inId);
			var job = _mapper.Map<Job>(jobRequest);
			if (id != job.Id)
			{
				return BadRequest();
			}

			_service.UpdateJob(job);

			try
			{
				_service.Commit();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!JobExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return Ok("Update Success");
		}

		private bool JobExists(long id)
		{
			return _context.Job.Any(e => e.Id == id);
		}
	}
}
