using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using VolunteerVision.Domain.Core.Abstractions;

namespace VolunteerVision.Infra.Persistence.Interceptors;

public class AuditableEntityInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        if (eventData.Context is not {} context)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        foreach (var entry in context.ChangeTracker.Entries<IAuditableEntity>())
        {
            var entity = entry.Entity;

            switch (entry.State)
            {
                case EntityState.Added:
                    entity.OnCreate();
                    break;
                case EntityState.Modified when entity.DeletedAt is not null:
                    entity.OnUpdate();
                    break;
                
                case EntityState.Deleted:
                    entity.OnDelete();
                        
                    context.Entry(entity).State = EntityState.Modified;
                    context
                        .Entry(entity)
                        .Property(nameof(IAuditableEntity.DeletedAt))
                        .IsModified = true;
                    
                    break;
            } 
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
