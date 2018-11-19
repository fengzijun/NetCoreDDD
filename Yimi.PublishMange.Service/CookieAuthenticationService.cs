using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Yimi.PublishManage.Core.Domain;
using Yimi.PublishManage.Service.IService;

namespace Yimi.PublishManage.Service
{
    public class CookieAuthenticationService : IYimiAuthenticationService
    {

        #region Fields

        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private User _cachedUser;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="customerSettings">Customer settings</param>
        /// <param name="customerService">Customer service</param>
        /// <param name="httpContextAccessor">HTTP context accessor</param>
        public CookieAuthenticationService(
            IUserService userService,
            IHttpContextAccessor httpContextAccessor)
        {
           
            this._userService = userService;
            this._httpContextAccessor = httpContextAccessor;
        }

        #endregion

        /// <summary>
        /// Sign in
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="createPersistentCookie">A value indicating whether to create a persistent cookie</param>
        public virtual async void SignIn(User user, bool createPersistentCookie)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            //create claims for customer's username and email
            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(user.Name))
            {
                claims.Add(new Claim(ClaimTypes.Name, user.Name, ClaimValueTypes.String, YimiCookieAuthenticationDefaults.ClaimsIssuer));
            }

            if (!string.IsNullOrEmpty(user.Email))
                claims.Add(new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email, YimiCookieAuthenticationDefaults.ClaimsIssuer));

            //create principal for the current authentication scheme
            var userIdentity = new ClaimsIdentity(claims, YimiCookieAuthenticationDefaults.AuthenticationScheme);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            //set value indicating whether session is persisted and the time at which the authentication was issued
            var authenticationProperties = new AuthenticationProperties
            {
                IsPersistent = createPersistentCookie,
                IssuedUtc = DateTime.UtcNow
            };

            //sign in
            await _httpContextAccessor.HttpContext.SignInAsync(YimiCookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, authenticationProperties);

            //cache authenticated customer
            _cachedUser = user;
        }

        /// <summary>
        /// Sign out
        /// </summary>
        public virtual async void SignOut()
        {
            _cachedUser = null;

            //and sign out from the current authentication scheme
            await _httpContextAccessor.HttpContext.SignOutAsync(YimiCookieAuthenticationDefaults.AuthenticationScheme);
        }

        /// <summary>
        /// Get authenticated customer
        /// </summary>
        /// <returns>Customer</returns>
        public User GetAuthenticateUser()
        {
            //whether there is a cached customer
            if (_cachedUser != null)
                return _cachedUser;

            //try to get authenticated user identity
            var authenticateResult = _httpContextAccessor.HttpContext.AuthenticateAsync(YimiCookieAuthenticationDefaults.AuthenticationScheme).Result;
            if (!authenticateResult.Succeeded)
                return null;

            User user = null;
            //if (_customerSettings.UsernamesEnabled)
            //{
            //    //try to get customer by username
            //    var usernameClaim = authenticateResult.Principal.FindFirst(claim => claim.Type == ClaimTypes.Name
            //        && claim.Issuer.Equals(YimiCookieAuthenticationDefaults.ClaimsIssuer, StringComparison.InvariantCultureIgnoreCase));
            //    if (usernameClaim != null)
            //        customer = _customerService.GetCustomerByUsername(usernameClaim.Value);
            //}
            //else
            //{
            //    //try to get customer by email
            //    var emailClaim = authenticateResult.Principal.FindFirst(claim => claim.Type == ClaimTypes.Email
            //        && claim.Issuer.Equals(YimiCookieAuthenticationDefaults.ClaimsIssuer, StringComparison.InvariantCultureIgnoreCase));
            //    if (emailClaim != null)
            //        customer = _customerService.GetCustomerByEmail(emailClaim.Value);
            //}

            var usernameClaim = authenticateResult.Principal.FindFirst(claim => claim.Type == ClaimTypes.Name
                 && claim.Issuer.Equals(YimiCookieAuthenticationDefaults.ClaimsIssuer, StringComparison.InvariantCultureIgnoreCase));
            if (usernameClaim != null)
                user = _userService.GetUserByName(usernameClaim.Value);

            //whether the found customer is available
            if (user == null || !user.Actived || user.Deleted)
                return null;

            //cache authenticated customer
            _cachedUser = user;

            return _cachedUser;
        }
    }
}
