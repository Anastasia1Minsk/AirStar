using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirStar.Infrastructure.Bases.Interfaces
{
    public interface IPagedList<T>
    {
        int CurrentPage { get; set; }
        int TotalPages { get; set; }
        int PageSize { get; set; }
        int TotalCount { get; set; }
        List<T> Data { get; set; }
    }
}