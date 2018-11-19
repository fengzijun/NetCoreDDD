using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core;

namespace Yimi.PublishManage.Core.Domain
{
    public class Permission: BaseEntity
    {

        private ICollection<Menu> _menus;

        public string Name { get; set; }

        public PermissionType PermissionType { get; set; }

        #region Navigation properties

        /// <summary>
        /// Gets or sets the customer roles
        /// </summary>
        public virtual ICollection<Menu> Menus
        {
            get { return _menus ?? (_menus = new List<Menu>()); }
            set { _menus = value; }
        }

      
        #endregion
    }
}
