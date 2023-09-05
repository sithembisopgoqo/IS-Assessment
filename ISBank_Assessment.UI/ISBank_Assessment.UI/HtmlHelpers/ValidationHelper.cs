using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISBank_Assessment.UI.HtmlHelpers
{
    public class ValidationHelper : ValidationAttribute
    {
        public class RequiredIfDependencyValueAttribute : ValidationAttribute, IClientValidatable
        {
            public readonly object _dependencyValue;
            public readonly string _dependencyProperty;

            /// <summary>
            /// This validator passes in two parameters - its says that the property cannot be null if the passed in property (dependencyproperty) is set to passed in value (dependencyvalue)
            /// example: CreditCardNumber is required if property PaymentType is set to value "PTCC"
            /// </summary>
            /// <param name="dependencyProperty">The field the tested property is dependent on</param>
            /// <param name="dependencyValue">The value the dependent property must be set to if the tested property is required</param>
            public RequiredIfDependencyValueAttribute(string dependencyProperty, object dependencyValue)
            {
                _dependencyProperty = dependencyProperty;
                _dependencyValue = dependencyValue;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (_dependencyProperty.ToString().Contains('|'))
                {
                    bool IsValid = false;
                    List<string> dependPropList = _dependencyProperty.ToString().Split('|').ToList();
                    foreach (var propItem in dependPropList)
                    {

                        var property = validationContext.ObjectType.GetProperty(propItem);

                        if (property == null)
                        {
                            return new ValidationResult(string.Format(
                                CultureInfo.CurrentCulture,
                                "Unknown property {0}",
                                new[] { _dependencyProperty }
                            ));
                        }
                        var otherPropertyValue = property.GetValue(validationContext.ObjectInstance, null);
                        if (_dependencyValue.ToString().Contains('|'))
                        {

                            List<string> dependList = _dependencyValue.ToString().Split('|').ToList();
                            foreach (var item in dependList)
                            {
                                if (otherPropertyValue != null && (otherPropertyValue.ToString() == item as string || item as string == "%"))
                                {
                                    if (value == null || value as string == string.Empty)
                                    {
                                        IsValid = true;
                                    }
                                }
                            }

                        }
                        else if (otherPropertyValue != null && (otherPropertyValue.ToString() == _dependencyValue as string || _dependencyValue as string == "%"))
                        {
                            if (value == null || value as string == string.Empty)
                            {
                                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                            }
                        }
                    }

                    if (!IsValid)
                    {
                        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                    }
                }
                else
                {
                    var property = validationContext.ObjectType.GetProperty(_dependencyProperty);

                    if (property == null)
                    {
                        return new ValidationResult(string.Format(
                            CultureInfo.CurrentCulture,
                            "Unknown property {0}",
                            new[] { _dependencyProperty }
                        ));
                    }
                    var otherPropertyValue = property.GetValue(validationContext.ObjectInstance, null);
                    if (_dependencyValue.ToString().Contains('|'))
                    {
                        List<string> dependList = _dependencyValue.ToString().Split('|').ToList();
                        foreach (var item in dependList)
                        {
                            if (otherPropertyValue != null && (otherPropertyValue.ToString() == item as string || item as string == "%"))
                            {
                                if (value == null || value as string == string.Empty)
                                {
                                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                                }
                            }
                        }
                    }
                    else if (otherPropertyValue != null && (otherPropertyValue.ToString() == _dependencyValue as string || _dependencyValue as string == "%"))
                    {
                        if (value == null || value as string == string.Empty)
                        {
                            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                        }
                    }
                }

                return null;
            }

            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                var rule = new ModelClientValidationRule
                {
                    ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                    ValidationType = "requiredifdependencyvalue",
                };
                rule.ValidationParameters.Add("dependencyproperty", _dependencyProperty);
                rule.ValidationParameters.Add("dependencyvalue", _dependencyValue);
                yield return rule;
            }
        }

        [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
        public class UploadFileExtensionsAttribute : ValidationAttribute, IClientValidatable
        {
            private List<string> ValidExtensions { get; set; }

            public UploadFileExtensionsAttribute(string fileExtensions)
            {
                ValidExtensions = fileExtensions.Split('|').ToList();
            }

            public override bool IsValid(object value)
            {
                HttpPostedFileBase file = value as HttpPostedFileBase;
                if (file != null)
                {
                    var fileName = file.FileName;
                    var isValidExtension = ValidExtensions.Any(y => fileName.EndsWith(y));
                    return isValidExtension;
                }
                return true;
            }

            public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
            {
                var rule = new ModelClientFileExtensionValidationRule(ErrorMessage, ValidExtensions);
                yield return rule;
            }
        }

        public class ModelClientFileExtensionValidationRule : ModelClientValidationRule
        {
            public ModelClientFileExtensionValidationRule(string errorMessage, List<string> fileExtensions)
            {
                ErrorMessage = errorMessage;
                ValidationType = "fileextensions";
                ValidationParameters.Add("fileextensions", string.Join(",", fileExtensions));
            }
        }
    }
}