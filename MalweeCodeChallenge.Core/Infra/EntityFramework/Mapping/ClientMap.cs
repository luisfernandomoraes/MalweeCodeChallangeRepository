using System.Data.Entity.ModelConfiguration;
using MalweeCodeChallenge.Core.Entities;

namespace MalweeCodeChallenge.Core.Infra.EntityFramework.Mapping
{
    public class ClientMap:EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            ToTable("Client");
            Property(x => x.Neighborhood).HasMaxLength(240);
            HasRequired(p => p.Supplier).WithMany().HasForeignKey(p => p.SupplierId);
            Property(x => x.City).HasMaxLength(100);
            Property(x => x.Name).HasMaxLength(120);
        }
    }
}
