using System;
using API.Dtos;

namespace API.Helpers
{
    public class Pagination<T> where T : class
    {
        public int PageIndex{get; set;}
        public int PageSize { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<ProductToReturnDto> Data {get; set;}

        public Pagination(int pageIndex, int pageSize, int count, IReadOnlyList<ProductToReturnDto> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Data = data;
            Count = count;
        }
    }
}