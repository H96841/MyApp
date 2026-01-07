using Microsoft.AspNetCore.Mvc;
using MyApp.Dto;
using MyApp.Models;
using MyApp.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _giftService;

        public GiftController(IGiftService giftService)
        {
            _giftService = giftService ?? throw new ArgumentNullException(nameof(giftService));
        }

        // GET: api/gift
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetGiftDto>>> GetAll()
        {
            var gifts = await _giftService.GetAllAsync();
            return Ok(gifts);
        }

        //GET: api/gift/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GetGiftDto>> GetById(int id)
        {
            var gift = await _giftService.GetByIdAsync(id);
            if (gift is null) return NotFound();
            return Ok(gift);
        }

        // POST: api/gift
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateGiftDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var res=await _giftService.CreateAsync(dto);

            // Service currently does not return the created resource or id.
            // Return 204 No Content to acknowledge creation; change to CreatedAtAction
            // when the service returns the created resource or id.
            return CreatedAtAction(nameof(GetById), new { id = res.Id }, dto);
        }

        // PUT: api/gift/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateGiftDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (dto.Id != id) return BadRequest("Route id and DTO id must match.");


            try
            {
                await _giftService.UpdateAsync(dto);
                return NoContent();
            }


            catch (ArgumentException ex)
            {
                return BadRequest(new {message=ex.Message});
            }
        }

        // DELETE: api/gift/5
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _giftService.DeleteAsync(id);
            return NoContent();
        }
    }
}
