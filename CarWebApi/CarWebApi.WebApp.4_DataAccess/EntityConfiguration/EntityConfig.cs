using CarWebApi.WebApp._4_DataAccess.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWebApi.WebApp._4_DataAccess.EntityConfiguration
{
    public class EntityConfig : IEntityTypeConfiguration<CarEntity>
    {
        public void Configure(EntityTypeBuilder<CarEntity> builder)
        {
            builder.ToTable("CarTable");
            builder.HasKey(PrimaryKey => PrimaryKey.CarId);
        }
    }
}
