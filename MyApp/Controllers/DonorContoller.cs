using Microsoft.AspNetCore.Mvc;
using MyApp.Dto;
using MyApp.Service;

namespace MyApp.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DonorContoller : ControllerBase
    {
        private readonly IDonorService _Donorservice;
        public DonorContoller(IDonorService donorservice)
        {
            _Donorservice = donorservice ?? throw new ArgumentNullException(nameof(donorservice));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDonorDto>>> GetAll()
        {
            var donors = await _Donorservice.GetAllAsync();
            return Ok(donors);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetDonorDto>> GetById(int id)
        {
            var donor = await _Donorservice.GetByIdAsync(id);
            if (donor is null) return NotFound();
            return Ok(donor);
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateDonorDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
           var res= await _Donorservice.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = res.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateDonorDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != dto.Id) return BadRequest("ID mismatch between URL and body.");

            try
            {
                await _Donorservice.UpdateAsync(dto);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _Donorservice.DeleteAsync(id);
            return NoContent();
        }
        
    }

}
