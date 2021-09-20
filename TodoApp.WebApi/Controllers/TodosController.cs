using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using TodoApp.BusinessLogic.LogicHandlers;
using TodoApp.Shared;
using TodoApp.Shared.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using System.Collections.Generic;
using System;

namespace TodoApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoLogicHandler _todoLogicHandler;

        public TodosController(ITodoLogicHandler todoLogicHandler)
        {
            _todoLogicHandler = todoLogicHandler;
        }

        [HttpPost]
        public async Task<ActionResult<TodoModel>> Post([FromBody] TodoModel newTodo)
        {
            Response<TodoModel> response = await _todoLogicHandler.Add(newTodo);

            if (response.StatusCode == (int)HttpStatusCode.Created)
            {

                return Created("todos", response.Data);
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpGet]
        public async Task<ActionResult<TodoModel>> Get()
        {

            Response<List<TodoModel>> response = await _todoLogicHandler.Get();

            if (response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                return NotFound();
            }

            else if (response.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoModel>> Get(Guid id)
        {
            Response<TodoModel> response = await _todoLogicHandler.GetById(id);

            if (response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                return NotFound();
            }

            else if (response.StatusCode == (int)HttpStatusCode.BadRequest)
            {
                return BadRequest(response.ErrorMessage);
            }

            return Ok(response.Data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(TodoModel newTodo)
        {
            Response<TodoModel> response = await _todoLogicHandler.Update(newTodo);

            if (response.StatusCode == (int)HttpStatusCode.NoContent)
            {
                return Ok(response.Data);
            }

            return BadRequest(response.ErrorMessage);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            Response<TodoModel> response = await _todoLogicHandler.Delete(id);

            if (response.StatusCode == (int)HttpStatusCode.NoContent)
            {

                return Ok(response.Data);
            }

            return BadRequest(response.ErrorMessage);
        }
    }
}
