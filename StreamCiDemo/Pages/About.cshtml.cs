using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StreamCiDemo.Pages
{
    public class AboutModel : PageModel
    {
        public string Message { get; set; }

		public DateTime dateTime { get; set; } = DateTime.Today;

        public void OnGet()
        {
            Message = "Your application description page.";
        }
    }
}
