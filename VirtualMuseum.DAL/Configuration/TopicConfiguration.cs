using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.DAL.Configuration;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(t => t.Name).IsRequired().HasColumnType("nvarchar(100)");
        builder.Property(t => t.Description).IsRequired().HasColumnType("nvarchar(400)");

        builder.HasMany<SubTopic>(t => t.SubTopics)
            .WithOne(s => s.Topic)
            .HasPrincipalKey(t => t.Id)
            .HasForeignKey(s => s.TopicId);
    }
}