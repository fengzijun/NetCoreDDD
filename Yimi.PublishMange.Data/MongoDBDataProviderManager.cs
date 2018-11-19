using System;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Data;

namespace Yimi.PublishManage.Data
{
    public partial class MongoDBDataProviderManager : BaseDataProviderManager
    {
        public MongoDBDataProviderManager(DataSettings settings):base(settings)
        {
        }

        public override IDataProvider LoadDataProvider()
        {

            var providerName = Settings.DataProvider;
            if (String.IsNullOrWhiteSpace(providerName))
                throw new YimiException("Data Settings doesn't contain a providerName");

            switch (providerName.ToLowerInvariant())
            {
                case "mongodb":
                    return new MongoDBDataProvider();
                default:
                    throw new YimiException(string.Format("Not supported dataprovider name: {0}", providerName));
            }
        }

    }
}
