using System.Collections.Generic;
using System.Linq;

namespace Jolia.Core.Results
{
    public class ImportItemsResult<T> : Transferable
    {
        public ImportItemsResult()
        {
            Results = new List<ImportItemResult<T>>();
        }

        public List<ImportItemResult<T>> Results { get; set; }
        public int SuccessCount => Results.Count(r => r.Success);
        public List<string> Messages => Results.Select(r => r.Message).Where(m => !string.IsNullOrEmpty(m)).ToList();
    }

    public class ImportItemResult<T> : Transferable
    {
        public int Index { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Item { get; set; }
    }
}
