using Microsoft.AspNetCore.Mvc;
using RoboProject.Entities;
using RoboProject.Entities.Interfaces;

namespace RoboProject.Controllers
{
    [ApiController]
    [Route("/api/robo/reset")]
    public class ResetController : ControllerBase
    {
        private readonly ILogger<RoboController> _logger;
        private IDeserializerHelper _deserializerHelper;

        public ResetController(ILogger<RoboController> logger, IDeserializerHelper deserializerHelper)
        {
            _logger = logger;
            _deserializerHelper = deserializerHelper;
        }

        [HttpGet(Name = "GetRoboReset")]
        public IActionResult Get()
        {
            Robo robo = new();

            _deserializerHelper.SerializeRobo(robo);

            return Redirect("https://localhost:7186/swagger/index.html");
        }
    }
}