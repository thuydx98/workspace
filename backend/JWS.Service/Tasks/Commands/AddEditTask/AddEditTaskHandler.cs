using JWS.Common.ApiResponse;
using JWS.Common.ApiResponse.ErrorResult;
using JWS.Contracts.EntityFramework;
using JWS.Data.Entities;
using JWS.Service.Tasks.ViewModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JWS.Service.Tasks.Commands.AddEditTask
{
    public class AddEditTaskHandler : IRequestHandler<AddEditTaskRequest, ApiResult>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddEditTaskHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResult> Handle(AddEditTaskRequest request, CancellationToken cancellationToken)
        {
            TaskEntity task = null;
            if (request.Id.HasValue)
            {
                task = await _unitOfWork.GetRepository<TaskEntity>().SingleOrDefaultAsync(
                    predicate: n => n.Id == request.Id && n.UserId == request.UserId,
                    cancellationToken: cancellationToken);

                if (task == null)
                {
                    return ApiResult.Failed(HttpCode.Notfound);
                }
            }

            task ??= new TaskEntity();
            task.UserId = request.UserId.Value;
            task.Title = request.Title;
            task.Content = request.Content;
            task.At = request.At;
            task.IsPriority = request.IsPriority;
            task.IsCompleted = request.IsCompleted;

            if (request.Id.HasValue)
            {
                _unitOfWork.GetRepository<TaskEntity>().Update(task);
            }
            else
            {
                _unitOfWork.GetRepository<TaskEntity>().Insert(task);
            }

            await _unitOfWork.CommitAsync();

            return ApiResult.Succeeded(new TaskViewModel(task));
        }
    }
}
