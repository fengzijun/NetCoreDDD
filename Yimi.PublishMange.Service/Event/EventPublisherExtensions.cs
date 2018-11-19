
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Events;
using Yimi.PublishManage.Core;

namespace Yimi.PublishManage.Services.Events
{
    public static class EventPublisherExtensions
    {
        public static void EntityInserted<T>(this IEventPublisher eventPublisher, T entity) where T : ParentEntity
        {
            eventPublisher.Publish(new EntityInserted<T>(entity));
        }

        public static void EntityUpdated<T>(this IEventPublisher eventPublisher, T entity) where T : ParentEntity
        {
            eventPublisher.Publish(new EntityUpdated<T>(entity));
        }

        public static void EntityDeleted<T>(this IEventPublisher eventPublisher, T entity) where T : ParentEntity
        {
            eventPublisher.Publish(new EntityDeleted<T>(entity));
        }

    }
}