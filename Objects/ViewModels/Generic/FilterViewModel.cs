using System.ComponentModel.DataAnnotations;

namespace Jolia.Core.ViewModels.Generic
{
    /// <summary>
    /// Global Filter Model
    /// </summary>
    public class FilterViewModel : Transferable
    {
        /// <summary>
        /// Results Page Index
        /// </summary>
        [Required()]
        [Display(Name = "Results Page Index")]
        public int PageIndex { get; set; }

        /// <summary>
        /// Results Page Size
        /// </summary>
        [Required()]
        [Display(Name = "Results Page Size")]
        public int PageSize { get; set; }

        /// <summary>
        /// Results Skip Size
        /// </summary>
        [Display(Name = "Results Skip Size")]
        public int SkipSize => PageIndex * PageSize;
    }
}
