using AutoMapper;
using BLL.Interfaces;
using BLL.Spcefication.CoursesSpec;
using BLL.Specification.CoursesSpec;
using DAL.Entities;
using Edu_Chatbot.DTOS;
using Edu_Chatbot.Errors;
using Edu_Chatbot.Helper;
using Microsoft.AspNetCore.Mvc;
using Talabat.BLL.Specifications;

namespace Edu_Chatbot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : BaseApiController
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CoursesController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet("allData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<CoursesDto>>> Get_All_Courses()
        {
            try
            {
                var course = await _unitOfWork.Repository<Courses>().GetAllAsync();
                var data = _mapper.Map<IReadOnlyList<Courses>, IReadOnlyList<CoursesDto>>(course);

                return Ok(data);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("userCources")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<CoursesDto>>> Get_User_Cources( int TrakId,int LevelId)
        {
            try
            {
                var courses  = await _unitOfWork.Repository<Courses>().GetAllAsync();
                var list = new List<Courses>();

                foreach(var course in courses)
                {
                    if(course.Track_id == TrakId && course.Course_level==LevelId)
                    {
                        list.Add(course);
                        
                    }
                }
                if(list!=null)
                {
                    var data = _mapper.Map<IReadOnlyList<Courses>, IReadOnlyList<CoursesDto>>(list);
                    return Ok(data);
                }

                else
                {
                    return NotFound();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }


        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<CoursesDto>> AddCourse([FromForm] CoursesDto CoursesDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    try
        //    {
        //        var Course = new Courses()
        //        {
        //            Course_name = CoursesDto.Course_name,
        //            Course_type = CoursesDto.Course_type,
        //            Course_link = CoursesDto.Course_link,
        //            Course_level = CoursesDto.Course_level,
        //            Track_id = CoursesDto.Track_id,
        //        };

        //        await _unitOfWork.Repository<Courses>().Add(Course);
        //        var result = await _unitOfWork.Complete();

        //        return Ok(Course);
        //    }
        //    catch (Exception Ex)
        //    {
        //        return BadRequest(Ex.Message);
        //    }
        //}




        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<CoursesDto>> UpdateCourse(int id, [FromForm] CoursesDto coursesDto)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    var Course = await _unitOfWork.Repository<Courses>().GetByIdAsync(id);

        //    if (Course == null)
        //        return BadRequest("Can`t Find This Course");

        //    Course.Course_name = coursesDto.Course_name != null ? coursesDto.Course_name : Course.Course_name;
        //    Course.Course_type = coursesDto.Course_type != null ? coursesDto.Course_type : Course.Course_type;
        //    Course.Course_link = coursesDto.Course_link != null ? coursesDto.Course_link : Course.Course_link;
        //    Course.Course_level = coursesDto.Course_level != null ? coursesDto.Course_level : Course.Course_level;
        //    Course.Track_id = coursesDto.Track_id != null ? coursesDto.Track_id : Course.Track_id;

        //    _unitOfWork.Repository<Courses>().Update(Course);
        //    await _unitOfWork.Complete();

        //    if (Course == null)
        //        return BadRequest(new ApiResponse(400));

        //    return Ok(Course);

        //}



        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<ActionResult<Courses>> DeleteCourse(int id)
        //{
        //    var Course = await _unitOfWork.Repository<Courses>().GetByIdAsync(id);
        //    if (Course == null)

        //        return BadRequest("Can`t Find This Course");

        //    _unitOfWork.Repository<Courses>().Delete(Course);
        //    await _unitOfWork.Complete();

        //    if (Course == null)
        //        return BadRequest(new ApiResponse(401));

        //    return Ok(true);

        //}

    }
}
