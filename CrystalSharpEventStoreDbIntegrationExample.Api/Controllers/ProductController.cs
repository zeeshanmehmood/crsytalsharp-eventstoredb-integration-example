using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrystalSharp.Application;
using CrystalSharp.Application.Execution;
using CrystalSharpEventStoreDbIntegrationExample.Api.Dto;
using CrystalSharpEventStoreDbIntegrationExample.Application.Commands;
using CrystalSharpEventStoreDbIntegrationExample.Application.Queries;
using CrystalSharpEventStoreDbIntegrationExample.Application.ReadModels;
using CrystalSharpEventStoreDbIntegrationExample.Application.Responses;

namespace CrystalSharpEventStoreDbIntegrationExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;

        public ProductController(ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<ActionResult<CommandExecutionResult<ProductResponse>>> Post([FromBody] CreateProductRequest request)
        {
            CreateProductCommand command = new() { Name = request.Name, Sku = request.Sku, Price = request.Price };

            return await _commandExecutor.Execute(command, CancellationToken.None).ConfigureAwait(false);
        }

        [HttpPut]
        [Route("change-name")]
        public async Task<ActionResult<CommandExecutionResult<ProductResponse>>> PutChangeName([FromBody] ChangeProductNameRequest request)
        {
            ChangeProductNameCommand command = new() { GlobalUId = request.GlobalUId, Name = request.Name };

            return await _commandExecutor.Execute(command, CancellationToken.None).ConfigureAwait(false);
        }

        [HttpPut]
        [Route("change-info")]
        public async Task<ActionResult<CommandExecutionResult<ProductResponse>>> PutChangeInfo([FromBody] ChangeProductInfoRequest request)
        {
            ChangeProductInfoCommand command = new() { GlobalUId = request.GlobalUId, Sku = request.Sku, Price = request.Price };

            return await _commandExecutor.Execute(command, CancellationToken.None).ConfigureAwait(false);
        }

        [HttpDelete]
        [Route("{globalUId}")]
        public async Task<ActionResult<CommandExecutionResult<DeleteProductResponse>>> Delete(Guid globalUId)
        {
            DeleteProductCommand command = new() { GlobalUId = globalUId };

            return await _commandExecutor.Execute(command, CancellationToken.None).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("product-details/{globalUId}")]
        public async Task<ActionResult<QueryExecutionResult<ProductReadModel>>> GetDetails(Guid globalUId)
        {
            ProductDetailQuery query = new() { GlobalUId = globalUId };

            return await _queryExecutor.Execute(query, CancellationToken.None).ConfigureAwait(false);
        }

        [HttpGet]
        [Route("product-details-by-version/{globalUId}/{version}")]
        public async Task<ActionResult<QueryExecutionResult<ProductReadModel>>> GetDetailsByVersion(Guid globalUId, long version)
        {
            ProductDetailByVersionQuery query = new() { GlobalUId = globalUId, Version = version };

            return await _queryExecutor.Execute(query, CancellationToken.None).ConfigureAwait(false);
        }
    }
}
