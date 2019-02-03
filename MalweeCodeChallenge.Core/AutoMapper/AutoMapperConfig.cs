using System;
using AutoMapper;
using MalweeCodeChallenge.Core.Contracts.DataObjects;
using MalweeCodeChallenge.Core.Contracts.Enums;
using MalweeCodeChallenge.Core.Entities;
using MalweeCodeChallenge.Core.Helper;

namespace MalweeCodeChallenge.Core.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ClientDto, Client>();
                cfg.CreateMap<SupplierDto, Supplier>();
                cfg.CreateMap<ServiceProvidedDto, ServiceProvided>();
                cfg.CreateMap<ServiceProvided, ServiceProvidedDto>()
                    .ForMember(dest => dest.ClientName,
                        opts => opts.MapFrom(src => src.ServiceProvidedClient.Name))
                    .ForMember(dest => dest.ClientState,
                        opts => opts.MapFrom(src =>
                            (src.ServiceProvidedClient.State)))
                    .ForMember(dest => dest.ClientCity,
                        opts => opts.MapFrom(src => src.ServiceProvidedClient.City))
                    .ForMember(dest => dest.ClientNeighborhood,
                        opts => opts.MapFrom(src => src.ServiceProvidedClient.Neighborhood));

            });
        }
    }
}