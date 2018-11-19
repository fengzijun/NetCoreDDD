using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Domain;

namespace Yimi.PublishManage.Service.IService
{
    public interface IMenuService
    {
        List<Menu> GetMenus(string userid);

        Menu AddMenu(Menu menu);

        void UpdateMenu(Menu Menu);

        void DeleteMenu(string Menuid);

        Menu GetMenu(string menuid);
    }
}
