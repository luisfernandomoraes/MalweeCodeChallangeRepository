using System.ComponentModel;

namespace MalweeCodeChallenge.Core.Contracts.DataObjects
{
    public class FilterServicesDto
    {
        public FilterTypeEnum FilterType { get; set; }
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