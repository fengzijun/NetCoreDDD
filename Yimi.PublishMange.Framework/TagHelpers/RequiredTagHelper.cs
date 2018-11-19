﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Yimi.PublishManage.Framework.TagHelpers
{
    [HtmlTargetElement("Yimi-required")]
    public class RequiredTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "required");
            output.Content.SetContent("*");
        }
    }
}