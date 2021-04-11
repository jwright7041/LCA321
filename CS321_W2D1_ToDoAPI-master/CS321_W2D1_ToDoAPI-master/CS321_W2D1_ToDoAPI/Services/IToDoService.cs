using System.Collections.Generic;
using CS321_W2D1_ToDoAPI.Models;

namespace CS321_W2D1_ToDoAPI.Services
{
    public interface IToDoService
    {
        // CRUDL - create (add), read (get), update, delete (remove), list

        // create
        ToDo Add(ToDo todo); 
        // read
        ToDo Get(int id);
        // update
        ToDo Update(ToDo todo); 
        // delete
        void Remove(ToDo todo);
        // list
        IEnumerable<ToDo> GetAll();
    }
}
