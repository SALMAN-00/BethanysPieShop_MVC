﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BethanysPieShop.TagHelpers
{
    public class EmailTagHelper : TagHelper 
    {
        public string? Address { get; set; }
        public string? Content { get; set; }
        public override void Process (TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "a";
            output.Attributes.SetAttribute("herf", "mailto" + Address);
            output.Content.SetContent(Content);
        }


    }
}
