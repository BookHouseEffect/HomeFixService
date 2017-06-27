using HomeFixService.WebService.Models.Enums;
using System.ComponentModel.DataAnnotations;
using HomeFixService.WebService.Extensions;

namespace HomeFixService.WebService.Models.EntityFramework
{
    public class Currencies : BaseEnumEntity
    {
        [Required, MaxLength(100)]
        public string CurrencySign { get; set; }

        [MaxLength(100)]
        public string CurrencyFullName { get; set; }

        protected Currencies() { } //For EF

        private Currencies(CurrencyEnum @enum)
        {
            this.Id = (int)@enum;
            this.CurrencySign = @enum.ToString();
            this.CurrencyFullName = @enum.GetEnumDescription();
        }

        public static implicit operator Currencies(CurrencyEnum @enum)
            => new Currencies(@enum);

        public static implicit operator CurrencyEnum(Currencies currency)
            => (CurrencyEnum)currency.Id;
    }
}