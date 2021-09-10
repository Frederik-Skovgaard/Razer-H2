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
        private List<ToDo> toDos;

        public ToDoRepository()
        {
            toDos = new List<ToDo>
            {
                new ToDo{ID=Guid.NewGuid() ,Priority=Priority.Normal ,IsCompleted=false ,CreatedTime=DateTime.Now ,TaskDescription="TextDescription1"},
                new ToDo{ID=Guid.NewGuid() ,Priority=Priority.Normal ,IsCompleted=false ,CreatedTime=DateTime.Now ,TaskDescription="TextDescription2"}
            };
        }

        /// <summary>
        /// Create new ToDo
        /// </summary>
        /// <param name="desc"></param>
        public void CreateToDo(ToDo toDo)
        {
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
        public ToDo UpdateToDo(Guid id, string desc, bool isCheck, Priority priority)
        {
            ToDo obj = FindToDo(id);

            obj.IsCompleted = isCheck;
            obj.TaskDescription = desc;
            obj.Priority = priority;

            return obj;
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
