using System;
using System.Collections.Generic;
using System.Text;

namespace Yimi.PublishManage.Core.Domain
{
    public class Quote : BaseEntity
    {
        public string Company { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string PartNo { get; set; }

        public string Quantity { get; set; }

        public string Leadtime { get; set; }

        public string Uploadfile { get; set; }

        public string Type { get; set; }

        public string Commnet { get; set; }

        
    }
}
