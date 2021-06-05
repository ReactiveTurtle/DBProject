using System.Collections.Generic;
using System.Linq;
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
    [Route("v{version:apiVersion}/products")]
    [Produces("application/json")]
    public class ProductController : ControllerBase
    {
        private readonly IManufacturerRepository _manufacturerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(
            IManufacturerRepository manufacturerRepository,
            IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _manufacturerRepository = manufacturerRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("search")]
        [ProducesResponseType(typeof(SearchResult<ProductPresetDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchProducts(
            [FromBody] BaseSearchPatternDto baseSearchPatternDto)
        {
            SearchResult<ProductPreset> searchResult =
                await _productRepository.Search(baseSearchPatternDto.Map());

            IReadOnlyList<int> manufacturerIds = searchResult.Items.Select(x => x.ManufacturerId).ToList();
            IReadOnlyDictionary<int, ManufacturerPreset> manufacturerPresets =
                await _manufacturerRepository.GetDictionaryByIds(manufacturerIds);

            return Ok(searchResult.Map(manufacturerPresets));
        }

        [HttpGet("{productId:int}")]
        [ProducesResponseType(typeof(ProductPresetDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProduct(int productId)
        {
            ProductPreset productPreset = await _productRepository.GetById(productId)
                .ThrowIfEntityNotFound(productId);

            ManufacturerPreset manufacturerPreset = await _manufacturerRepository.GetById(productPreset.ManufacturerId)
                .ThrowIfEntityNotFound(productPreset.ManufacturerId);

            return Ok(productPreset.Map(manufacturerPreset));
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct(
            [FromBody] UpsertProductDto upsertProductDto)
        {
            ManufacturerPreset manufacturerPreset = await _manufacturerRepository
                .GetById(upsertProductDto.ManufacturerId)
                .ThrowIfEntityNotFound(upsertProductDto.ManufacturerId);

            ProductPreset productPreset = new ProductPreset(
                manufacturerPreset.Id,
                new Product(upsertProductDto.Name,
                    upsertProductDto.Price,
                    upsertProductDto.CurrencyType.Map(),
                    upsertProductDto.ManufactureDateTime.Date,
                    upsertProductDto.ExpirationDateTime.Date));

            int productId = await _productRepository.Add(productPreset);

            await _unitOfWork.SaveEntitiesAsync();
            return Ok(productId);
        }

        [HttpPost("{productId:int}/update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProduct(
            [FromRoute] int productId,
            [FromBody] UpsertProductDto upsertProductDto)
        {
            ManufacturerPreset manufacturerPreset = await _manufacturerRepository
                .GetById(upsertProductDto.ManufacturerId)
                .ThrowIfEntityNotFound(upsertProductDto.ManufacturerId);

            ProductPreset productPreset = await _productRepository
                .GetById(productId)
                .ThrowIfEntityNotFound(productId);

            productPreset.Update(
                manufacturerPreset.Id,
                new Product(
                    upsertProductDto.Name,
                    upsertProductDto.Price,
                    upsertProductDto.CurrencyType.Map(),
                    upsertProductDto.ManufactureDateTime.Date,
                    upsertProductDto.ExpirationDateTime.Date));

            await _productRepository.Update(productPreset);

            await _unitOfWork.SaveEntitiesAsync();
            return Ok();
        }

        [HttpPost("{productId:int}/delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            ProductPreset productPreset = await _productRepository
                .GetById(productId)
                .ThrowIfEntityNotFound(productId);

            await _productRepository.Delete(productPreset);

            await _unitOfWork.SaveEntitiesAsync();
            return Ok();
        }
    }
}