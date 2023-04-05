using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace myProject.Models.Mapping
{
    public class hradminMap : EntityTypeConfiguration<hradmin>
    {
        public hradminMap()
        {
            // Primary Key
            this.HasKey(t => t.uuid);

            // Properties
            this.Property(t => t.uuid)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.login_name)
                .HasMaxLength(36);

            this.Property(t => t.login_pwd)
                .HasMaxLength(36);

            // Table & Column Mappings
            this.ToTable("hradmin", "myproject");
            this.Property(t => t.uuid).HasColumnName("uuid");
            this.Property(t => t.login_name).HasColumnName("login_name");
            this.Property(t => t.login_pwd).HasColumnName("login_pwd");
        }
    }
}