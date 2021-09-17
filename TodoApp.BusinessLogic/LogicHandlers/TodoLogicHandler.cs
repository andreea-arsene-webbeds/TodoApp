using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApp.DataAccess.Repositories;
using TodoApp.Shared;
using TodoApp.Shared.Entities;
using TodoApp.Shared.Models;

namespace TodoApp.BusinessLogic.LogicHandlers
{
    public class TodoLogicHandler : ITodoLogicHandler
    {
        private readonly ITodoRepository _todoRepository;
        private readonly IMapper _mapper;

        public TodoLogicHandler(ITodoRepository todoRepository, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _mapper = mapper;
        }
        public async Task<Response<TodoModel>> Add(TodoModel todo)
        {
            try
            {
                TodoEntity todoEntity = _mapper.Map<TodoEntity>(todo);

                TodoModel added = _mapper.Map<TodoModel>(_todoRepository.Add(todoEntity));

                await _todoRepository.Save();

                var response = new Response<TodoModel>
                {
                    StatusCode = 201,
                    Data = added,
                    ErrorMessage = null
                };

                return response;

            }
            catch (Exception e)
            {
                var response = new Response<TodoModel>
                {
                    StatusCode = 503,
                    Data = null,
                    ErrorMessage = e.Message
                };

                return response;
            }
        }

        public async Task<Response<TodoModel>> Delete(Guid todoId)
        {
            try
            {
                await _todoRepository.Delete(todoId);

                await _todoRepository.Save();

                var response = new Response<TodoModel>
                {
                    StatusCode = 204,
                    Data = null,
                    ErrorMessage = null
                };

                return response;

            }
            catch (Exception e)
            {
                var response = new Response<TodoModel>
                {
                    StatusCode = 503,
                    Data = null,
                    ErrorMessage = e.Message
                };

                return response;
            }
        }

        public async Task<Response<List<TodoModel>>> Get()
        {
            try
            {
                IEnumerable<TodoEntity> todos = await _todoRepository.Get();

                List<TodoModel> result = _mapper.Map<List<TodoModel>>(todos);

                var response = new Response<List<TodoModel>>
                {
                    StatusCode = 200,
                    Data = result,
                    ErrorMessage = null
                };

                return response;

            }
            catch (Exception e)
            {
                var response = new Response<List<TodoModel>>
                {
                    StatusCode = 500,
                    Data = null,
                    ErrorMessage = e.Message
                };

                return response;
            }
        }

        public async Task<Response<TodoModel>> GetById(Guid todoId)
        {
            try
            {
                TodoEntity todo = await _todoRepository.GetById(todoId);

                TodoModel result = _mapper.Map<TodoModel>(todo);

                var response = new Response<TodoModel>
                {
                    StatusCode = 200,
                    Data = result,
                    ErrorMessage = null,
                };

                return response;

            }
            catch (Exception e)
            {
                var response = new Response<TodoModel>
                {
                    StatusCode = 500,
                    Data = null,
                    ErrorMessage = e.Message
                };

                return response;
            }
        }

        public async Task<Response<TodoModel>> Update(TodoModel todo)
        {
            try
            {
                TodoEntity todoEntity = _mapper.Map<TodoEntity>(todo);

                _todoRepository.Update(todoEntity);

                await _todoRepository.Save();

                var response = new Response<TodoModel>
                {
                    StatusCode = 204,
                    Data = null,
                    ErrorMessage = null
                };

                return response;

            }
            catch (Exception e)
            {
                var response = new Response<TodoModel>
                {
                    StatusCode = 503,
                    Data = null,
                    ErrorMessage = e.Message
                };

                return response;
            }
        }
    }
}
