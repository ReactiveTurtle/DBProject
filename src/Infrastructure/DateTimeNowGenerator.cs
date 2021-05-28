﻿using System;
using Toolkit.Clock;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Infrastructure
{
    public class DateTimeNowGenerator : ValueGenerator<DateTime>
    {
        private readonly IClock _clock;

        public DateTimeNowGenerator( IClock clock )
        {
            _clock = clock;
        }

        public override DateTime Next( EntityEntry entry )
        {
            return _clock.Now();
        }

        public override bool GeneratesTemporaryValues { get; } = false;
    }
}
