using NLog.Config;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NLog.Targets
{
    public sealed class NTUHTarget : AsyncTaskTarget
    {
        public NTUHTarget()
        {
            this.IncludeEventProperties = true; // Include LogEvent Properties by default
            this.Host = "localhost";
        }

        [RequiredParameter]
        public string Host { get; set; }
        protected override Task WriteAsyncTask(LogEventInfo logEvent, CancellationToken cancellationToken)
        {
            string logMessage = this.RenderLogEvent(this.Layout, logEvent);
            IDictionary<string, object> logProperties = this.GetAllProperties(logEvent);
            return SendTheMessageToRemoteHost(this.Host, logMessage, logProperties);
        }
        private async Task SendTheMessageToRemoteHost(string host, string message, IDictionary<string, object> properties)
        {
            // TODO - write me 
        }
        //protected override Task WriteAsyncTask(IList<LogEventInfo> logEvents, CancellationToken cancellationToken)
        //{
        //    // TODO - write batch
        //}
    }
}
