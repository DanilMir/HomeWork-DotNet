using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WebApplication3
{
    public static class HtmlExtensions
    {
        public static string GetString(this IHtmlContent content)
        {
            using (var writer = new System.IO.StringWriter())
            {
                content.WriteTo(writer, HtmlEncoder.Default);
                return writer.ToString();
            }
        }

        public static HtmlString EditorForModelNew(this IHtmlHelper htmlHelper)
        {
            var type = htmlHelper.ViewData.ModelMetadata.ModelType;
            var properties = type.GetProperties();
            string temp = "";
            var model = type.GetConstructor(Type.EmptyTypes)?.Invoke(Array.Empty<object>());
            var formHelper = new FormHelper(htmlHelper, model);
            foreach (var varInfo in properties)
            {
                temp += formHelper.GenerateHeader(varInfo);
                temp += formHelper.GenerateBody(varInfo);
            }

            return new HtmlString(temp);
        }
    }

    public class FormHelper
    {
        
        private IHtmlHelper _htmlHelper;
        private object _model;
        
        public FormHelper(IHtmlHelper htmlHelper, object model)
        {
            _htmlHelper = htmlHelper;
            _model = model;
        }

        private bool IsAttributeExist<T>(MemberInfo prop) => Attribute.IsDefined(prop, typeof(T));
        
        public string GenerateHeader(PropertyInfo prop)
        {
            var name = IsAttributeExist<DisplayAttribute>(prop)
                ? ((DisplayAttribute) prop.GetCustomAttribute(typeof(DisplayAttribute)))?.Name :
                NameFromCamelCase(prop.Name);
            return $"<div class=\"editor-label\"><label for=\"{prop.Name}\">{name}</label></div>";
        }

        public string GenerateField(PropertyInfo prop) => $"<div class=\"editor-field\">{GenerateBody(prop)}</div>";

        private string GenerateSpan(PropertyInfo prop)
        {
            var res =
                $"<span class=\"field-validation-error\" data-valmsg-for=\"{prop.Name}\" data-valmsg-replace=\"true\">";
            var attr = (ValidationAttribute) prop.GetCustomAttribute(typeof(ValidationAttribute));
            res += !attr?.IsValid(prop.GetValue(_model))! ?? false
                ? attr.ErrorMessage! ?? attr.FormatErrorMessage(prop.Name)
                : string.Empty;
            res += "</span>";
            return res;
        }

        public string GenerateBody(PropertyInfo prop)
        {
            var res = "";
            res = prop.PropertyType.IsEnum ? 
                _htmlHelper.DropDownList(prop.Name, _htmlHelper.GetEnumSelectList(prop.PropertyType)).GetString() :
                GenerateInput(prop);
            res += GenerateSpan(prop);
            return res;
        }

        private string GenerateInput(PropertyInfo prop)
        {
            var res = prop.PropertyType == typeof(string) ? 
                $"<input class=\"text-box single-line\" type=\"text\" name=\"{prop.Name}\">" : 
                $"<input class=\"text-box single-line\" type=\"number\" name=\"{prop.Name}\">";

            return res;
        }

        private string NameFromCamelCase(string str) => Regex.Replace(str, "([A-Z])", " $1").Trim();
    }
}