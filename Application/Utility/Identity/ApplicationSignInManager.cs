using Application.Models;
using Domain.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
 

namespace Application.Utility.Identity
{
    public class ApplicationSignInManager : SignInManager<User>
    {
        private readonly SignInResult signInStatus;
        public ApplicationSignInManager(UserManager<User> userManager, 
            IHttpContextAccessor contextAccessor, 
            IUserClaimsPrincipalFactory<User> claimsFactory, 
            IOptions<IdentityOptions> optionsAccessor, 
            ILogger<SignInManager<User>> logger, IAuthenticationSchemeProvider schemes) 
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
        {
        }



        #region Sign with password custom
        public override async Task<SignInResult> PasswordSignInAsync(User user, 
            string password, 
            bool isPersistent, 
            bool lockoutOnFailure)
        {
            if (this.UserManager != null)
            {
                Task<User> userManager = this.UserManager.FindByNameAsync(user.UserName);
                if (userManager != null)
                {
                    Task<bool> checkUserLocked = this.UserManager.IsLockedOutAsync(user);

                    if (!await checkUserLocked)
                    {
                        Task<bool> checkUserPassword = this.UserManager.CheckPasswordAsync(user, user.Password);
                        if (!await checkUserPassword)
                        {
                            if (lockoutOnFailure)
                            {
                                IdentityResult accessFailed = await UserManager.AccessFailedAsync(user);
                                bool checkUserLocked2 = await UserManager.IsLockedOutAsync(user);
                                if (checkUserLocked2)
                                {
                                    return SignInResult.LockedOut;
                                }
                            }
                            else
                            {
                                IdentityResult identityResult = await UserManager.ResetAccessFailedCountAsync(user);
                                return SignInResult.Success;
                            }

                        }
                        return SignInResult.Failed;
                    }
                    else
                    {
                        return SignInResult.LockedOut;
                    }
                }
                else
                {
                    return SignInResult.Failed;
                }
            }
            else
            {
                return SignInResult.Failed;
            }
        }

        #endregion


    }
}
