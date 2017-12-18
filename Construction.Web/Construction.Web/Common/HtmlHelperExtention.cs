
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Construction.Web.Common
{
    public static class HtmlHelperExtention
    {
        public static MvcHtmlString CustomDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> Expression, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
        {
            
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression<TModel, TProperty>(Expression, htmlHelper.ViewData);
            string name = ExpressionHelper.GetExpressionText((LambdaExpression)Expression);
            return CustomDropdownList(htmlHelper, metadata, name, optionLabel, selectList, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        private static MvcHtmlString CustomDropdownList(this HtmlHelper htmlHelper, ModelMetadata metadata, string name, string optionLabel, IEnumerable<SelectListItem> list, IDictionary<string, object> htmlAttributes)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
           
            TagBuilder dropdown = new TagBuilder("select");
            dropdown.Attributes.Add("name", fullName);
            dropdown.MergeAttributes(htmlAttributes); //dropdown.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            dropdown.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name, metadata));

            StringBuilder options = new StringBuilder();

            // Make optionLabel the first item that gets rendered.
            if (optionLabel != null)
                options.Append("<option value='" + String.Empty + "'>" + optionLabel + "</option>");

            foreach (var item in list)
            {
                if (item.Selected == true)
                    options.Append("<option value='" + item.Value + "' selected>" + item.Text + "</option>");
                else
                    options.Append("<option value='" + item.Value + "'>" + item.Text + "</option>");
            }
            dropdown.InnerHtml = options.ToString();
            return MvcHtmlString.Create(dropdown.ToString(TagRenderMode.Normal));
        }
    }
}