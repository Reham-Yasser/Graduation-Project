
namespace BLL.Specification.CoursesSpec
{
   public class CoursesSpecParam
    {

        private const int PageMaxSize = 15;

        public int PageIndex { get; set; } = 1;

        private int pageSize = 10;   

        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value > PageMaxSize ? PageMaxSize : value; }
        }

       
        private int search ;

        public int Search 
        {
            get { return search; }
            set { search = value; }
        }

    }
}
