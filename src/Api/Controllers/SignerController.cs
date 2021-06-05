using System.Threading.Tasks;
using Api.MessageContracts;
using Api.MessageContracts.Shared;
using Domain.InvoiceModel;
using Domain.Shared;
using Infrastructure.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Toolkit.Domain.Abstractions;
using Toolkit.Extensions;
using Toolkit.Search;

namespace Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/signers")]
    [Produces("application/json")]
    public class SignerController : ControllerBase
    {
        private readonly ISignerRepository _signerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SignerController(
            ISignerRepository signerRepository,
            IUnitOfWork unitOfWork)
        {
            _signerRepository = signerRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("search")]
        [ProducesResponseType(typeof(SearchResult<SignerPresetDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchSigners(
            [FromBody] BaseSearchPatternDto baseSearchPatternDto)
        {
            SearchResult<SignerPreset> searchResult =
                await _signerRepository.Search(baseSearchPatternDto.Map());
            return Ok(searchResult.Map());
        }

        [HttpGet("{signerId:int}")]
        [ProducesResponseType(typeof(SignerPresetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSigner(int signerId)
        {
            SignerPreset signerPreset = await _signerRepository.GetById(signerId)
                .ThrowIfEntityNotFound(signerId);

            return Ok(signerPreset.Map());
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSigner(
            [FromBody] UpsertSignerDto upsertSignerDto)
        {
            SignerPreset signerPreset = new SignerPreset(
                new Signer(
                    upsertSignerDto.Fullname,
                    upsertSignerDto.Position,
                    upsertSignerDto.Address,
                    upsertSignerDto.PhoneNumber));

            int signerId = await _signerRepository.Add(signerPreset);

            await _unitOfWork.SaveEntitiesAsync();
            return Ok(signerId);
        }

        [HttpPost("{signerId:int}/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateSigner(
            [FromRoute] int signerId,
            [FromBody] UpsertSignerDto upsertSignerDto)
        {
            SignerPreset signerPreset = await _signerRepository
                .GetById(signerId)
                .ThrowIfEntityNotFound(signerId);

            signerPreset.Update(
                new Signer(
                    upsertSignerDto.Fullname,
                    upsertSignerDto.Position,
                    upsertSignerDto.Address,
                    upsertSignerDto.PhoneNumber));

            await _signerRepository.Update(signerPreset);

            await _unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpPost("{signerId:int}/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteSigner([FromRoute] int signerId)
        {
            SignerPreset signerPreset = await _signerRepository
                .GetById(signerId)
                .ThrowIfEntityNotFound(signerId);

            await _signerRepository.Delete(signerPreset);

            await _unitOfWork.SaveEntitiesAsync();
            return Ok();
        }
    }
}