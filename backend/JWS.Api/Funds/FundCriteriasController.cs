using JWS.Contracts.ApiRoutes;
using JWS.Service.FundCriteria.Commands.AddEditFundCriteria;
using JWS.Service.FundCriteria.Commands.DeleteFundCriteria;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace JWS.Api.Funds
{
    [ApiController]
    public class FundCriteriasController : BaseController
    {
        public FundCriteriasController(IMediator mediator) : base(mediator) { }

        [HttpPost(ApiRoutes.Funds.Criterias.Add)]
        public async Task<IActionResult> AddAsync([FromRoute] Guid fundId, [FromBody] AddEditFundCriteriaRequest request)
        {
            request.UserId = UserId;
            request.FundId = fundId;
            request.CriteriaId = null;

            return await _mediator.Send(request);
        }

        [HttpPut(ApiRoutes.Funds.Criterias.Edit)]
        public async Task<IActionResult> EditAsync([FromRoute] Guid fundId, [FromRoute] Guid criteriaId, [FromBody] AddEditFundCriteriaRequest request)
        {
            request.UserId = UserId;
            request.FundId = fundId;
            request.CriteriaId = criteriaId;

            return await _mediator.Send(request);
        }

        [HttpDelete(ApiRoutes.Funds.Criterias.Delete)]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid fundId, [FromRoute] Guid criteriaId)
        {
            var request = new DeleteFundCriteriaRequest
            {
                UserId = UserId,
                FundId = fundId,
                CriteriaId = criteriaId,
            };

            return await _mediator.Send(request);
        }
    }
}
