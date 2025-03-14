using System;
using Microsoft.EntityFrameworkCore;
namespace SkillShare.Application.Utilities
{
    public static class PaginationExtensions
    {
         public static async Task<Pagination<T>> ToPaginationAsync<T>(
            this IQueryable<T> query, int pageNumber, int pageSize)

        {
            var totalCount = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new Pagination<T>(pageNumber, pageSize, totalCount, items);
        }
    }
}