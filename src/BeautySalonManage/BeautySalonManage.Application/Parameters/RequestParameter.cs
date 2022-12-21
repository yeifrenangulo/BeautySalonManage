using BeautySalonManage.Application.Constants;

namespace BeautySalonManage.Application.Parameters
{
    public class RequestParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public RequestParameter()
        {
            PageNumber = ValuesConstant.PAGE_NUMBER_DEFAULT;
            PageSize = ValuesConstant.PAGE_SIZE_DEFAULT;
        }

        public RequestParameter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? ValuesConstant.PAGE_NUMBER_DEFAULT : pageNumber;
            PageSize = pageSize < 1 || pageSize > 10 ? ValuesConstant.PAGE_SIZE_DEFAULT : pageSize;
        }
    }
}
