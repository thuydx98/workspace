using JWS.Data.Entities;
using System;

namespace JWS.Service.Tasks.ViewModels
{
    public class TaskViewModel
    {
        public TaskViewModel(TaskEntity entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Content = entity.Content;
            At = entity.At;
            IsPriority = entity.IsPriority;
            IsCompleted = entity.IsCompleted;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string At { get; set; }
        public bool IsPriority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
