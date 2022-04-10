using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirStar.Infrastructure.Bases.Interfaces;

namespace AirStar.Infrastructure.Bases
{
    public class PagedList<T> : IPagedList<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public List<T> Data { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);

            Data = items;
        }

        public PagedList()
        { }
    }
}
