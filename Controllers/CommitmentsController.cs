using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrganizationDashboardAPI.Data;
using OrganizationDashboardAPI.Dtos;
using OrganizationDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizationDashboardAPI.Controllers
{
    //api/commitments
    [Route("api/[controller]")]
    [ApiController]
    public class CommitmentsController : ControllerBase
    {
        private readonly ICommitmentRepo _repository;
        private readonly IMapper _mapper;
        public CommitmentsController(ICommitmentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //private readonly MockCommitmentRepo _repository = new MockCommitmentRepo();
        //GET api/commitments
        [HttpGet]
        public ActionResult<IEnumerable<CommitmentReadDto>> GetAllCommitment()
        {
            var commitmentItems = _repository.GetAllCommitments();
            return Ok(_mapper.Map<IEnumerable<CommitmentReadDto>>(commitmentItems));
        }

        //GET api/commitments/{id}
        [HttpGet("{id}", Name = "GetCommitmentById")]
        public ActionResult<CommitmentReadDto> GetCommitmentById(int id)
        {
            var commitmentItem = _repository.GetCommitmentById(id);

            if (commitmentItem != null)
                return Ok(_mapper.Map<CommitmentReadDto>(commitmentItem));

            return NotFound();
        }

        //POST api/commitments
        [HttpPost]
        public ActionResult<CommitmentReadDto> CreateCommitment(CommitmentCreateDto commitmentCreateDto)
        {
            var commitmentModel = _mapper.Map<Commitment>(commitmentCreateDto);
            _repository.CreateCommitment(commitmentModel);
            _repository.SaveChanges();

            var commitmentReadDto = _mapper.Map<CommitmentReadDto>(commitmentModel);

            return CreatedAtRoute(nameof(GetCommitmentById), new { Id = commitmentReadDto.Id }, commitmentReadDto);
        }

        //PUT api/commitments/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommitment(int id, CommitmentUpdateDto commitmentUpdateDto)
        {
            var commitmentModel = _repository.GetCommitmentById(id);
            if (commitmentModel == null)
            {
                return NotFound();
            }

            _mapper.Map(commitmentUpdateDto, commitmentModel);

            _repository.UpdateCommitment(commitmentModel);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
