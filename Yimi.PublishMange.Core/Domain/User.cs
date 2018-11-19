using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core;

namespace Yimi.PublishManage.Core.Domain
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Password { get; set; }

        public bool Actived { get; set; }

        public string LastLoginIp { get; set; }

        public virtual ICollection<Role> Roles { get; set; }


    }
}
