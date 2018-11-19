using System.Linq;
//using System.Linq.Dynamic;
using FluentValidation;
using Yimi.PublishManage.Core.Infrastructure;
using Yimi.PublishManage.Data;


namespace Yimi.PublishManage.Framework.Validators
{
    public abstract class BaseYimiValidator<T> : AbstractValidator<T> where T : class
    {
        protected BaseYimiValidator()
        {
            PostInitialize();
        }

        /// <summary>
        /// Developers can override this method in custom partial classes
        /// in order to add some custom initialization code to constructors
        /// </summary>
        protected virtual void PostInitialize()
        {

        }


    }
}