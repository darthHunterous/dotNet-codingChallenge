using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RoboProject.Entities;
using RoboProject.Entities.HeadStates;
using RoboProject.Entities.Interfaces;

namespace RoboProject.Controllers
{
    [ApiController]
    [Route("/api/robo/head")]
    public class HeadController : ControllerBase
    {
        private Robo? Robo;

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
            Robo = _deserializerHelper.deserializeRobo();

            switch (command)
            {
                case "lower":
                    Robo?.Head.LowerHead();
                    break;
                case "raise":
                    Robo?.Head.RaiseHead();
                    break;
                case "left":
                    Robo?.Head.RotateHeadLeft();
                    break;
                case "right":
                    Robo?.Head.RotateHeadRight();
                    break;
                default:
                    throw new Exception("Unknown command");
            }

            _deserializerHelper.serializeRobo(Robo);

            return Ok(Robo);
        }
    }
}