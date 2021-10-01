﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Razer_H2.Modul;
using Razer_H2.Repository;



namespace Razer_H2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IToDoRepository _doRepository;

        public IndexModel(IToDoRepository doRepository)
        {
            _doRepository = doRepository;
        }


        //---------------Get-----------------
        [BindProperty]
        public IList<ToDo> ToDos { get; set; }

        [BindProperty]
        public IList<Contact> Contacts { get; set; }

        //---------------Add-----------------
        [BindProperty, Required, MaxLength(24)]
        public string TextDescrip { get; set; }

        [BindProperty]
        public Priority RadioPriority { get; set; }

        public Array PriorityList => Enum.GetValues(typeof(Priority));

        //---------------Edit-----------------
        [BindProperty]
        public List<int> IsChecked { get; set; }

        [BindProperty]
        public Priority ToPriority { get; set; }

        [BindProperty]
        public ToDo Todo { get; set; }

        [BindProperty]
        public Contact Contact { get; set; }



        /// <summary>
        /// on startup load list
        /// </summary>
        public void OnGet()
        {
            Contacts = _doRepository.ReadAllContacts();
            
            ToDos = _doRepository.ReadAllToDo();
            ToDos = ToDos.Where(x => x.IsCompleted != true).OrderBy(b => b.CreatedTime).ToList();
        }

        /// <summary>
        /// If checkbox is checked change isCompleted to true
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostIsChecked()
        {
            foreach (var item in IsChecked)
            {
                ToDo to = _doRepository.FindToDo(item);
                to.IsCompleted = true;
                _doRepository.UpdateToDo(to);
            }

            return RedirectToPage("/Index");
        }


        /// <summary>
        /// Add Todo
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostAdd()
        {
            ToDo todo = new ToDo();

            todo.TaskDescription = TextDescrip;
            todo.Priority = (int)RadioPriority;

            _doRepository.CreateToDo(todo);

            return RedirectToPage("/Index");
        }

        /// <summary>
        /// Delete Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnPostDelete(int id)
        {
            ToDo todo = _doRepository.FindToDo(id);
            _doRepository.DeleteToDo(todo);


            return RedirectToPage("/Index");
        }

        public IActionResult OnPostLoad()
        {
            ToDos.Clear();

            ToDos = _doRepository.ReadAllToDo();
            ToDos = ToDos.Where(x => x.IsCompleted == true).OrderBy(b => b.CreatedTime).ToList();

            return Page();
        }

        public IActionResult OnPostBack()
        {

            return RedirectToPage("/Index");
        }

    }
}
