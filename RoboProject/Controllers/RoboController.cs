using Microsoft.AspNetCore.Mvc;
using RoboProject.Entities.Interfaces;

namespace RoboProject.Controllers
{
    [ApiController]
    [Route("/api/robo")]
    public class RoboController : ControllerBase
    {
        private readonly ILogger<RoboController> _logger;
        private IDeserializerHelper _deserializerHelper;

        public RoboController(ILogger<RoboController> logger, IDeserializerHelper deserializerHelper)
        {
            _logger = logger;
            _deserializerHelper = deserializerHelper;
        }

        [HttpGet(Name = "GetRoboInformation")]
        public IActionResult Get()
        {
            return Ok(_deserializerHelper.DeserializeRobo());
        }
    }
}