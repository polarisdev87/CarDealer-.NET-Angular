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
    public class FeaturesController : ControllerBase
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly IFeatureRepository _featureRepository;

        
        #endregion

        #region Constructor
        public FeaturesController(IUnitOfWork unitOfWork, IMapper mapper, IFeatureRepository featureRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _featureRepository = featureRepository;

        }
        #endregion


        [HttpGet("/api/features")]
        public async Task<IEnumerable<KeyValuePairDto>> GetFeatures()
        {
            var features = await _featureRepository.GetAllAsync();

            return _mapper.Map<List<Feature>, List<KeyValuePairDto>>(features);
        }

    }
}