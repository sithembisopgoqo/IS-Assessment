using ISBank_Assessment.UI.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.WebPages;

namespace ISBank_Assessment.UI.HtmlHelpers
{
    public static class WebGridExtensions
    {
        public static HelperResult PagerList(
            this WebGrid webGrid,
            WebGridPagerModes mode = WebGridPagerModes.NextPrevious | WebGridPagerModes.Numeric,
            string firstText = null,
            string previousText = null,
            string nextText = null,
            string lastText = null,
            int numericLinksCount = 5,
            string paginationStyle = null)
        {
            return PagerList(webGrid, mode, firstText, previousText, nextText, lastText, numericLinksCount, paginationStyle, explicitlyCalled: true);
        }

        private static HelperResult PagerList(
            WebGrid webGrid,
            WebGridPagerModes mode,
            string firstText,
            string previousText,
            string nextText,
            string lastText,
            int numericLinksCount,
            string paginationStyle,
            bool explicitlyCalled)
        {

            int currentPage = webGrid.PageIndex;
            int totalPages = webGrid.PageCount;
            int lastPage = totalPages - 1;

            var ul = new TagBuilder("ul");
            ul.AddCssClass(paginationStyle);

            var li = new List<TagBuilder>();

            if (webGrid.TotalRowCount <= webGrid.PageCount)
            {
                return new HelperResult(writer =>
                {
                    writer.Write(string.Empty);
                });
            }

            if (ModeEnabled(mode, WebGridPagerModes.FirstLast))
            {
                if (string.IsNullOrEmpty(firstText))
                {
                    firstText = "First";
                }

                var part = new TagBuilder("li")
                {
                    InnerHtml = GridLink(webGrid, webGrid.GetPageUrl(0), firstText)
                };

                if (currentPage == 0)
                {
                    part.MergeAttribute("class", "disabled");
                }

                li.Add(part);

            }

            if (ModeEnabled(mode, WebGridPagerModes.NextPrevious))
            {
                if (string.IsNullOrEmpty(previousText))
                {
                    previousText = "Prev";
                }

                int page = currentPage == 0 ? 0 : currentPage - 1;

                var part = new TagBuilder("li")
                {
                    InnerHtml = GridLink(webGrid, webGrid.GetPageUrl(page), previousText)
                };

                if (currentPage == 0)
                {
                    part.MergeAttribute("class", "disabled");
                }

                li.Add(part);

            }


            if (ModeEnabled(mode, WebGridPagerModes.Numeric) && (totalPages > 1))
            {
                int last = currentPage + (numericLinksCount / 2);
                int first = last - numericLinksCount + 1;
                if (last > lastPage)
                {
                    first -= last - lastPage;
                    last = lastPage;
                }
                if (first < 0)
                {
                    last = Math.Min(last + (0 - first), lastPage);
                    first = 0;
                }
                for (int i = first; i <= last; i++)
                {

                    var pageText = (i + 1).ToString(CultureInfo.InvariantCulture);
                    var part = new TagBuilder("li")
                    {
                        InnerHtml = GridLink(webGrid, webGrid.GetPageUrl(i), pageText)
                    };

                    if (i == currentPage)
                    {
                        part.MergeAttribute("class", "active");
                    }

                    li.Add(part);

                }
            }

            if (ModeEnabled(mode, WebGridPagerModes.NextPrevious))
            {
                if (string.IsNullOrEmpty(nextText))
                {
                    nextText = "Next";
                }

                int page = currentPage == lastPage ? lastPage : currentPage + 1;

                var part = new TagBuilder("li")
                {
                    InnerHtml = GridLink(webGrid, webGrid.GetPageUrl(page), nextText)
                };

                if (currentPage == lastPage)
                {
                    part.MergeAttribute("class", "disabled");
                }

                li.Add(part);

            }

            if (ModeEnabled(mode, WebGridPagerModes.FirstLast))
            {
                if (string.IsNullOrEmpty(lastText))
                {
                    lastText = "Last";
                }

                var part = new TagBuilder("li")
                {
                    InnerHtml = GridLink(webGrid, webGrid.GetPageUrl(lastPage), lastText)
                };

                if (currentPage == lastPage)
                {
                    part.MergeAttribute("class", "disabled");
                }

                li.Add(part);

            }

            ul.InnerHtml = string.Join("", li);

            var html = "";
            if (explicitlyCalled && webGrid.IsAjaxEnabled)
            {
                var span = new TagBuilder("span");
                span.MergeAttribute("data-swhgajax", "true");
                span.MergeAttribute("data-swhgcontainer", webGrid.AjaxUpdateContainerId);
                span.MergeAttribute("data-swhgcallback", webGrid.AjaxUpdateCallback);

                span.InnerHtml = ul.ToString();
                html = span.ToString();

            }
            else
            {
                html = ul.ToString();
            }

            return new HelperResult(writer =>
            {
                writer.Write(html);
            });
        }

        private static string GridLink(WebGrid webGrid, string url, string text)
        {
            TagBuilder builder = new TagBuilder("a");
            builder.SetInnerText(text);
            builder.MergeAttribute("href", url);
            if (webGrid.IsAjaxEnabled)
            {
                builder.MergeAttribute("data-swhglnk", "true");
            }
            return builder.ToString(TagRenderMode.Normal);
        }


        private static bool ModeEnabled(WebGridPagerModes mode, WebGridPagerModes modeCheck)
        {
            return (mode & modeCheck) == modeCheck;
        }

        public static IHtmlString GetHtmlWithSelectAllCheckBox(
               this WebGrid webGrid,
               string tableStyle = null,
               string headerStyle = null,
               string footerStyle = null,
               string rowStyle = null,
               string alternatingRowStyle = null,
               string selectedRowStyle = null,
               string caption = null,
               bool displayHeader = true,
               bool fillEmptyRows = false,
               string emptyRowCellValue = null,
               IEnumerable<WebGridColumn> columns = null,
               IEnumerable<string> exclusions = null,
               WebGridPagerModes mode = WebGridPagerModes.All,
               string firstText = null, string previousText = null,
               string nextText = null,
               string lastText = null, int numericLinksCount = 0,
               object htmlAttributes = null,
               string checkBoxValue = "ID",
               string isDisabled = null,
               string isChecked = null,
               string gridNumber = "")
        {
            var newColumn = webGrid.Column(header: "{}", columnName: "", style: "", format: item => new HelperResult(

                                writer =>
                                {
                                    StringBuilder sb = new StringBuilder();
                                    sb.Append("<input class=\"singleCheckBox");
                                    sb.Append(gridNumber);
                                    sb.Append("\" id=\"");
                                    sb.Append(item.Value.GetType().GetProperty(checkBoxValue).GetValue(item.Value, null).ToString());
                                    sb.Append("\" name=\"selectedRows\" value=\"");
                                    sb.Append(item.Value.GetType().GetProperty(checkBoxValue).GetValue(item.Value, null).ToString());
                                    sb.Append("\"");

                                    if (!string.IsNullOrEmpty(isDisabled) && item.Value.GetType().GetProperty(isDisabled).GetValue(item.Value, null) != null)
                                    {
                                        if (bool.Parse(item.Value.GetType().GetProperty(isDisabled).GetValue(item.Value, null).ToString()))
                                        {
                                            sb.Append(" disabled=\"disabled\"");
                                        }
                                    }

                                    if (!string.IsNullOrEmpty(isChecked) && item.Value.GetType().GetProperty(isChecked).GetValue(item.Value, null) != null)
                                    {
                                        if (bool.Parse(item.Value.GetType().GetProperty(isChecked).GetValue(item.Value, null).ToString()))
                                        {
                                            sb.Append(" checked=\"checked\"");
                                        }
                                    }

                                    sb.Append(" type=\"checkbox\" />");

                                    writer.Write(sb);
                                }));

            var newColumns = columns.ToList();

            newColumns.Insert(0, newColumn);

            var script = @"<script>

                if (typeof jQuery == 'undefined')
                {
                    document.write(

                        unescape(
                        ""%3Cscript src='http://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js'%3E%3C/script%3E""
                        )
                     );
                }

                (function(){
                    window.setTimeout(function() { initializeCheckBoxes();  }, 1000);
                    

                    function initializeCheckBoxes(){
                        $(function () {
                            var checkboxValues{#} = JSON.parse(localStorage.getItem('checkboxValues{#}')) || {};
                            var $checkboxes = $('.gridtable{#} :checkbox');

                            $.each(checkboxValues{#}, function(key, value) {
                              $('#' + key).prop('checked', value);
                            });
                            
                            $('#allCheckBox{#}').on('click',function () {
                                var isChecked = $(this).prop('checked');                              

                                $('.singleCheckBox').each(function(i, obj) {
                                    var checkbox = $(this);
                                    if (!checkbox.prop('disabled')) {
                                        checkbox.prop('checked', isChecked ? true : false);                                        
                                    }
                                });

                                $('.singleCheckBox{#}').closest('tr').addClass(isChecked  ? 'selected-row{#}': 'not-selected-row{#}');

                                $('.singleCheckBox{#}').closest('tr').removeClass(isChecked  ? 'not-selected-row{#}': 'selected-row{#}');                                

                                $checkboxes.each(function(){ 
                                    if(this.checked && this.id != 'allCheckBox{#}')
                                    {
                                        checkboxValues{#}[this.id] = this.checked;
                                    } 
                                    else
                                    {
                                       RemoveCheckBoxItemFromStorage(this.id) 
                                    }                                    
                                });
                                localStorage.setItem('checkboxValues{#}', JSON.stringify(checkboxValues{#}));
                            });

                            $('.singleCheckBox{#}').on('click',function () {
                                var isChecked = $(this).prop('checked');

                                $(this).closest('tr').addClass(isChecked  ? 'selected-row{#}': 'not-selected-row{#}');

                                $(this).closest('tr').removeClass(isChecked  ? 'not-selected-row{#}': 'selected-row{#}');

                                if(isChecked && $('.singleCheckBox{#}').length == $('.selected-row{#}').length)
                                {
                                     $('#allCheckBox{#}').prop('checked',true);
                                }
                                else                                        
                                {
                                    $('#allCheckBox{#}').prop('checked',false);
                                    
                                }
                                
                                if(this.checked && this.id != 'allCheckBox{#}')
                                {
                                checkboxValues{#}[this.id] = this.checked;
                                } 
                                else
                                {
                                   RemoveCheckBoxItemFromStorage(this.id) 
                                }             
                                localStorage.setItem('checkboxValues{#}', JSON.stringify(checkboxValues{#}));
                            });

                        function persistCheckBoxes()
                        {       
                            $checkboxes.on('change', function(){
                         
                                if(this.checked && this.id != 'allCheckBox{#}')
                                {
                                checkboxValues{#}[this.id] = this.checked;
                                } 
                                else
                                {
                                   RemoveCheckBoxItemFromStorage(this.id) 
                                }             
                                localStorage.setItem('checkboxValues{#}', JSON.stringify(checkboxValues{#}));
                            });
                         }

                     function persistAllCheckBoxes()
                    {       
                        $checkboxes.on('change', function(){
                         $checkboxes.each(function(){                                  
                                    if(this.checked && this.id != 'allCheckBox{#}')
                                    {
                                    checkboxValues{#}[this.id] = this.checked;
                                    } 
                                    else
                                    {
                                       RemoveCheckBoxItemFromStorage(this.id) 
                                    }                                 
                            });
                            localStorage.setItem('checkboxValues{#}', JSON.stringify(checkboxValues{#}));
                        });
                     }

                    function RemoveCheckBoxItemFromStorage(id)
                    {       
                        checkboxValues{#} = JSON.parse(localStorage.getItem('checkboxValues{#}'));
                        
                        //remove item selected, second parameter is the number of items to delete 
                        delete checkboxValues{#}[id];
                            
                        // Put the object into storage
                        localStorage.setItem('checkboxValues{#}', JSON.stringify(checkboxValues{#}));
                    }    
                      
                    
                    
                    });
                    }

                    

                })();

            </script>";

            script = script.Replace("{#}", gridNumber);

            var html = webGrid.GetHtml(tableStyle, headerStyle, footerStyle, rowStyle, alternatingRowStyle, selectedRowStyle, caption,
                                       displayHeader, fillEmptyRows, emptyRowCellValue, newColumns, exclusions, mode, firstText, previousText,
                                       nextText, lastText, numericLinksCount, htmlAttributes);

            return MvcHtmlString.Create(html.ToString().Replace("{}",
                "<input type='checkbox' id='allCheckBox" + gridNumber + "' value = " + Labels.All + ">") + script);
        }
    }
}