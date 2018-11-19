using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core;

namespace Yimi.PublishManage.Core.Domain
{
    public class Role : BaseEntity 
    {
        public string Name { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
