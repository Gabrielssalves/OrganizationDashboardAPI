using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceController : ControllerBase
    {
        private readonly ISpaceRepo _repository;
        private readonly IMapper _mapper;

        public SpaceController(ISpaceRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/spaces
        [HttpGet]
        public ActionResult<IEnumerable<SpaceReadDto>> GetAllSpace()
        {
            var SpaceItems = _repository.GetAllSpaces();
            return Ok(_mapper.Map<IEnumerable<SpaceReadDto>>(SpaceItems));
        }

        //GET api/spaces/{id}
        [HttpGet("{id}", Name = "GetSpaceById")]
        public ActionResult<SpaceReadDto> GetSpaceById(int id)
        {
            var commitmentItem = _repository.GetSpaceById(id);

            if (commitmentItem != null)
                return Ok(_mapper.Map<SpaceReadDto>(commitmentItem));

            return NotFound();
        }

        //POST api/spaces
        [HttpPost]
        public ActionResult<SpaceReadDto> CreateSpace(SpaceCreateDto commitmentCreateDto)
        {
            var commitmentModel = _mapper.Map<Space>(commitmentCreateDto);
            _repository.CreateSpace(commitmentModel);
            _repository.SaveChanges();

            var commitmentReadDto = _mapper.Map<SpaceReadDto>(commitmentModel);

            return CreatedAtRoute(nameof(GetSpaceById), new { Id = commitmentReadDto.Id }, commitmentReadDto);
        }

        //PUT api/spaces/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSpace(int id, SpaceUpdateDto commitmentUpdateDto)
        {
            var commitmentModel = _repository.GetSpaceById(id);
            if (commitmentModel == null)
            {
                return NotFound();
            }

            _mapper.Map(commitmentUpdateDto, commitmentModel);

            _repository.UpdateSpace(commitmentModel);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/spaces/{id}
        [HttpPatch("id")]
        public ActionResult PartialSpaceUpdate(int id, JsonPatchDocument<SpaceUpdateDto> patchDoc)
        {
            var commitmentModel = _repository.GetSpaceById(id);
            if (commitmentModel == null)
            {
                return NotFound();
            }

            var commitmentToPatch = _mapper.Map<SpaceUpdateDto>(commitmentModel);
            patchDoc.ApplyTo(commitmentToPatch, ModelState);

            if (!TryValidateModel(commitmentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commitmentToPatch, commitmentModel);

            _repository.UpdateSpace(commitmentModel);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/spaces/{id}
        [HttpDelete("id")]
        public ActionResult DeleteSpace(int id)
        {
            var commitmentModel = _repository.GetSpaceById(id);
            if (commitmentModel == null)
            {
                return NotFound();
            }

            _repository.DeleteSpace(commitmentModel);
            _repository.SaveChanges();

            return NoContent();
            ;
        }


    }
}
