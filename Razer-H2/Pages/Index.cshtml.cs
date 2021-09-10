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
        public readonly IToDoRepository doRepository = new ToDoRepository();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public string Message { get; set; }

        public void OnPostEdit()
        {

        }

        public void OnPostView(int id)
        {
            Message = $"{id}";
        }

        public void OnPost()
        {
            ToDo toDo = new ToDo("TaDa");
            doRepository.CreateToDo(toDo);

            ToDo toDoe = new ToDo("Biug Dick TEXTSCREEN");
            doRepository.CreateToDo(toDoe);
        }

    }
}
