using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MalweeCodeChallenge.Core.Contracts.Enums;
using MalweeCodeChallenge.Core.Contracts.Interfaces;

namespace MalweeCodeChallenge.Core.Contracts.DataObjects
{
    public class ServiceProvidedDto
    {
        public string IdDbKey { get; set; }
        public ServiceProvidedDto()
        {
            this.IdDbKey = Guid.NewGuid().ToString();
        }
        [Required]
        [Display(Name = "Descrição")]
        [MaxLength(300, ErrorMessage = "Descrição deve ter no máximo 300 caracteres")]
        public string Description { get; set; }
       
        [Required]
        [Display(Name = "Data de atendimento")]
        public DateTime DateOfService { get; set; }
        
        [Required]
        [Display(Name = "Valor")]
        public decimal Value { get; set; }

        public string ServiceProvidedClientId { get; set; }
        public string ClientName { get; set; }
        public StatesEnum ClientState { get; set; }
        public string ClientNeighborhood { get; set; }
        public string ClientCity { get; set; }

        [Required]
        [Display(Name = "Tipo de Serviço")]
        public ServiceEnum Service { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
    }
}
