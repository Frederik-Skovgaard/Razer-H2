using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        //---------------Get-----------------
        [BindProperty]
        public IList<ToDo> ToDos { get; set; }

        //---------------Add-----------------
        [BindProperty, Required, MaxLength(24)]
        public string TextDescrip { get; set; }

        [BindProperty]
        public Priority RadioPriority { get; set; }

        public Array PriorityList => Enum.GetValues(typeof(Priority));

        //---------------Edit-----------------
        [BindProperty]
        public List<Guid> IsChecked { get; set; }

        [BindProperty]
        public Priority ToPriority { get; set; }

        [BindProperty]
        public ToDo Todo { get; set; }



        /// <summary>
        /// on startup load list
        /// </summary>
        public void OnGet()
        {
            ToDos = _doRepository.ReadAllToDo();

            ToDos = ToDos.Where(x => x.IsCompleted == false).ToList();
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

            ToDos = _doRepository.ReadAllToDo();
            ToDos = ToDos.Where(x => x.IsCompleted == false).ToList();

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
            todo.Priority = RadioPriority;

            _doRepository.CreateToDo(todo);

            ToDos = _doRepository.ReadAllToDo();
            ToDos = ToDos.Where(x => x.IsCompleted == false).ToList();

            return RedirectToPage("/Index");
        }

        /// <summary>
        /// Delete Todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult OnPostDelete(Guid id)
        {
            ToDo todo = _doRepository.FindToDo(id);
            _doRepository.DeleteToDo(todo);

            ToDos = _doRepository.ReadAllToDo();

            ToDos = ToDos.Where(x => x.IsCompleted == false).ToList();

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostLoad()
        {
            ToDos = _doRepository.ReadAllToDo();
            ToDos = ToDos.Where(x => x.IsCompleted == true).ToList();

            return Page();
        }

    }
}
