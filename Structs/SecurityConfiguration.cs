using static Jolia.Core.Enums;

namespace Jolia.Core.Structs
{
    public struct SecurityConfiguration
    {
        public bool ConfirmingPhoneNumber;
        public bool ConfirmingEmail;
        public bool PhoneNumberRequired;
        public bool EmailRequired;
        public bool NameIsUnique;
        public bool NameIsUserName;
        public bool LoginRequiresConfirmation;
    }
}
