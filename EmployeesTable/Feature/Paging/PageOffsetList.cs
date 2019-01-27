using System.Collections.Generic;

namespace EmployeesTable.Feature.Paging
{
    public class PageOffsetList : System.ComponentModel.IListSource
    {
        private readonly int count;

        public PageOffsetList(int count)
        {
            this.count = count;
        }

        public bool ContainsListCollection { get; protected set; }

        public System.Collections.IList GetList()
        {
            var pageOffsets = new List<int>();
            for (int offset = 0; offset < count; offset += 50)
                pageOffsets.Add(offset);
            return pageOffsets;
        }
    }
}
