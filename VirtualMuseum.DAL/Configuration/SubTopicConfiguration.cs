using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VirtualMuseum.Domain.Entity;

namespace VirtualMuseum.DAL.Configuration;

public class SubTopicConfiguration : IEntityTypeConfiguration<SubTopic>
{
    public void Configure(EntityTypeBuilder<SubTopic> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Property(s => s.Name).IsRequired().HasColumnType("varchar(200)");
        builder.Property(s => s.Description).IsRequired().HasColumnType("varchar(500)");

        builder.HasMany<Article>(s => s.Articles)
            .WithOne(a => a.SubTopic)
            .HasPrincipalKey(s => s.Id)
            .HasForeignKey(a => a.SubTopicId);

        builder.HasOne<Topic>(s => s.Topic)
            .WithMany(t => t.SubTopics)
            .HasPrincipalKey(t => t.Id)
            .HasForeignKey(s => s.TopicId);
    }
    
}