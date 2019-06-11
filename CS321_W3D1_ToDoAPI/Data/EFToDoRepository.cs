using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W3D1_ToDoAPI_EF.Models;

namespace CS321_W3D1_ToDoAPI_EF.Data
{
    public class EFToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _toDoContext;

        public EFToDoRepository(ToDoContext toDoContext)
        {
            _toDoContext = toDoContext;
        }

        public ToDo Add(ToDo todo)
        {
            // store in the list of ToDos
            _toDoContext.ToDos.Add(todo);
            _toDoContext.SaveChanges();
            // return the new ToDo with Id filled in
            return todo;
        }

        public ToDo Get(int id)
        {
            // return the specified ToDo or null if not found
            return _toDoContext.ToDos.Find(id);
        }

        public IEnumerable<ToDo> GetAll()
        {
            return _toDoContext.ToDos.ToList();
        }

        public ToDo Update(ToDo updatedToDo)
        {
            // get the ToDo object in the current list with this id 
            var currentToDo = this.Get(updatedToDo.Id);

            // return null if todo to update isn't found
            if (currentToDo == null) return null;

            // copy the property values from the updated ToDo into the current todo object
            _toDoContext.Entry(currentToDo)
                .CurrentValues
                .SetValues(updatedToDo);
            // update the todo
            _toDoContext.ToDos.Update(currentToDo);
            _toDoContext.SaveChanges();

            return currentToDo;
        }

        public void Remove(ToDo todo)
        {
            _toDoContext.ToDos.Remove(todo);
            _toDoContext.SaveChanges();
        }

    }
}
