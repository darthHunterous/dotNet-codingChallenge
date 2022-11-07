using Microsoft.AspNetCore.Mvc;
using RoboProject.Entities;
using RoboProject.Entities.Interfaces;

namespace RoboProject.Controllers
{
    [ApiController]
    [Route("/api/robo/head")]
    public class HeadController : ControllerBase
    {
        private IDeserializerHelper _deserializerHelper;

        private readonly ILogger<HeadController> _logger;

        public HeadController(ILogger<HeadController> logger, IDeserializerHelper deserializerHelper)
        {
            _logger = logger;
            _deserializerHelper = deserializerHelper;
        }

        [HttpGet(Name = "GetHeadCommands")]
        public IActionResult Get(string command)
        {
            Robo robo = _deserializerHelper.DeserializeRobo();

            switch (command)
            {
                case "lower":
                    robo.Head.LowerHead();
                    break;
                case "raise":
                    robo.Head.RaiseHead();
                    break;
                case "left":
                    robo.Head.RotateHeadLeft();
                    break;
                case "right":
                    robo.Head.RotateHeadRight();
                    break;
                default:
                    throw new Exception("Unknown command");
            }

            _deserializerHelper.SerializeRobo(robo);

            return Ok(robo);
        }
    }
}