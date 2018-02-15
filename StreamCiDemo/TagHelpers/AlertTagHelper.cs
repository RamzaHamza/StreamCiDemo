using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StreamCiDemo.TagHelpers
{



	public class AlertTagHelper : TagHelper
	{

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{

			output.TagName = "div";
			output.AddClass("alert alert-danger");
			output.Attributes.Add("role", "alert");

			base.Process(context, output);
		}

	}

	public class HeadTagHelper : TagHelper
	{

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{

			output.Content.AppendHtml("<link rel='stylesheet' href='https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.7/css/bootstrap.min.css' />");

			base.Process(context, output);
		}



	}


}
