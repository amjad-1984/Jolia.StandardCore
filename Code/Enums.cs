using System.ComponentModel.DataAnnotations;
using Jolia.Core.Resources;

namespace Jolia.Core
{
    public class Enums
    {
        public enum TableActions
        {
            Preview,
            Create,
            Edit,
            Delete,
            Export,
            Import,
            Reports
        }

        public enum LayoutDirections
        {
            LTR,
            RTL
        }

        public enum LogPatterns
        {
            [Display(Name = "Log_None", ResourceType = typeof(RGlobal))]
            None,
            [Display(Name = "Log_Create", ResourceType = typeof(RGlobal))]
            Create,
            [Display(Name = "Log_Edit", ResourceType = typeof(RGlobal))]
            Edit,
            [Display(Name = "Log_Delete", ResourceType = typeof(RGlobal))]
            Delete
        }

        public enum WebFeatures
        {
            Angular
        }

        public enum ExportMethods
        {
            PDF,
            Excel
        }

        public enum LayoutMarginsPatterns
        {
            Normal,
            Wide,
            Narrow
        }

        public enum FileTypes
        {
            [Display(Name = "Type_IMG", ResourceType = typeof(RIO))]
            IMG,
            [Display(Name = "Type_PDF", ResourceType = typeof(RIO))]
            PDF,
            [Display(Name = "Type_DOC", ResourceType = typeof(RIO))]
            DOC,
            [Display(Name = "Type_XLS", ResourceType = typeof(RIO))]
            XLS,
            [Display(Name = "Type_PPT", ResourceType = typeof(RIO))]
            PPT,
            [Display(Name = "Type_TXT", ResourceType = typeof(RIO))]
            TXT,
            [Display(Name = "Type_File", ResourceType = typeof(RIO))]
            File
        }

        public enum Genders
        {
            [Display(Name = "Male", ResourceType = typeof(RAccount))]
            Male,
            [Display(Name = "Female", ResourceType = typeof(RAccount))]
            Female
        }

        public enum Days
        {
            [Display(Name = "Saturday", ResourceType = typeof(RCalendar))]
            Saturday,
            [Display(Name = "Sunday", ResourceType = typeof(RCalendar))]
            Sunday,
            [Display(Name = "Monday", ResourceType = typeof(RCalendar))]
            Monday,
            [Display(Name = "Tuesday", ResourceType = typeof(RCalendar))]
            Tuesday,
            [Display(Name = "Wednesday", ResourceType = typeof(RCalendar))]
            Wednesday,
            [Display(Name = "Thursday", ResourceType = typeof(RCalendar))]
            Thursday,
            [Display(Name = "Friday", ResourceType = typeof(RCalendar))]
            Friday
        }

        public enum Months
        {
            [Display(Name = "January", ResourceType = typeof(RCalendar))]
            January,
            [Display(Name = "February", ResourceType = typeof(RCalendar))]
            February,
            [Display(Name = "March", ResourceType = typeof(RCalendar))]
            March,
            [Display(Name = "April", ResourceType = typeof(RCalendar))]
            April,
            [Display(Name = "May", ResourceType = typeof(RCalendar))]
            May,
            [Display(Name = "June", ResourceType = typeof(RCalendar))]
            June,
            [Display(Name = "July", ResourceType = typeof(RCalendar))]
            July,
            [Display(Name = "August", ResourceType = typeof(RCalendar))]
            August,
            [Display(Name = "September", ResourceType = typeof(RCalendar))]
            September,
            [Display(Name = "October", ResourceType = typeof(RCalendar))]
            October,
            [Display(Name = "November", ResourceType = typeof(RCalendar))]
            November,
            [Display(Name = "December", ResourceType = typeof(RCalendar))]
            December
        }

        public enum ColorClasses
        {
            None,
            Info,
            Success,
            Warning,
            Danger
        }

        public enum SMSProviders
        {
            PostToUrl,
            GetUrl,
            GetUrl2
        }

        public enum EmailServices
        {
            Gmail,
            SecureServer,
            AmazonWebServices,
            Custom
        }

        public enum UserClaimTypes
        {
            Name,
            AvatarUrl,
            EmailConfirmed,
            PhoneNumberConfirmed
        }

        public enum DefaultImageTypes
        {
            Empty,
            Avatar
        }

        public enum PS
        {
            [Display(Name = "PS_Success", ResourceType = typeof(RGlobal))]
            Success,
            [Display(Name = "PS_Warning", ResourceType = typeof(RGlobal))]
            Warning,
            [Display(Name = "PS_Error", ResourceType = typeof(RGlobal))]
            Error,
            [Display(Name = "PS_NotFound", ResourceType = typeof(RGlobal))]
            NotFound,
            [Display(Name = "PS_Forbidden", ResourceType = typeof(RGlobal))]
            Forbidden,
            [Display(Name = "PS_BadRequest", ResourceType = typeof(RGlobal))]
            BadRequest
        }
    }
}
