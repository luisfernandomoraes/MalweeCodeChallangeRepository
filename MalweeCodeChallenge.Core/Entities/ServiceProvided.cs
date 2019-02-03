using System;
using System.ComponentModel.DataAnnotations;
using MalweeCodeChallenge.Core.Contracts.Enums;
using MalweeCodeChallenge.Core.Contracts.Interfaces;

namespace MalweeCodeChallenge.Core.Entities
{
    public class ServiceProvided : IEntity
    {
        public string IdDbKey { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DateOfService { get; set; }
        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal Value { get; set; }
        public ServiceEnum Service { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateUser { get; set; }
        public string ServiceProvidedClientId { get; set; }
        public virtual Client ServiceProvidedClient { get; set; }
    }
}