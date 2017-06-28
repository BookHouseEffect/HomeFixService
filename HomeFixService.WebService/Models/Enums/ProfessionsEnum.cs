using System.ComponentModel;

namespace HomeFixService.WebService.Models.Enums
{
    public enum ProfessionsEnum 
    {
        [Description("Cleaning service")] HYGIEN = 1,
        [Description("Power service")] ELECTRITIAN,
        [Description("Bathroom service")] PLUMBER,
        [Description("House wall service")] PAINTER,
        [Description("Child care service")] BABYSITTER,
        [Description("Shoe fixing service")] SHOEMAKER,
        [Description("Transport service")] TAXIDRIVER,
        [Description("Clothes cutting service")] TAILOR,
        [Description("IT service")] PROGRAMMER,
        [Description("Defense/Protecting service")] BODYGUARD
    }
}
