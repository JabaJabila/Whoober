using System;

namespace WhooberCore.Domain.Entities.Notifications
{
    public interface INotification
    {
        DateTime Time { get; }
    }
}