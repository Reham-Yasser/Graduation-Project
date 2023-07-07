using AutoMapper;
using BLL.Interfaces;
using DAL.Entities;
using Edu_Chatbot.DTOS;
using Edu_Chatbot.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Edu_Chatbot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracksController : BaseApiController
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TracksController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet("allData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Tracks>> Get_All_Tracks()
        {
             var track = await _unitOfWork.Repository<Tracks>().GetAllAsync();
            var data = _mapper.Map<IReadOnlyList<Tracks>, IReadOnlyList<TracksDto>>(track);

            return Ok(data);
        }



        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Tracks>> Get_Track_By_Id(int id)
        {
            var Track = await _unitOfWork.Repository<Tracks>().GetByIdAsync(id);
            var data = _mapper.Map<Tracks,TracksDto>(Track);

            if (data == null)
                return NotFound();

            return Ok(data);
        }


        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<Tracks>> AddTrack([FromForm] TracksDto TracksDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //        var track = new Tracks()
        //        {
        //            track_Name = TracksDto.track_Name
        //        };
        //    await _unitOfWork.Repository<Tracks>().Add(track);
        //    var result = await _unitOfWork.Complete();

        //    if (track == null)
        //       return BadRequest(new ApiResponse(400));

        //       return Ok(track);
        //}

        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<TracksDto>> UpdateTrack(int id, [FromForm] TracksDto TracksDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
           
        //   var Track = await _unitOfWork.Repository<Tracks>().GetByIdAsync(id);

        //    if (Track == null)
        //        return BadRequest("Can`t Find This Track");

        //    Track.track_Name = TracksDto.track_Name != null ? TracksDto.track_Name : Track.track_Name;
        //    _unitOfWork.Repository<Tracks>().Update(Track);
        //     await _unitOfWork.Complete();
        //    if (Track == null)
        //        return BadRequest(new ApiResponse(400));
               
        //     return Ok(Track);
           
        //}





        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<Tracks>> DeleteTrack(int id)
        //{
        //    var Track = await _unitOfWork.Repository<Tracks>().GetByIdAsync(id);
        //    if (Track == null)

        //        return BadRequest("Can`t Find This Track");

        //    _unitOfWork.Repository<Tracks>().Delete(Track);
        //    await _unitOfWork.Complete();

        //    if(Track == null)
        //        return BadRequest(new ApiResponse(401));


        //    return Ok(true);

        //}





    }
}
