using System.Data.Entity.ModelConfiguration;
using MalweeCodeChallenge.Core.Entities;

namespace MalweeCodeChallenge.Core.Infra.EntityFramework.Mapping
{
    public class ServiceProvidedMap:EntityTypeConfiguration<ServiceProvided>
    {
        public ServiceProvidedMap()
        {
            ToTable("ServiceProvided");
            HasKey(x => x.IdDbKey);
            Property(p => p.Description).HasColumnType("Text");
            HasRequired(p => p.ServiceProvidedClient).WithMany().HasForeignKey(p => p.ServiceProvidedClientId);
            Property(p => p.DateOfService).HasColumnType("DateTime");
            
        }
    }
}