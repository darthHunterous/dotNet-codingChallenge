using Microsoft.AspNetCore.Mvc;
using RoboProject.Entities;
using RoboProject.Entities.Interfaces;

namespace RoboProject.Controllers
{
    [ApiController]
    [Route("/api/robo/arm")]
    public class ArmController : ControllerBase
    {
        private IDeserializerHelper _deserializerHelper;

        private readonly ILogger<HeadController> _logger;

        public ArmController(ILogger<HeadController> logger, IDeserializerHelper deserializerHelper)
        {
            _logger = logger;
            _deserializerHelper = deserializerHelper;
        }

        [HttpGet(Name = "GetArmCommands")]
        public IActionResult Get(string arm, string command)
        {
            Robo robo = _deserializerHelper.DeserializeRobo();

            Arm selectedArm;

            switch (arm)
            {
                case "left":
                    selectedArm = robo.LeftArm;
                    break;
                case "right":
                    selectedArm = robo.RightArm;
                    break;
                default:
                    throw new Exception("Invalid arm, select left or right");
            }

            switch (command)
            {
                case "contract":
                    selectedArm.ContractArm();
                    break;
                case "relax":
                    selectedArm.RelaxArm();
                    break;
                case "clockwise":
                    selectedArm.RotateWristClockwise();
                    break;
                case "counterclockwise":
                    selectedArm.RotateWristCounterClockwise();
                    break;
                default:
                    throw new Exception("Unknown command");
            }

            _deserializerHelper.SerializeRobo(robo);

            return Ok(robo);
        }
    }
}