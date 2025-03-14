using System;
using Microsoft.EntityFrameworkCore;
namespace SkillShare.Application.Utilities
{
    public static class PaginationExtensions
    {
        public static Pagination<T> ToPagination<T>(
            this IEnumerable<T> source, 
            int pageNumber, 
            int pageSize)
        {
            var count = source.Count();
            var items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new Pagination<T>
            {
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = count,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
        }

        public static async Task<Pagination<T>> ToPaginationAsync<T>(
            this IEnumerable<T> source,
            int pageNumber,
            int pageSize)
        {
            return await Task.FromResult(source.ToPagination(pageNumber, pageSize));
        }
    }
}
