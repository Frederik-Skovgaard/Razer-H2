using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Razer_H2.Modul;
using Razer_H2.Repository;

namespace Razer_H2.Pages
{
    public class IndexModel : PageModel
    {
        public ToDoRepository doRepository = new ToDoRepository();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        
        public void OnPost()
        {
            ToDo toDo = new ToDo("TaDa");
            doRepository.CreateToDo(toDo);
        }

        public void OnGet()
        {
            
        }
    }
}
