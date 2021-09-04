using JWS.Common.ApiResponse;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.Tasks.ViewModels;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.Tasks.Queries.GetListTask
{
    public class GetListTaskHandler : IRequestHandler<GetListTaskRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetListTaskHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult> Handle(GetListTaskRequest request, CancellationToken cancellationToken)
        {
            var tasks = await _unitOfWork.GetRepository<TaskEntity>().GetListAsync(
                selector: n => new TaskViewModel(n),
                predicate: n => n.UserId == request.UserId && n.At == request.At,
                orderBy: n => n.OrderBy(o => o.IsCompleted).ThenByDescending(o => o.IsPriority),
                cancellationToken: cancellationToken);

            return ApiResult.Succeeded(tasks);
        }
    }
}
