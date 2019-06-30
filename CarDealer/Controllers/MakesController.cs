using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CarDealer.Core;
using CarDealer.Core.Domain;
using CarDealer.Core.Dto;
using CarDealer.Core.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace CarDealer.Controllers
{
    [ApiController]
    public class MakesController : ControllerBase
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMakeRepository _makeRepository;
        #endregion

        #region Constructor
        public MakesController(IUnitOfWork unitOfWork, IMapper mapper, IMakeRepository makeRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _makeRepository = makeRepository;

        }
        #endregion



        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeDto>> GetMakes()
        {
            var makes = await _makeRepository.GetAllMakesWithModelsAsync();

            return _mapper.Map<List<Make>, List<MakeDto>>(makes);
        }

    }
}