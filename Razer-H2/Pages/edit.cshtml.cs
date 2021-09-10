using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [BindProperty]
        public ToDo ToDo { get; set; }

        public IActionResult OnGet(Guid id)
        {
            ToDo = doRepository.FindToDo(id);

            if (ToDo == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}
