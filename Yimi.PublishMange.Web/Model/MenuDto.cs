using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yimi.PublishManage.Web.Model
{
    public class MenuDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string ParentId { get; set; }

        public MenuDto ParentMenu { get; set; }

        public List<MenuDto> ChildMenus { get; set; }


    }
}
