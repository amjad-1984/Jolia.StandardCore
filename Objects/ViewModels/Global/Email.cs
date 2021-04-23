namespace Jolia.Core.ViewModels.Global
{
    // TODO: Remove this Model
    public class MailTemplateViewModel : Transferable
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Footer { get; set; }
        public string LinkText { get; set; }
        public string LinkUrl { get; set; }
    }

    public class BaseEmailViewModel : Transferable
    {
        public string ActionTitle { get; set; }
        public string ActionUrl { get; set; }
    }

    public class GlobalEmailViewModel : BaseEmailViewModel
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class ContactEmailViewModel : BaseEmailViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}