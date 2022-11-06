using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RoboProject.Entities;
using RoboProject.Entities.ArmStates;

namespace RoboProject.Controllers
{
    [ApiController]
    [Route("/api/robo/arm")]
    public class ArmController : ControllerBase
    {
        private Robo? Robo;

        private readonly ILogger<HeadController> _logger;

        public ArmController(ILogger<HeadController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetArmCommands")]
        public IActionResult Get(string command, string arm)
        {
            string roboInternalState = System.IO.File.ReadAllText("robo.json");
            Robo = JsonConvert.DeserializeObject<Robo>(roboInternalState);

            if (Robo == null)
            {
                throw new Exception("Invalid robot internal state, reload the application");
            }

            string? leftArmStateDescriptor = Robo?.LeftArm.State.Descriptor;
            string? rightArmStateDescriptor = Robo?.RightArm.State.Descriptor;

            switch (leftArmStateDescriptor)
            {
                case "Static":
                    if (Robo != null)
                    {
                        Robo.LeftArm.State = new StaticArmState();
                    }
                    break;
                case "Slightly Contracted":
                    if (Robo != null)
                    {
                        Robo.LeftArm.State = new SlightlyContractedArmState();
                    }
                    break;
                case "Contracted":
                    if (Robo != null)
                    {
                        Robo.LeftArm.State = new ContractedArmState();
                    }
                    break;
                case "Heavily Contracted":
                    if (Robo != null)
                    {
                        Robo.LeftArm.State = new HeavilyContractedArmState();
                    }
                    break;
                default:
                    throw new Exception("Invalid case");
            }

            switch (rightArmStateDescriptor)
            {
                case "Static":
                    if (Robo != null)
                    {
                        Robo.RightArm.State = new StaticArmState();
                    }
                    break;
                case "Slightly Contracted":
                    if (Robo != null)
                    {
                        Robo.RightArm.State = new SlightlyContractedArmState();
                    }
                    break;
                case "Contracted":
                    if (Robo != null)
                    {
                        Robo.RightArm.State = new ContractedArmState();
                    }
                    break;
                case "Heavily Contracted":
                    if (Robo != null)
                    {
                        Robo.RightArm.State = new HeavilyContractedArmState();
                    }
                    break;
                default:
                    throw new Exception("Invalid case");
            }

            Arm? selectedArm;

            switch (arm)
            {
                case "left":
                    selectedArm = Robo?.LeftArm;
                    break;
                case "right":
                    selectedArm = Robo?.RightArm;
                    break;
                default:
                    throw new Exception("Invalid arm, select left or right");
            }

            switch (command)
            {
                case "contract":
                    selectedArm?.ContractArm();
                    break;
                case "relax":
                    selectedArm?.RelaxArm();
                    break;
                case "clockwise":
                    selectedArm?.RotateWristClockwise();
                    break;
                case "counterclockwise":
                    selectedArm?.RotateWristCounterClockwise();
                    break;
                default:
                    throw new Exception("Unknown command");
            }

            string jsonString = JsonConvert.SerializeObject(Robo);
            System.IO.File.WriteAllText("robo.json", jsonString);

            return Ok(Robo);
        }
    }
}