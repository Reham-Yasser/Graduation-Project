using BLL.Specification;
using BLL.Specification.CoursesSpec;
using DAL.Entities;

namespace Talabat.BLL.Specifications
{
    public class CoursesSpecificationWithRelatedtable : BaseSpecification<Courses>
    { 
    //{
    //    public CoursesSpecificationWithRelatedtable(CoursesSpecParam coursesSpecParam)
    //        : base(C =>
    //            (string.IsNullOrEmpty(coursesSpecParam.Search) || C.Course_name.ToLower().Contains(coursesSpecParam.Search)))
    //    {

    //        ApplyPagination(coursesSpecParam.PageSize * (coursesSpecParam.PageIndex== 1 ? 1 : coursesSpecParam.PageIndex - 1), coursesSpecParam.PageIndex == 1 ? 0 : coursesSpecParam.PageSize);



    //    }


    //    public CoursesSpecificationWithRelatedtable(int id) : base(C => C.id == id)
    //    {

    //    }

    }
}
