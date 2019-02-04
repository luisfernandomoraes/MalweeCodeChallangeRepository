using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MalweeCodeChallenge.Core.Contracts.DataObjects
{
    public class FilterServicesDto
    {
        public FilterTypeEnum FilterType { get; set; }
        [Required]
        public string FilterValue { get; set; }
    }

    public enum FilterTypeEnum 
    {
        [Description("Cliente")]
        CLIENT, 
        [Description("Estado")]
        STATE,
        [Description("Cidade")]
        CITY,
        [Description("Bairro")]
        NEIGHBORHOOD, 
        [Description("Tipo de Serviço")]
        SERVICE,
        [Description("Valor Mínimo")]
        MIN_VALUE, 
        [Description("Valor Máximo")]
        MAX_VALUE
    }
}