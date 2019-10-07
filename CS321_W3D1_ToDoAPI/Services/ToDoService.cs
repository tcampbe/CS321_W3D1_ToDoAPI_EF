using System.Collections.Generic;
using System.Linq;
using CS321_W3D1_ToDoAPI_EF.Models;
using CS321_W3D1_ToDoAPI_EF.Data;

namespace CS321_W3D1_ToDoAPI_EF.Services
{
    public class ToDoService : IToDoService
    {

        private readonly ToDoContext _todoContext;

        public ToDoService(ToDoContext toDoContext /* TODO: add a parameter so ToDoContext can be injected */)
        {
            _todoContext = toDoContext;
            // TODO: keep a reference to the ToDoContext in _todoContext
        }

        public ToDo Add(ToDo todo)
        {
            // NOTE: This method is already completed for your reference. 
            // Note how _todoContext is used.

            // store in the list of ToDos
            _todoContext.ToDos.Add(todo);
            _todoContext.SaveChanges();

            // return the new ToDo with Id filled in
            return todo;
        }

        public ToDo Get(int id)
        {
            // TODO: return the specified ToDo using Find()
            return _todoContext.ToDos.Find(id);
        }

        public IEnumerable<ToDo> GetAll()
        {
            // TODO: return all ToDos using ToList()
            return _todoContext.ToDos.ToList();
        }

        public ToDo Update(ToDo updatedToDo)
        {
            // get the ToDo object in the current list with this id 
            var currentToDo = _todoContext.ToDos.Find(updatedToDo.Id);

            // return null if todo to update isn't found
            if (currentToDo == null) return null;

            // NOTE: This method is already completed for you, but note
            // how the property values are copied below.

            // copy the property values from the changed todo into the
            // one in the db. NOTE that this is much simpler than individually
            // copying each property.
            _todoContext.Entry(currentToDo)
                .CurrentValues
                .SetValues(updatedToDo);

            // update the todo and save
            _todoContext.ToDos.Update(currentToDo);
            _todoContext.SaveChanges();
            return currentToDo;
        }

        public void Remove(ToDo todo)
        {
            _todoContext.ToDos.Remove(todo);
            // TODO: remove the todo
            _todoContext.SaveChanges();
        }

    }
}
