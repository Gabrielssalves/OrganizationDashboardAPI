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
    public class SpacesController : ControllerBase
    {
        private readonly ISpaceRepo _repository;
        private readonly IMapper _mapper;

        public SpacesController(ISpaceRepo repository, IMapper mapper)
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

        [HttpGet("users/{userId}")]
        public ActionResult<IEnumerable<SpaceReadDto>> GetSpacesByUser(string userId)
        {
            var SpaceItems = _repository.GetSpacesByUser(userId);
            return Ok(_mapper.Map<IEnumerable<SpaceReadDto>>(SpaceItems));
        }

        //GET api/spaces/{id}
        [HttpGet("{id}", Name = "GetSpaceById")]
        public ActionResult<SpaceReadDto> GetSpaceById(int id)
        {
            var spaceItem = _repository.GetSpaceById(id);

            if (spaceItem != null)
                return Ok(_mapper.Map<SpaceReadDto>(spaceItem));

            return NotFound();
        }

        //POST api/spaces
        [HttpPost]
        public ActionResult<SpaceReadDto> CreateSpace(SpaceCreateDto spaceCreateDto)
        {
            var spaceModel = _mapper.Map<Space>(spaceCreateDto);
            _repository.CreateSpace(spaceModel);
            _repository.SaveChanges();

            var spaceReadDto = _mapper.Map<SpaceReadDto>(spaceModel);

            return CreatedAtRoute(nameof(GetSpaceById), new { Id = spaceReadDto.Id }, spaceReadDto);
        }

        //PUT api/spaces/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSpace(int id, SpaceUpdateDto spaceUpdateDto)
        {
            var spaceModel = _repository.GetSpaceById(id);
            if (spaceModel == null)
            {
                return NotFound();
            }

            _mapper.Map(spaceUpdateDto, spaceModel);

            _repository.UpdateSpace(spaceModel);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/spaces/{id}
        [HttpPatch("id")]
        public ActionResult PartialSpaceUpdate(int id, JsonPatchDocument<SpaceUpdateDto> patchDoc)
        {
            var spaceModel = _repository.GetSpaceById(id);
            if (spaceModel == null)
            {
                return NotFound();
            }

            var spaceToPatch = _mapper.Map<SpaceUpdateDto>(spaceModel);
            patchDoc.ApplyTo(spaceToPatch, ModelState);

            if (!TryValidateModel(spaceToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(spaceToPatch, spaceModel);

            _repository.UpdateSpace(spaceModel);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/spaces/{id}
        [HttpDelete("id")]
        public ActionResult DeleteSpace(int id)
        {
            var spaceModel = _repository.GetSpaceById(id);
            if (spaceModel == null)
            {
                return NotFound();
            }

            _repository.DeleteSpace(spaceModel);
            _repository.SaveChanges();

            return NoContent();
            ;
        }


    }
}
