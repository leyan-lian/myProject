using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace myProject.Models.Mapping
{
    public class hrempMap:EntityTypeConfiguration<hremp>
    {
        public hrempMap()
        {
            // Primary Key
            this.HasKey(t => t.uuid);

            // Properties
            this.Property(t => t.uuid)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.name_emp)
                .HasMaxLength(36);

            this.Property(t => t.phone_emp)
                .HasMaxLength(11);

            this.Property(t => t.idcard_emp)
                .HasMaxLength(20);

            this.Property(t => t.org_emp)
                .HasMaxLength(160);

            this.Property(t => t.login_name)
                .HasMaxLength(36);

            this.Property(t => t.login_pwd)
                .HasMaxLength(36);

            this.Property(t => t.role)
                .HasMaxLength(36);

            // Table & Column Mappings
            this.ToTable("hremp", "myproject");
            this.Property(t => t.uuid).HasColumnName("uuid");
            this.Property(t => t.name_emp).HasColumnName("name_emp");
            this.Property(t => t.phone_emp).HasColumnName("phone_emp");
            this.Property(t => t.idcard_emp).HasColumnName("idcard_emp");
            this.Property(t => t.org_emp).HasColumnName("org_emp");
            this.Property(t => t.login_name).HasColumnName("login_name");
            this.Property(t => t.login_pwd).HasColumnName("login_pwd");
            this.Property(t => t.role).HasColumnName("role");
            this.Property(t => t.inactive).HasColumnName("inactive");
        }
    }
}