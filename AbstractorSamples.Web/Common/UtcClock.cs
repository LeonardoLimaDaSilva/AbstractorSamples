using System;
using Abstractor.Cqrs.Interfaces.CrossCuttingConcerns;

namespace AbstractorSamples.Web.Common
{
    /// <summary>
    ///     Sample clock that uses UTC format.
    /// </summary>
    public sealed class UtcClock : IClock
    {
        public DateTime Now()
        {
            return DateTime.UtcNow;
        }
    }
}