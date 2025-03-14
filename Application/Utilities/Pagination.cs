using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillShare.Application.Utilities
{
    public class Pagination<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<T>? Items { get; set; }

        public bool HasPrevious => PageNumber > 1;
        public bool HasNext => PageNumber < TotalPages;
    }
    
}

