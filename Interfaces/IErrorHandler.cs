using System;

namespace Jolia.Core.Interfaces
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
