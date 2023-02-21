using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hydra.Repository.Dtos {
    public class PageGrid<T> {
        public List<T> Data { get; set; }
        public long TotalData { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public double TotalPages {
            get {
                return Math.Ceiling((double)TotalData / PageSize);
            }
        }

        public PageGrid(List<T> data, long totalData, int pageNumber, int pageSize) {
            Data = data;
            TotalData = totalData;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
