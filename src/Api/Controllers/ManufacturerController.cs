using System.Threading.Tasks;
using Api.MessageContracts;
using Api.MessageContracts.Shared;
using Domain.InvoiceModel;
using Domain.Shared;
using Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toolkit.Domain.Abstractions;
using Toolkit.Exceptions;
using Toolkit.Search;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/manufacturers")]
    [Produces("application/json")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ManufacturerController(
            IManufacturerRepository manufacturerRepository,
            IUnitOfWork unitOfWork)
        {
            _manufacturerRepository = manufacturerRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("search")]
        [ProducesResponseType(typeof(SearchResult<ManufacturerPresetDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchManufacturers(
            [FromBody] BaseSearchPatternDto baseSearchPatternDto)
        {
            SearchResult<ManufacturerPreset> searchResult =
                await _manufacturerRepository.Search(baseSearchPatternDto.Map());
            return Ok(searchResult.Map());
        }

        [HttpGet("{manufacturerId:int}")]
        [ProducesResponseType(typeof(ManufacturerPresetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetManufacturer(int manufacturerId)
        {
            var manufacturerPreset = await _manufacturerRepository.GetById(manufacturerId)
                .ThrowIfEntityNotFound(manufacturerId);

            return Ok(manufacturerPreset.Map());
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateManufacturer(
            [FromBody] UpsertManufacturerDto upsertManufacturerDto)
        {
            var manufacturerPreset = new ManufacturerPreset(
                new Manufacturer(
                    upsertManufacturerDto.Name,
                    upsertManufacturerDto.Address,
                    upsertManufacturerDto.PhoneNumber,
                    upsertManufacturerDto.Email,
                    upsertManufacturerDto.ManagerFullname));

            int contractId = await _manufacturerRepository.Add(manufacturerPreset);

            await _unitOfWork.SaveEntitiesAsync();
            return Ok(contractId);
        }

        [HttpPost("{manufacturerId:int}/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateManufacturer(
            [FromRoute] int manufacturerId,
            [FromBody] UpsertManufacturerDto upsertManufacturerDto)
        {
            var manufacturerPreset = await _manufacturerRepository
                .GetById(manufacturerId)
                .ThrowIfEntityNotFound(manufacturerId);
            
            manufacturerPreset.Update(
                new Manufacturer(
                    upsertManufacturerDto.Name,
                    upsertManufacturerDto.Address,
                    upsertManufacturerDto.PhoneNumber,
                    upsertManufacturerDto.Email,
                    upsertManufacturerDto.ManagerFullname));

            await _manufacturerRepository.Update(manufacturerPreset);

            await _unitOfWork.SaveEntitiesAsync();
            return Ok();
        }
    }
}