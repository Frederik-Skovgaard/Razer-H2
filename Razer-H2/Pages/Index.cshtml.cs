using System;
using System.Collections.Generic;
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

        public IActionResult OnPostAdd()
        {
            _doRepository.CreateToDo(Todo);
            return RedirectToPage("/Index");
        }

    }
}
