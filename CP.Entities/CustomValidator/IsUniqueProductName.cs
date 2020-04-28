using CP.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CP.Entities.CustomValidator
{
    public class IsUniqueProductName : ValidationAttribute, IClientValidatable
    {
        CafeProjectModel cafeProjectModel = new CafeProjectModel();
        public IsUniqueProductName() : base("Ürün Adı Alınmış")
        {
            
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule();
            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationType = "exclude";

            yield return rule;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (cafeProjectModel.Product.Any(x => x.Name == value.ToString()))
            {
                var errormessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errormessage);
            }
            return null;
        }
    }
}
