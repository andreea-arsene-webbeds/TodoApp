using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Shared.Entities;

namespace TodoApp.DataAccess.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoEntity>> Get();

        Task<TodoEntity> GetById(Guid todoId);

        TodoEntity Add(TodoEntity todo);

        Task Delete(Guid todoId);

        void Update(TodoEntity todo);

        Task Save();
    }
}
