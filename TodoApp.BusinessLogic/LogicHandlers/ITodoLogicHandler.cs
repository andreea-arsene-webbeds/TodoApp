using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Shared;
using TodoApp.Shared.Models;

namespace TodoApp.BusinessLogic.LogicHandlers
{
    public interface ITodoLogicHandler
    {
        Task<Response<List<TodoModel>>> Get();

        Task<Response<TodoModel>> GetById(Guid todoId);

        Task<Response<TodoModel>> Add(TodoModel todo);

        Task<Response<TodoModel>> Delete(Guid todoId);

        Task<Response<TodoModel>> Update(TodoModel todo);
    }
}
