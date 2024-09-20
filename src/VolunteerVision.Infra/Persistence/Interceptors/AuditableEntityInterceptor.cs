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
                case EntityState.Modified when entity.DeletedAtUtc is not null:
                    entity.GetType()
                          .GetProperty(nameof(IAuditableEntity.UpdatedAtUtc))!
                          .SetValue(entity, DateTime.UtcNow);
                    break;
                
                case EntityState.Deleted:
                    entity.GetType()
                          .GetProperty(nameof(IAuditableEntity.DeletedAtUtc))!
                          .SetValue(entity, DateTime.UtcNow);
                        
                    context.Entry(entity).State = EntityState.Modified;
                    
                    context
                        .Entry(entity)
                        .Property(nameof(IAuditableEntity.DeletedAtUtc))
                        .IsModified = true;
                    
                    break;
            } 
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
