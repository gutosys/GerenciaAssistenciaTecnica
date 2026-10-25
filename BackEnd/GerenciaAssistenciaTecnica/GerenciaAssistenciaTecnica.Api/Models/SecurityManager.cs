using GerenciaAssistenciaTecnica.Api.Repositories;
using GerenciaAssistenciaTecnica.Infrastructure.Data;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaAssistenciaTecnica.Api.Models
{
    public class SecurityManager
    {
        private JwtSettings _settings = null;

        private IUserRepository _userRepository;

        public SecurityManager(JwtSettings settings, IUserRepository userRepository)
        {
            _settings = settings;
            this._userRepository = userRepository;
        }

        public AppUserAuth ValidateUser(AppUser user)
        {
            AppUserAuth ret = new AppUserAuth();
            AppUser authUser = null;


            authUser = _userRepository.ValidadeUser(user);            

            if (authUser != null)
            {
                // Build User Security Object
                ret = BuildUserAuthObject(authUser);
            }

            return ret;
        }

        protected List<AppUserClaim> GetUserClaims(AppUser authUser)
        {
            List<AppUserClaim> list = new List<AppUserClaim>();

            try
            {                
                list = _userRepository.ListClaims(authUser);                
            }
            catch (Exception ex)
            {
                throw new Exception(
                    "Exception trying to retrieve user claims.", ex);
            }

            return list;
        }

        protected AppUserAuth BuildUserAuthObject(AppUser authUser)
        {
            AppUserAuth ret = new AppUserAuth();
            List<AppUserClaim> claims = new List<AppUserClaim>();

            // Set User Properties
            ret.UserName = authUser.UserName;
            ret.IsAuthenticated = true;
            ret.BearerToken = new Guid().ToString();

            // Get all claims for this user
            ret.Claims = GetUserClaims(authUser);

            // Set JWT bearer token
            ret.BearerToken = BuildJwtToken(ret);

            return ret;
        }

        protected string BuildJwtToken(AppUserAuth authUser)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(
              Encoding.UTF8.GetBytes(_settings.Key));

            // Create standard JWT claims
            List<Claim> jwtClaims = new List<Claim>();
            jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Sub,
                authUser.UserName));
            jwtClaims.Add(new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString()));

            // Add custom claims
            jwtClaims.Add(new Claim("isAuthenticated",
                authUser.IsAuthenticated.ToString().ToLower()));


            // Add custom claims
            foreach (var claim in authUser.Claims)
            {
                jwtClaims.Add(new Claim(claim.ClaimType, claim.ClaimValue));
            }

            // Create the JwtSecurityToken object
            var token = new JwtSecurityToken(
              issuer: _settings.Issuer,
              audience: _settings.Audience,
              claims: jwtClaims,
              notBefore: DateTime.UtcNow,
              expires: DateTime.UtcNow.AddMinutes(
                  _settings.MinutesToExpiration),
              signingCredentials: new SigningCredentials(key,
                          SecurityAlgorithms.HmacSha256)
            );

            // Create a string representation of the Jwt token
            return new JwtSecurityTokenHandler().WriteToken(token); ;
        }
    }
}
