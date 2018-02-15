using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace StreamCiDemo.TagHelpers
{
	[HtmlTargetElement("datetime")]
	public class DateTimePickerTagHelper : TagHelper
	{
		private readonly IHtmlGenerator _generator;

		/// <summary>
		/// An expression to be evaluated against the current model.
		/// </summary>
		[HtmlAttributeName("asp-for")]
		public ModelExpression For { get; set; }

		[HtmlAttributeName("asp-style")]
		public DatePickerStyle Style { get; set; } = DatePickerStyle.DateTime;

		[HtmlAttributeNotBound]
		[ViewContext]
		public ViewContext ViewContext { get; set; }

		public DateTimePickerTagHelper(IHtmlGenerator generator)
		{
			_generator = generator;
		}


		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			var icon = "far fa-calendar";
			if (Style == DatePickerStyle.Time) icon = "far fa-clock";

			output.TagName = "div";

			if (context == null)
				throw new ArgumentNullException(nameof(context));
			if (output == null)
				throw new ArgumentNullException(nameof(output));
			var metadata = For.Metadata;
			var modelExplorer = For.ModelExplorer;
			if (metadata == null)
				throw new InvalidOperationException($"{nameof(metadata)} is null for {For.Name}");

			output.AddClass($"input-group {Style.ToString().ToLower()}");

			var sanitizedId = $"{TagBuilder.CreateSanitizedId(For.Name, "_")}-picker";

			output.Attributes.Add("id", sanitizedId);
			output.Attributes.Add("data-target-input", "nearest");
			var textBox = _generator.GenerateTextBox(ViewContext, modelExplorer, For.Name, modelExplorer.Model, "{0:yyyy-MM-dd}", new Dictionary<string, object>
						{
								{ "type", "text" },
								{ "class", "form-control datetimepicker-input" },
								{ "data-target", $"#{sanitizedId}" }
						});
			var span =
					// ReSharper disable once StringLiteralTypo
					$"<div class=\"input-group-append\" data-target=\"#{sanitizedId}\" data-toggle=\"datetimepicker\"> <div class=\"input-group-text\"><i class=\"{icon}\"></i></div></div>";
			string textBoxOutput;
			using (var writer = new StringWriter())
			{
				textBox.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
				textBoxOutput = writer.ToString();
			}
			output.Content.SetHtmlContent($"{textBoxOutput}{span}");
		}
	}


}
