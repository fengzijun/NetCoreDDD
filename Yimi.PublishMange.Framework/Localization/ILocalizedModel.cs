﻿using System.Collections.Generic;

namespace Yimi.PublishManage.Framework.Localization
{
    public interface ILocalizedModel
    {

    }
    public interface ILocalizedModel<TLocalizedModel> : ILocalizedModel
    {
        IList<TLocalizedModel> Locales { get; set; }
    }
}
