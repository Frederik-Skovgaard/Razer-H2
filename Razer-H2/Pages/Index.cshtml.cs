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

        public void OnGet()
        {
            ToDos = _doRepository.ReadAllToDo();
            ToDos = ToDos.Where(x => x.IsCompleted == false).ToList();
        }

        //---------------Edit-----------------
        [BindProperty]
        public List<Guid> IsChecked { get; set; }


        public IActionResult OnPostIsChecked()
        {
            ToDos = _doRepository.ReadAllToDo();

            foreach (var item in IsChecked)
            {
                ToDo to = _doRepository.FindToDo(item);
                to.IsCompleted = true;
               _doRepository.UpdateToDo(to);
            } 

            ToDos = ToDos.Where(x => x.IsCompleted == false).ToList();

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostEdit()
        {



            ToDos = ToDos.Where(x => x.IsCompleted == false).ToList();

            return RedirectToPage("/Index");
        }

        //---------------Add-----------------
        [BindProperty, Required, MaxLength(24)]
        public string TextDescrip { get; set; }

        [BindProperty]
        public Priority RadioPriority { get; set; }

        public Array PriorityList => Enum.GetValues(typeof(Priority));

        public IActionResult OnPostAdd()
        {
            ToDo todo = new ToDo(TextDescrip, RadioPriority);

            _doRepository.CreateToDo(todo);
            return RedirectToPage("/Index");
        }


        //---------------Delete-----------------
        public IActionResult OnPostDelete(Guid id)
        {
            ToDo todo = _doRepository.FindToDo(id);
            _doRepository.DeleteToDo(todo);

            ToDos = ToDos.Where(x => x.IsCompleted == false).ToList();

            return RedirectToPage("/Index");
        }
    }
}
