namespace BeautySalonManage.Application.Common.Models;

public class PagedResponse<T> : Response<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int PageTotal { get; set; }
    public int TotalCount { get; set; }

    public PagedResponse(T data, int pageNumber, int pageSize, int count)
    {
        Data = data;
        Errors = null;
        Message = null;
        PageNumber = pageNumber;
        PageSize = pageSize;
        PageTotal = (int)Math.Ceiling(count / (double)pageSize); ;
        TotalCount = count;
        Succeded = true;
    }
}
