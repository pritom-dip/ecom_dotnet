using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class QueryObject
    {
        public int PerPage { get; set; } = 10;
        public int PageNumber { get; set; } = 1;
    }
}