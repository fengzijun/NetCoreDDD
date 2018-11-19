using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yimi.PublishManage.Web.Model
{
    public class RoleDto
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public List<PermissionDto> Permissions { get; set; }
    }
}
