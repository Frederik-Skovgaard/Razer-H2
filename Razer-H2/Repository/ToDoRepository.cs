using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Razer_H2.Modul;


namespace Razer_H2.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private List<ToDo> toDos = new List<ToDo>();


        /// <summary>
        /// Create new ToDo
        /// </summary>
        /// <param name="desc"></param>
        public void CreateToDo(ToDo toDo)
        {
            toDo.ID = Guid.NewGuid();
            toDo.CreatedTime = DateTime.UtcNow;
            toDo.IsCompleted = false;

            toDos.Add(toDo);
        }

        /// <summary>
        /// Delete ToDo
        /// </summary>
        /// <param name="id"></param>
        public void DeleteToDo(ToDo toDo)
        {
            toDos.Remove(toDo);
        }

        /// <summary>
        /// Read all ToDo's
        /// </summary>
        public List<ToDo> ReadAllToDo()
        {
            return toDos;
        }

        /// <summary>
        /// Update ToDo
        /// </summary>
        /// <param name="id"></param>
        public void UpdateToDo(ToDo obj)
        {
            int index = toDos.FindIndex(x => x.ID == obj.ID);
            toDos[index] = obj;
        }

        /// <summary>
        /// Find ToDo with id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ToDo FindToDo(Guid id)
        {
            ToDo obj = toDos.Find(x => x.ID == id);
            return obj;
        }
    }
}
