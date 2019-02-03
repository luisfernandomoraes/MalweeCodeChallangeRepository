using System.Data.Entity.ModelConfiguration;
using MalweeCodeChallenge.Core.Entities;

namespace MalweeCodeChallenge.Core.Infra.EntityFramework.Mapping
{
    public class SupplierMap:EntityTypeConfiguration<Supplier>
    {
        public SupplierMap()
        {
            ToTable("Supplier");
            HasKey(x => x.IdDbKey);

            Property(x => x.Name).HasMaxLength(140);
        }
    }
}