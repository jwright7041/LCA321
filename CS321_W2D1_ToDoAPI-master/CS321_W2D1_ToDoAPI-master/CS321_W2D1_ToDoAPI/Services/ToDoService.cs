using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W2D1_ToDoAPI.Models;

namespace CS321_W2D1_ToDoAPI.Services
{
    public class ToDoService : IToDoService
    {
        // seed some initial ToDo data
        private List<ToDo> _todos = new List<ToDo>()
        {
            new ToDo
            {
                Id = 1,
                Description = "My first todo",
                IsComplete = false
            },
            new ToDo
            {
                Id = 2,
                Description = "My second todo",
                IsComplete = false
            }
        };
        // keep track of next id number
        private int _nextId = 3;

        public ToDo Add(ToDo todo)
        {
            //throw new ApplicationException("Adding ToDos is not available at this time.");
            // assign an id (and then increment _nextId for next time)
            todo.Id = _nextId++;
            // store in the list of ToDos
            _todos.Add(todo);
            // return the new ToDo with Id filled in
            return todo;
        }

        public ToDo Get(int id)
        {
            // return the specified ToDo or null if not found
            return _todos.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _todos;
        }

        public ToDo Update(ToDo updatedToDo)
        {
            // get the ToDo object in the current list with this id 
            var currentToDo = this.Get(updatedToDo.Id);

            // return null if todo to update isn't found
            if (currentToDo == null) return null;

            // copy the property values from the updated ToDo into the current todo object
            currentToDo.Description = updatedToDo.Description;
            currentToDo.IsComplete = updatedToDo.IsComplete;

            return currentToDo;
        }

        public void Remove(ToDo todo)
        {
            _todos.Remove(todo);
        }

    }
}
