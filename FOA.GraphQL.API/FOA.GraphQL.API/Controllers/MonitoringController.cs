
using FOA.WebApi.Extensions.Controller;
using FOA.WebApi.Extensions.Identity;
using Microsoft.Extensions.Logging;

namespace FOA.GraphQL.API.Controllers
{
    /// <summary>
    /// Monitoring controller for this service
    /// </summary>
    public class MonitoringController : MonitoringControllerBase
    {
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="userIdentity">The user's identity</param>
        /// <param name="logger">The logger to use</param>
        public MonitoringController(
            ILogger<MonitoringController> logger,
            IUserIdentity userIdentity
            ) : base(logger, userIdentity)
        { }

    }
}