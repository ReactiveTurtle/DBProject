using System;

namespace Toolkit.Clock
{
    public interface IClock
    {
        DateTime Now();

        DateTime Today();
    }
}
