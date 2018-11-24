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


        public override string ToString()
        {
            return $"Company:{Company??string.Empty}" + System.Environment.NewLine +
                $"Name:{Name ?? string.Empty}" + System.Environment.NewLine +
                $"Email:{Email ?? string.Empty}" + System.Environment.NewLine +
                $"Phone:{Phone ?? string.Empty}" + System.Environment.NewLine +
                $"PartNo:{PartNo ?? string.Empty}" + System.Environment.NewLine +
                $"Quantity:{Quantity ?? string.Empty}" + System.Environment.NewLine +
                $"Type:{Type ?? string.Empty}" + System.Environment.NewLine +
                $"Commnet:{Commnet ?? string.Empty}" + System.Environment.NewLine;
        }


    }
}
