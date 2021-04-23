using Jolia.Core.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jolia.Core.ViewModels.Generic
{
    public class FilterItemsViewModel<T> : FilterViewModel
    {
        [Display(Name = "Term", ResourceType = typeof(RGlobal))]
        public string Term { get; set; }

        public List<T> Items { get; set; }
    }
}
