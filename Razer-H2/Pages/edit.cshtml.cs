using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razer_H2.Modul;
using Razer_H2.Repository;

namespace Razer_H2.Pages
{
    public class editModel : PageModel
    {
        private readonly IToDoRepository doRepository;

        public editModel(IToDoRepository doRepository)
        {
            this.doRepository = doRepository;
        }

        [BindProperty, Required, MaxLength(24)]
        public string TextDescrip { get; set; }

        [BindProperty]
        public Priority RadioPriority { get; set; }

        public Array PriorityList => Enum.GetValues(typeof(Priority));

        [BindProperty]
        public ToDo Todo { get; set; }

        [BindProperty]
        public bool IsChecked { get; set; }

        /// <summary>
        /// On startup
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnGet(int id)
        {
            Todo = doRepository.FindToDo(id);

            if (Todo == null)
            {
                return RedirectToPage("/NotFound");
            }

            IsChecked = Todo.IsCompleted;
            TextDescrip = Todo.TaskDescription;
            RadioPriority = (Priority)Todo.Priority;

            return Page();
        }

        /// <summary>
        /// Redirect to page index
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostClose()
        {
            return RedirectToPage("/Index");
        }

        /// <summary>
        /// Save new data
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostSave(int id)
        {
            Todo.Todo_ID = id;
            Todo.TaskDescription = TextDescrip;
            Todo.Priority = (int)RadioPriority;
            Todo.IsCompleted = IsChecked;

            doRepository.UpdateToDo(Todo);

            return RedirectToPage("/Index");
        }

    }
}
