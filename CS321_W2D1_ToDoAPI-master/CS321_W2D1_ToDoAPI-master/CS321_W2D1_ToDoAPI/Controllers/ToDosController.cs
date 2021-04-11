using CS321_W2D1_ToDoAPI.Models;
using CS321_W2D1_ToDoAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CS321_W2D1_ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase
    {
        private readonly IToDoService _todoService;

        // Constructor
        public ToDosController(IToDoService toDoService)

        {
            _todoService = toDoService;
        }

        // get all todos
        // GET api/todos
        [HttpGet]
        public IActionResult Get()
        {
            // return OK 200 status and list of todos
            return Ok(_todoService.GetAll());
        }

        // get specific todo by id
        // GET api/todos/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            // look up todo by id
            var todo = _todoService.Get(id);
            // if not found, return 404 NotFound 
            if (todo == null) return NotFound();
            // otherwise return 200 OK and the ToDo
            return Ok(todo);
        }

        // create a new todo
        // POST api/todos
        [HttpPost]
        public IActionResult Post([FromBody] ToDo newToDo)
        {
            try
            {
                // add the new todo
                _todoService.Add(newToDo);
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddToDo", ex.Message);
                return BadRequest(ModelState);
            }

            // return a 201 Created status. This will also add a "location" header
            // with the URI of the new todo. E.g., /api/todos/99, if the new is 99
            return CreatedAtAction("Get", new { Id = newToDo.Id }, newToDo);
        }

        // update an existing todo
        // PUT api/todos/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ToDo updatedToDo)
        {
            var todo = _todoService.Update(updatedToDo);
            if (todo == null) return NotFound();
            return Ok(todo);
        }

        // delete an existing todo
        // DELETE api/todos/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todo = _todoService.Get(id);
            if (todo == null) return NotFound();
            _todoService.Remove(todo);
            return NoContent();
        }
    }
}
