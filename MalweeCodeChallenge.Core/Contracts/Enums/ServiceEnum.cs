using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MalweeCodeChallenge.Core.Contracts.Enums
{
    public enum ServiceEnum
    {
        [Description("Reparos elétricos")]
        ElectronicRepair,
        [Description("Serviços Gerais")]
        GeneralServices,
        [Description("Manutenção Hidráulica")]
        HydraulicMaintenance,
        [Description("Instalação Elétrica")]
        ElectricalInstallation,
        [Description("Jardinagem")]
        Gardening,
        [Description("Outro")]
        Other
    }
}