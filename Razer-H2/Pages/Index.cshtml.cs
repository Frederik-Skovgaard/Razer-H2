using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public IList<ToDo> toDos { get; set; }

        public void OnGet()
        {
            toDos = _doRepository.ReadAllToDo();
        }


        [BindProperty]
        public ToDo Todo { get; set; }


        [BindProperty, Required, MaxLength(24)]
        public string TextDescrip { get; set; }

        [BindProperty]
        public Priority RadioPriority { get; set; }

        public Array PriorityList => Enum.GetValues(typeof(Priority));


        public IActionResult OnPostAdd()
        {
            Todo.TaskDescription = TextDescrip;
            Todo.Priority = RadioPriority;

            _doRepository.CreateToDo(Todo);
            return RedirectToPage("/Index");
        }

    }
}
