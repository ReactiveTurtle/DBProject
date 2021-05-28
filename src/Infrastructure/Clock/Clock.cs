using System;
using Toolkit.Clock;

namespace Infrastructure.Clock
{
    public class Clock : IClock
    {
        public DateTime Now()
        {
            return DateTime.UtcNow;
        }

        public DateTime Today()
        {
            return DateTime.UtcNow.Date;
        }
    }
}
