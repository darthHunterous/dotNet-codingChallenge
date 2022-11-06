using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RoboProject.Entities;
using RoboProject.Entities.HeadStates;

namespace RoboProject.Controllers
{
    [ApiController]
    [Route("/api/robo/head")]
    public class HeadController : ControllerBase
    {
        private Robo? Robo;

        private readonly ILogger<HeadController> _logger;

        public HeadController(ILogger<HeadController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetHeadCommands")]
        public IActionResult Get(string command)
        {
            string roboInternalState = System.IO.File.ReadAllText("robo.json");
            Robo = JsonConvert.DeserializeObject<Robo>(roboInternalState);

            if (Robo == null)
            {
                throw new Exception("Invalid robot internal state, reload the application");
            }

            string? stateDescriptor = Robo?.Head.State.Descriptor;

            switch (stateDescriptor)
            {
                case "Static":
                    if (Robo != null)
                    {
                        Robo.Head.State = new StaticHeadState();
                    }                   
                    break;
                case "Upwards":
                    if (Robo != null)
                    {
                        Robo.Head.State = new UpwardsHeadState();
                    }
                    break;
                case "Downwards":
                    if (Robo != null)
                    {
                        Robo.Head.State = new DownwardsHeadState();
                    }
                    break;
                default:
                    throw new Exception("Invalid case");
            }     

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

            string jsonString = JsonConvert.SerializeObject(Robo);
            System.IO.File.WriteAllText("robo.json", jsonString);

            return Ok(Robo);
        }
    }
}