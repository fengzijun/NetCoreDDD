using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core;

namespace Yimi.PublishManage.Core.Domain
{
    public class Menu : BaseEntity
    {
        public Menu()
        {
            ChildMenus = new List<Menu>();
          
        }

        public string Name { get; set; }

        public string Url { get; set; }

        public string ParentId { get; set; }

        public virtual Menu ParentMenu { get; set; }

        public virtual ICollection<Menu> ChildMenus { get; set; }

    }
}
