using System.ComponentModel;
using Yimi.PublishManage.Core;
using Yimi.PublishManage.Core.Infrastructure;

namespace Yimi.PublishManage.Framework.Mvc.ModelBinding
{
    /// <summary>
    /// Represents model attribute that specifies the display name by passed key of the locale resource
    /// </summary>
    public class YimiResourceDisplayNameAttribute : DisplayNameAttribute, IModelAttribute
    {
        #region Fields

        private string _resourceValue = string.Empty;

        #endregion

        #region Ctor

        /// <summary>
        /// Create instance of the attribute
        /// </summary>
        /// <param name="resourceKey">Key of the locale resource</param>
        public YimiResourceDisplayNameAttribute(string resourceKey) : base(resourceKey)
        {
            ResourceKey = resourceKey;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets key of the locale resource 
        /// </summary>
        public string ResourceKey { get; set; }

        /// <summary>
        /// Getss the display name
        /// </summary>
        public override string DisplayName
        {
            get
            {
                //get working language identifier
                //var workingLanguageId = EngineContext.Current.Resolve<IWorkContext>().WorkingLanguage.Id;

                ////get locale resource value
                //_resourceValue = EngineContext.Current.Resolve<ILocalizationService>().GetResource(ResourceKey, workingLanguageId, true, ResourceKey);

                return _resourceValue;
            }
        }

        /// <summary>
        /// Gets name of the attribute
        /// </summary>
        public string Name
        {
            get { return nameof(YimiResourceDisplayNameAttribute); }
        }

        #endregion
    }
}
