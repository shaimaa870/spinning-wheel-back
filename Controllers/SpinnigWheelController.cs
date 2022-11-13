using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using spinning_wheel.Core;
using spinning_wheel.Core.Domain;
using spinning_wheel.Core.Dtos;

namespace spinning_wheel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpinnigWheelController : ControllerBase
    {
     
            private readonly ISpinningWheellRepo _spinningWheelRepo;
            public SpinnigWheelController(ISpinningWheellRepo spinningWheelRepo)
            {
            _spinningWheelRepo = spinningWheelRepo;
            }

            [HttpGet]
            public  Task<List<SpinningWheel>> Get()
            {
            return _spinningWheelRepo.GetSpinningWheels();
            }
        [HttpGet("find/{id}")]
        public Task<SpinningWheel> GetWithId([FromRoute] string id)
        {
            return _spinningWheelRepo.GetSpinningWheel(id);
        }
        [HttpPost]
            public  IActionResult Post(SpinningWheelDto request)
            {
                if (request == null)
                    return BadRequest();
            var spinningWheel = new SpinningWheel() { Name = request.Name };
            spinningWheel.Segments = new HashSet<WheelSegment>();
            if (request.Segments.Count > 0)
            {
                foreach (var segmentDto in request.Segments)
                {
                    spinningWheel.Segments.Add(new WheelSegment()
                    {
                        Label = segmentDto.Label,
                        TextColor = segmentDto.TextColor,
                        Reward = segmentDto.Reward,
                        Color = segmentDto.Color,
                    });

                }
            }



                return  Ok(_spinningWheelRepo.CreateSpinningWheel(spinningWheel)) ;

            }

            [HttpPut]
            public IActionResult Update( SpinningWheelDto request)
            {
            if (request == null)
                return BadRequest();
            var spinningWheel = new SpinningWheel() 
            {
                Id=request.Id,
                Name = request.Name
            };
            spinningWheel.Segments = new HashSet<WheelSegment>();
            if (request.Segments.Count > 0)
            {
                foreach (var segmentDto in request.Segments)
                {
                    spinningWheel.Segments.Add(new WheelSegment()
                    {
                        Label = segmentDto.Label,
                        TextColor = segmentDto.TextColor,
                        Reward = segmentDto.Reward,
                        Color = segmentDto.Color,
                    });

                }
            }


            return Ok(_spinningWheelRepo.UpdateSpinningWheel(spinningWheel));
        }

            [HttpDelete("delete/{id}")]
            public Task<string> Delete ([FromRoute] string id)
            {
               

                return _spinningWheelRepo.DeleteSpinningWheel(id);
            }

        }
    }

