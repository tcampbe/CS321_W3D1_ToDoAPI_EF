using System.Collections.Generic;
using CS321_W3D1_ToDoAPI_EF.Data;
using CS321_W3D1_ToDoAPI_EF.Models;

namespace CS321_W3D1_ToDoAPI_EF.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _todoRepo;

        public ToDoService(IToDoRepository todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public ToDo Add(ToDo todo)
        {
            // store in the list of ToDos
            _todoRepo.Add(todo);
            // return the new ToDo with Id filled in
            return todo;
        }

        public ToDo Get(int id)
        {
            // return the specified ToDo or null if not found
            return _todoRepo.Get(id);
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _todoRepo.GetAll();
        }

        public ToDo Update(ToDo updatedToDo)
        {
            // get the ToDo object in the current list with this id 
            var currentToDo = _todoRepo.Get(updatedToDo.Id);

            // return null if todo to update isn't found
            if (currentToDo == null) return null;

            // update the todo
            _todoRepo.Update(currentToDo);

            return currentToDo;
        }

        public void Remove(ToDo todo)
        {
            _todoRepo.Remove(todo);
        }

    }
}
