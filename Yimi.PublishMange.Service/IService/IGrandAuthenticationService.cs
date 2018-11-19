using System;
using System.Collections.Generic;
using System.Text;
using Yimi.PublishManage.Core.Domain;

namespace Yimi.PublishManage.Service.IService
{
    public interface IYimiAuthenticationService
    {
        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="createPersistentCookie">A value indicating whether to create a persistent cookie</param>
        void SignIn(User user, bool createPersistentCookie);

        /// <summary>
        /// Sign out
        /// </summary>
        void SignOut();

        /// <summary>
        /// Get authenticated customer
        /// </summary>
        /// <returns>Customer</returns>
        User GetAuthenticateUser();
    }
}
