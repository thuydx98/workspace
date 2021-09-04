using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.Tasks.Commands.DeleteTask
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult> Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
        {
            var task = await _unitOfWork.GetRepository<TaskEntity>().SingleOrDefaultAsync(
                predicate: n => n.Id == request.Id && n.UserId == request.UserId,
                cancellationToken: cancellationToken);

            if (task == null)
            {
                return ApiResult.Failed(HttpCode.Notfound);
            }

            _unitOfWork.GetRepository<TaskEntity>().Delete(task);

            await _unitOfWork.CommitAsync();

            return ApiResult.Succeeded();
        }
    }
}
