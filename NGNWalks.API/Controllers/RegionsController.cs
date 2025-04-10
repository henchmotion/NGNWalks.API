using Microsoft.AspNetCore.Mvc;
using NGNWalks.API.Data;
using NGNWalks.API.Models.Domain;
using NGNWalks.API.Models.DTO.Request;
using NGNWalks.API.Repositories;

namespace NGNWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : Controller
    {
        private readonly NGNWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(NGNWalksDbContext dbContext, IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data from Database - Domain models 

            var regionsDomain = await regionRepository.GetAllAsync();


            // Map Domain Models to DTOs &
            //Return the DTOs to the client
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        //GET REGION BY ID
        //GET:  // GET: https: //localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);

            //Get Region Domain Model From Database
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //Return DTO back to client
            return Ok(mapper.Map<RegionDto>(regionDomain));


        }
        //POST To Create New Region
        //POST:https: //localhost:portnumber/api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map or Covert DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            // Use Domaiin Model to create Region
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
            //await dbContext.Regions.AddAsync(regionDomainModel);
            //await dbContext.SaveChangesAsync();

            // Map Domain moodel back to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);

            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDomainModel);
        }


        //Update Region
        //PUT: https: //localhost:portnumber/api/regions {id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Map DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);


            // Check if Region Exists 
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }


            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

        //Delete Region
        // DELETE: https: //localhost:portnumber/api/regions {id}

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //return deleted Region back
            return Ok(mapper.Map<RegionDto>(regionDomainModel));

        }

    }

}
