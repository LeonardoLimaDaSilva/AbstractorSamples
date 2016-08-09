using System.Diagnostics;
using Abstractor.Cqrs.Interfaces.CrossCuttingConcerns;

namespace AbstractorSamples.Web.Common
{
    /// <summary>
    ///     Sample logger that writes to debug output.
    /// </summary>
    public sealed class DebugOutputLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }
}