using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Razer_H2.Modul;


namespace Razer_H2.Repository
{
    public class ToDoRepository : IToDoRepository
    {

        public List<ToDo> ToDos => toDos;
        private List<ToDo> toDos = new List<ToDo>();

        /// <summary>
        /// Create new ToDo
        /// </summary>
        /// <param name="desc"></param>
        public void CreateToDo(string desc)
        {
            ToDo toDo = new ToDo(desc);
            toDos.Add(toDo);
        }

        /// <summary>
        /// Delete ToDo
        /// </summary>
        /// <param name="id"></param>
        public void DeleteToDo(Guid id)
        {
            ToDo obj = FindToDo(id);
            toDos.Remove(obj);
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
        public void UpdateToDo(Guid id, string desc, bool isCheck, Priority priority)
        {
            ToDo obj = FindToDo(id);

            obj.IsCompleted = isCheck;
            obj.TaskDescription = desc;
            obj.Priority = priority;
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
