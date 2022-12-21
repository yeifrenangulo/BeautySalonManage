namespace BeautySalonManage.Application.Wrappers
{
    public class PagedResponse<T> : Response<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            Data = data;
            Errors = null;
            Message = null;
            PageNumber = pageNumber;
            PageSize = pageSize;
            Succeded = true;
        }
    }
}
