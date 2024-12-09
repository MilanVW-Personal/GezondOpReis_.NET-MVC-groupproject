using System;
using System.ComponentModel.DataAnnotations;

namespace GezondOpReis.ViewModels
{
    public class OpleidingCreateViewModel
    {
        [Required(ErrorMessage = "Naam is verplicht.")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Beschrijving is verplicht.")]
        public string Beschrijving { get; set; }

        [Required(ErrorMessage = "Startdatum is verplicht.")]
        [Display(Name = "Startdatum")]
        public DateTime StartDatum { get; set; }

        [Required(ErrorMessage = "Einddatum is verplicht.")]
        [Display(Name = "Einddatum")]
        [ValidateEndDate("StartDatum", ErrorMessage = "Einddatum moet na de startdatum liggen.")]
        public DateTime EindDatum { get; set; }

        [Required(ErrorMessage = "Aantal plaatsen is verplicht.")]
        [Range(1, int.MaxValue, ErrorMessage = "Aantal plaatsen moet groter zijn dan nul.")]
        [Display(Name = "Aantal plaatsen")]
        public int AantalPlaatsen { get; set; }
    }

    public class ValidateEndDateAttribute : ValidationAttribute
    {
        private readonly string _startDatePropertyName;

        public ValidateEndDateAttribute(string startDatePropertyName)
        {
            _startDatePropertyName = startDatePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime endDate = (DateTime)value;
            DateTime startDate = (DateTime)validationContext.ObjectType.GetProperty(_startDatePropertyName).GetValue(validationContext.ObjectInstance, null);

            if (endDate <= startDate)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}