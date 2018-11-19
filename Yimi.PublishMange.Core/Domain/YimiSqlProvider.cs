using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core;

namespace Yimi.PublishManage.Core.Domain
{
    public class YimiSqlProvider : BaseEntity
    {
        public string Name { get; set; }

        public bool IsProd { get; set; }

        public string Connectstring { get; set; }

        public SqlProviderType SqlProviderType { get; set; }

        public string DbName { get; set; }

    }
}
