using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DataAccess.Concrete.Configurations
{
    public class ModelTypeConfiguration : IEntityTypeConfiguration<ModelType>
    {
        public void Configure(EntityTypeBuilder<ModelType> builder)
        {
            builder.HasKey(type => type.TypeId);
            builder.Property(type => type.TypeName).HasMaxLength(25).IsRequired();
        }
    }
}
