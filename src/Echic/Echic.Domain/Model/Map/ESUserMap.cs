using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Echic.Domain.Model
{
    public class ESUserMap : IEntityTypeConfiguration<ES_User>
    {
        public void Configure(EntityTypeBuilder<ES_User> builder)
        {
            builder.ToTable("ES_User");

            builder.Property(u => u.ObjectID).HasColumnName("objectid");
            builder.Property(u => u.Username).HasColumnName("username");
            builder.Property(u => u.Password).HasColumnName("password");
            builder.Property(u => u.Expired).HasColumnName("expired");
            builder.Property(u => u.CreatedBy).HasColumnName("createdby");
            builder.Property(u => u.CreatedTime).HasColumnName("createdtime");
            builder.Property(u => u.ModifiedBy).HasColumnName("modifiedby");
            builder.Property(u => u.ModifiedTime).HasColumnName("modifiedtime");

            builder.HasKey(u => u.ObjectID);
        }
    }
}
