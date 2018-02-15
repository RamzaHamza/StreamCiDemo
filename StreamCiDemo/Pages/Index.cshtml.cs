using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StreamCiDemo.Pages
{
	public class IndexModel : PageModel
	{

		public IndexModel(IRepository repository)
		{
			this.Repository = repository;
		}

		public IRepository Repository { get; }

		public void OnGet()
		{

		}
	}
}
