
using FOA.WebApi.Extensions.Controller;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace FOA.GraphQL.API.Controllers
{
    /// <summary>
    /// Support controller for this micro service
    /// </summary>
    public class SupportController : SupportControllerBase
    {
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="logger">The logger to use</param>
        /// <param name="applicationLifetime">Application lifetime</param>
        public SupportController(
            ILogger<SupportController> logger,
            IApplicationLifetime applicationLifetime
            ) : base(logger: logger, applicationLifetime: applicationLifetime)
        {
        }
    }
}