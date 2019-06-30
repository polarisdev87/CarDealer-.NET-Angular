using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Core;
using CarDealer.Core.Domain;
using CarDealer.Core.Dto;
using CarDealer.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Controllers
{
    [Route("/api/vehicles")]
    public class VehicleController : Controller
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IModelRepository _modelRepository;
        #endregion

        #region Constructor
        public VehicleController(
            IUnitOfWork unitOfWork,

            IMapper mapper, 

            IVehicleRepository vehicleRepository, 
            IModelRepository modelRepository 
        )
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;

            _vehicleRepository = vehicleRepository;
            _modelRepository = modelRepository;
        }
        #endregion

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _vehicleRepository.GetById(id, true);

            if (vehicle == null)
            {
                return NotFound();
            }

            var vehicleDto = _mapper.Map<Vehicle, VehicleDto>(vehicle);

            return Ok(vehicleDto);
        }



        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] SaveVehicleDto saveVehicleDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var model = await _modelRepository.GetById(saveVehicleDto.ModelId);

            if (model == null)
            {
                ModelState.AddModelError("ModelId", "Invalid ModelId");
                return BadRequest(ModelState);
            }


            var vehicle = _mapper.Map<SaveVehicleDto, Vehicle>(saveVehicleDto);

            // vehicle.LastUpdate = DateTime.Now;
            await _vehicleRepository.Create(vehicle);

            await _unitOfWork.CompleteAsync();

            vehicle = await _vehicleRepository.GetById(vehicle.Id, true);

            var result = _mapper.Map<Vehicle, VehicleDto>(vehicle);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] SaveVehicleDto saveVehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var vehicle = await _vehicleRepository.GetById(id, true);

            if (vehicle == null)
            {
                return NotFound();
            }

            _mapper.Map(saveVehicleDto, vehicle);

            await _unitOfWork.CompleteAsync();

            vehicle = await _vehicleRepository.GetById(vehicle.Id);

            var result = _mapper.Map<Vehicle, VehicleDto>(vehicle);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {

            var vehicle = await _vehicleRepository.GetById(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            await _vehicleRepository.Delete(vehicle.Id);

            await _unitOfWork.CompleteAsync();

            return Ok(id);

        }
    }
}