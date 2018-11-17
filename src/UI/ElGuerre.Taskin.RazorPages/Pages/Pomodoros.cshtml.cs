// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElGuerre.Taskin.RazorPages.Pages
{
    public class PomodorosPageModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Pomodoros list";
        }
    }
}
