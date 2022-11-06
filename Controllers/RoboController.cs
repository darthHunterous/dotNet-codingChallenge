using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RoboProject.Entities;

namespace RoboProject.Controllers
{
    [ApiController]
    [Route("/api/robo")]
    public class RoboController : ControllerBase
    {
        private Robo? Robo;

        private readonly ILogger<RoboController> _logger;

        public RoboController(ILogger<RoboController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetRoboInformation")]
        public IActionResult Get()
        {
            string roboState = System.IO.File.ReadAllText("robo.json");
            Robo = JsonConvert.DeserializeObject<Robo>(roboState);

            if (Robo == null)
            {
                Robo = new Robo();

                string jsonString = JsonConvert.SerializeObject(Robo);
                System.IO.File.WriteAllText("robo.json", jsonString);
            }

            return Ok(Robo);
        }
    }
}