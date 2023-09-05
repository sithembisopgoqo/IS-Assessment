using ISBank_Assessment.UI.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Xml.Linq;

namespace ISBank_Assessment.UI.HtmlHelpers
{
    public static class HtmlHelperExtensions
    {
        static object GetModelStateValue(HtmlHelper htmlHelper, string key, Type destinationType)
        {
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(key, out modelState))
            {
                if (modelState.Value != null)
                {
                    return modelState.Value.ConvertTo(destinationType, null /* culture */);
                }
            }
            return null;
        }

        public static MvcHtmlString DropDownListWithItemAttributesFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItemWithAttributes> selectList, string optionLabel, object htmlAttributes)
        {
            string name = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));

            var selectDoc = XDocument.Parse(htmlHelper.DropDownListFor(expression, (IEnumerable<SelectListItem>)selectList, optionLabel, htmlAttributes).ToString());

            var options = from XElement el in selectDoc.Element("select").Descendants()
                          select el;

            for (int i = 0; i < options.Count(); i++)
            {
                var option = options.ElementAt(i);
                //this check is done to cater for optionLabel
                if (i - 1 >= 0)
                {
                    var attributes = selectList.ElementAt(i - 1);
                    foreach (var attribute in attributes.HtmlAttributes)
                    {
                        option.SetAttributeValue(attribute.Key, attribute.Value);
                    }
                }
            }

            selectDoc.Root.ReplaceNodes(options.ToArray());
            return MvcHtmlString.Create(selectDoc.ToString());
        }

        public static MvcHtmlString DropDownListWithItemAttributesFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItemWithAttributes> selectList, object htmlAttributes)
        {
            string name = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));

            var selectDoc = XDocument.Parse(htmlHelper.DropDownListFor(expression, (IEnumerable<SelectListItem>)selectList, htmlAttributes).ToString());

            var options = from XElement el in selectDoc.Element("select").Descendants()
                          select el;

            for (int i = 0; i < options.Count(); i++)
            {
                var option = options.ElementAt(i);
                var attributes = selectList.ElementAt(i);

                foreach (var attribute in attributes.HtmlAttributes)
                {
                    option.SetAttributeValue(attribute.Key, attribute.Value);
                }
            }

            selectDoc.Root.ReplaceNodes(options.ToArray());
            return MvcHtmlString.Create(selectDoc.ToString());
        }

        public static MvcHtmlString ExtendedDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IEnumerable<SelectListItem> selectList, object htmlAttributes)
        {
            return SelectInternal(htmlHelper, null /* optionLabel */, ExpressionHelper.GetExpressionText(expression), selectList, false /* allowMultiple */, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        private static MvcHtmlString SelectInternal(this HtmlHelper htmlHelper, string optionLabel, string name, IEnumerable<SelectListItem> selectList, bool allowMultiple, IDictionary<string, object> htmlAttributes)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
                throw new ArgumentException("No name");

            if (selectList == null)
                throw new ArgumentException("No selectlist");

            object defaultValue = (allowMultiple) ? GetModelStateValue(htmlHelper, fullName, typeof(string[])) : GetModelStateValue(htmlHelper, fullName, typeof(string));

            // If we haven't already used ViewData to get the entire list of items then we need to
            // use the ViewData-supplied value before using the parameter-supplied value.
            if (defaultValue == null)
                defaultValue = htmlHelper.ViewData.Eval(fullName);

            if (defaultValue != null)
            {
                IEnumerable defaultValues = (allowMultiple) ? defaultValue as IEnumerable : new[] { defaultValue };
                IEnumerable<string> values = from object value in defaultValues select Convert.ToString(value, CultureInfo.CurrentCulture);
                HashSet<string> selectedValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
                List<SelectListItem> newSelectList = new List<SelectListItem>();

                foreach (SelectListItem item in selectList)
                {
                    item.Selected = (item.Value != null) ? selectedValues.Contains(item.Value) : selectedValues.Contains(item.Text);
                    newSelectList.Add(item);
                }
                selectList = newSelectList;
            }

            // Convert each ListItem to an <option> tag
            StringBuilder listItemBuilder = new StringBuilder();

            // Make optionLabel the first item that gets rendered.
            if (optionLabel != null)
                listItemBuilder.Append(ListItemToOption(new SelectListItem() { Text = optionLabel, Value = String.Empty, Selected = false }));

            foreach (SelectListItem item in selectList)
            {
                listItemBuilder.Append(ListItemToOption(item));
            }

            TagBuilder tagBuilder = new TagBuilder("select")
            {
                InnerHtml = listItemBuilder.ToString()
            };
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("name", fullName, true /* replaceExisting */);
            tagBuilder.GenerateId(fullName);
            if (allowMultiple)
                tagBuilder.MergeAttribute("multiple", "multiple");

            // If there are any errors for a named field, we add the css attribute.
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    tagBuilder.AddCssClass(HtmlHelper.ValidationInputCssClassName);
                }
            }

            tagBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name));

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        internal static string ListItemToOption(SelectListItem item)
        {
            TagBuilder builder = new TagBuilder("option")
            {
                InnerHtml = HttpUtility.HtmlEncode(item.Text)
            };
            if (item.Value != null)
            {
                builder.Attributes["value"] = item.Value;
            }
            if (item.Selected)
            {
                builder.Attributes["selected"] = "selected";
            }

            //foreach (var property in StringProperties(item))
            //{
            //    if (property.Key.ToLower() != "text" && property.Key.ToLower() != "Value" && property.Key.ToLower() != "Selected")
            //    {
            //        builder.Attributes[property.Key] = property.Value;
            //    }

            //}


            //builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(item.htmlAttributes));
            return builder.ToString(TagRenderMode.Normal);
        }

        internal static IEnumerable<KeyValuePair<string, string>> StringProperties(object obj)
        {
            return from p in obj.GetType().GetProperties()
                   select new KeyValuePair<string, string>(p.Name, p.GetValue(obj).ToString());
        }


    }
}