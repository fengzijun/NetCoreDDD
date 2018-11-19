using System;
using System.Collections.Generic;
using System.Text;

namespace Yimi.PublishManage.Core
{
   public interface IEventPublisher
    {
        void Publish<T>(T eventMessage);
    }
}
