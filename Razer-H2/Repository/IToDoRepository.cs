using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Razer_H2.Modul;

namespace Razer_H2.Repository
{
    public interface IToDoRepository
    {
        void CreateToDo(ToDo toDo);

        void UpdateToDo(ToDo obj);

        void DeleteToDo(ToDo toDo);

        List<ToDo> ReadAllToDo();

        ToDo FindToDo(int id);

        //Contacts

        void CreateContact(Contact obj);

        void DeleteContact(Contact obj);

        List<Contact> ReadAllContacts();

        void UpdateContact(Contact obj);

    }
}
