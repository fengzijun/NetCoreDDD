﻿using System;

namespace Yimi.PublishManage.Core
{
    public class HistoryObject: BaseEntity
    {
        public DateTime CreatedOnUtc { get; set; }
        public BaseEntity Object { get; set; }
    }
}
