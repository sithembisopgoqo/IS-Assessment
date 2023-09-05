using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ISBank_Assessment.UI.HtmlHelpers
{
    public static class LabelExtensions
    {
        public static MvcHtmlString LabelForGR<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes = null)
        {
            return LabelForGR(html, expression, new RouteValueDictionary(htmlAttributes));
        }

        public static MvcHtmlString LabelForGR<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, IDictionary<string, object> htmlAttributes)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();
            string labelDescription = "";
            if (metadata.AdditionalValues.Count > 0)
            {
                labelDescription = metadata.AdditionalValues.Where(x => x.Key == "DescriptionText").FirstOrDefault().Value.ToString();
            }

            if (string.IsNullOrEmpty(labelText))
            {
                return MvcHtmlString.Empty;
            }

            IDictionary<string, object> newHtmlAttributes = new Dictionary<string, object>();

            foreach (var item in htmlAttributes)
            {
                if (item.Key.StartsWith("data_"))
                {
                    var oldKey = item.Key;

                    newHtmlAttributes.Remove(oldKey);
                    var newKey = oldKey.Replace('_', '-');
                    newHtmlAttributes.Add(newKey, item.Value);
                }
                else
                {
                    newHtmlAttributes.Add(item.Key, item.Value);
                }
            }

            TagBuilder tag = new TagBuilder("label");
            //tag.MergeAttributes(htmlAttributes);
            tag.MergeAttributes(newHtmlAttributes);
            tag.Attributes.Add("for", html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(htmlFieldName));

            tag.MergeAttribute("data-toggle", "tooltip");
            tag.MergeAttribute("data-placement", "right");
            tag.MergeAttribute("title", labelDescription);


            if (metadata.IsRequired)
            {
                TagBuilder span = new TagBuilder("span");
                span.AddCssClass("required");

                // assign <span> to <label> inner html
                tag.InnerHtml = string.Format("{0}{1}", labelText, span.ToString(TagRenderMode.Normal));
            }
            else
            {
                tag.InnerHtml = string.Format("{0}", labelText);
            }

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.Normal));
        }
    }
}