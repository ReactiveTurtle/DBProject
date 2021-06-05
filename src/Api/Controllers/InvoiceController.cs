using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Api.MessageContracts;
using Api.MessageContracts.Shared;
using Domain.InvoiceModel;
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
    [Route("v{version:apiVersion}/invoices")]
    [Produces("application/json")]
    public class InvoiceController : ControllerBase
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IProductRepository _productRepository;
        private readonly ISignerRepository _signerRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InvoiceController(
            IManufacturerRepository manufacturerRepository,
            IProductRepository productRepository,
            ISignerRepository signerRepository,
            IInvoiceRepository invoiceRepository,
            IUnitOfWork unitOfWork)
        {
            _manufacturerRepository = manufacturerRepository;
            _productRepository = productRepository;
            _signerRepository = signerRepository;
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("search")]
        [ProducesResponseType(typeof(SearchResult<InvoiceDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchInvoices(
            [FromBody] BaseSearchPatternDto baseSearchPatternDto)
        {
            SearchResult<Invoice> searchResult =
                await _invoiceRepository.Search(baseSearchPatternDto.Map());

            List<int> productIds = new List<int>();
            foreach (var invoice in searchResult.Items)
            {
                productIds.AddRange(invoice.Products.Select(x => x.ProductId));
            }

            IReadOnlyDictionary<int, ProductPreset> productPresets = await _productRepository
                .GetDictionaryByIds(productIds);

            IReadOnlyDictionary<int, ManufacturerPreset> manufacturerPresets = await _manufacturerRepository
                .GetDictionaryByIds(productPresets.Values.Select(x => x.ManufacturerId).ToList());

            IReadOnlyDictionary<int, ProductPresetDto> productPresetDtos =
                new ReadOnlyDictionary<int, ProductPresetDto>(
                    productPresets.ToDictionary(pair => pair.Key,
                        pair =>
                        {
                            manufacturerPresets.TryGetValue(pair.Value.ManufacturerId, out var manufacturerPreset);
                            return pair.Value.Map(manufacturerPreset);
                        }));

            IReadOnlyDictionary<int, SignerPreset> signerPresets = await _signerRepository
                .GetDictionaryByIds(searchResult.Items.Select(x => x.SignerId).ToList());

            return Ok(searchResult.Map(productPresetDtos, signerPresets));
        }

        [HttpGet("{invoiceId:int}")]
        [ProducesResponseType(typeof(InvoiceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInvoice(int invoiceId)
        {
            Invoice invoice = await _invoiceRepository
                .GetById(invoiceId)
                .ThrowIfEntityNotFound(invoiceId);

            SignerPreset signerPreset = await _signerRepository
                .GetById(invoice.SignerId)
                .ThrowIfEntityNotFound(invoice.SignerId);

            IReadOnlyDictionary<int, ProductPreset> productPresets = await _productRepository
                .GetDictionaryByIds(invoice.Products.Select(x => x.ProductId).ToList());

            IReadOnlyDictionary<int, ManufacturerPreset> manufacturerPresets = await _manufacturerRepository
                .GetDictionaryByIds(productPresets.Values.Select(x => x.ManufacturerId).ToList());

            IReadOnlyDictionary<int, ProductPresetDto> productPresetDtos =
                new ReadOnlyDictionary<int, ProductPresetDto>(
                    productPresets.ToDictionary(pair => pair.Key,
                        pair =>
                        {
                            manufacturerPresets.TryGetValue(pair.Value.ManufacturerId, out var manufacturerPreset);
                            return pair.Value.Map(manufacturerPreset);
                        }));

            return Ok(invoice.Map(productPresetDtos, signerPreset));
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateInvoice(
            [FromBody] UpsertInvoiceDto upsertInvoiceDto)
        {
            SignerPreset signerPreset = await _signerRepository
                .GetById(upsertInvoiceDto.SignerPresetId)
                .ThrowIfEntityNotFound(upsertInvoiceDto.SignerPresetId);

            Invoice invoice = new Invoice(
                upsertInvoiceDto.Name,
                upsertInvoiceDto.PreparationDate.Date,
                signerPreset.Id);
            int invoiceId = await _invoiceRepository.Add(invoice);
            await _unitOfWork.SaveEntitiesAsync();

            invoice = await _invoiceRepository.GetById(invoiceId);
            foreach (var productPresetDto in upsertInvoiceDto.ProductPresets)
            {
                invoice.AddProduct(productPresetDto.Id, invoiceId);
            }

            await _invoiceRepository.Update(invoice);

            await _unitOfWork.SaveEntitiesAsync();
            return Ok(invoiceId);
        }

        [HttpPost("{invoiceId:int}/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteInvoice([FromRoute] int invoiceId)
        {
            Invoice invoice = await _invoiceRepository
                .GetById(invoiceId)
                .ThrowIfEntityNotFound(invoiceId);

            await _invoiceRepository.Delete(invoice);

            await _unitOfWork.SaveEntitiesAsync();
            return Ok();
        }
    }
}