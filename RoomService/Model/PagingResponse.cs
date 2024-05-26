namespace RoomService.Model
{
    public class PagingResponse<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPage { get; set; }
        public PagingResponse(List<T> items, int totalCount, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(totalCount / (double)pageSize);
            AddRange(items);
        }

        public static PagingResponse<T> Paging(List<T> DataList, int Skip, int Count)
        {
            var totalCount = DataList.Count();
            var items = DataList.Skip((Skip - 1) * Count).Take(Count).ToList();

            return new PagingResponse<T>(items, totalCount, Skip, Count);
        }
    }
}

