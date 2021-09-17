using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.Shared.Entities;

namespace TodoApp.DataAccess.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly Context _context;

        public TodoRepository(Context context)
        {
            _context = context;
        }

        public TodoEntity Add(TodoEntity todo)
        {
            try
            {
                todo.Id = Guid.NewGuid();

                _context.Todos.Add(todo);

                return todo;
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(Guid todoId)
        {
            try
            {
                TodoEntity todo = await _context.Todos.FindAsync(todoId);

                _context.Todos.Remove(todo);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TodoEntity>> Get()
        {
            try
            {
                return await _context.Todos.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<TodoEntity> GetById(Guid todoId)
        {
            try
            {
                return await _context.Todos.FindAsync(todoId);
            }
            catch
            {
                throw;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(TodoEntity todo)
        {
            try
            {
                _context.Entry(todo).State = EntityState.Modified;
            }
            catch
            {
                throw;
            }
        }
    }
}
