using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Razer_H2.Modul;

namespace Razer_H2.Repository
{
    interface IToDoRepository
    {
        void CreateToDo(ToDo toDo);

        void UpdateToDo(Guid id, string desc, bool isCheck, Priority priority);

        void DeleteToDo(Guid id);

        List<ToDo> ReadAllToDo();

    }
}
