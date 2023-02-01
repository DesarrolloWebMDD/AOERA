using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Application.Security.Entity;
using Application.Security.Enum;
using Application.Security.IJsonWebToken;
using Microsoft.Extensions.Options;

namespace Application.Security.JsonWebToken
{
    public class JwtFactory : IJwtFactory
    {
        private readonly JwtIssuerOptions _jwtIssuerOptions;

        public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions)
        {
            _jwtIssuerOptions = jwtOptions.Value;
        }

        public AppUserToken GetJwt(AppUser appUser)
        {
            var claimsIdentity = GenerateClaims(appUser);
            return GenerateJwt(claimsIdentity);
        }

        private ClaimsIdentity GenerateClaims(AppUser appUser)
        {
            return new ClaimsIdentity(new GenericIdentity("tokenName", "Token"), new[]
            {
                new Claim(ClaimType.Id, appUser.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, appUser.Id.ToString()),
                new Claim(ClaimType.Name, appUser.Nombre),
                new Claim(ClaimType.Username, appUser.UserName),
                new Claim(ClaimType.Email, appUser.Email),
                //new Claim(ClaimType.Platform, appUser.Platform),
                //new Claim(ClaimType.Company, appUser.Company)
            });
        }

        private AppUserToken GenerateJwt(ClaimsIdentity identity)
        {
            var response = new AppUserToken
            {
                Token = GenerateEncodedToken(identity),
                Expiration = _jwtIssuerOptions.Expiration,
                ExpireIn = _jwtIssuerOptions.ValidFor.TotalMinutes
            };

            return response;
        }

        private string GenerateEncodedToken(ClaimsIdentity claimsIdentity)
        {
            //Creación de array de claims con claims registrados
            var claims = new[]
            {
                //new Claim(JwtRegisteredClaimNames.Sub, "reason24"), // [pending]
                //new Claim(JwtRegisteredClaimNames.Jti, await _jwtIssuerOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtIssuerOptions.IssuedAt).ToString(),
                    ClaimValueTypes.Integer64)
            };
            //agregación de claims publicos
            foreach (var claim in claimsIdentity.Claims)
            {
                Array.Resize(ref claims, claims.Length + 1);
                claims[^1] = claim;
            }

            // Create the JWT security token and encode it.
            var jwt = new JwtSecurityToken(
                _jwtIssuerOptions.Issuer,
                _jwtIssuerOptions.Audience,
                claims,
                _jwtIssuerOptions.NotBefore,
                _jwtIssuerOptions.Expiration,
                _jwtIssuerOptions.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }

        /// <returns>Date converted to seconds since Unix epoch (Jan 1, 1970, midnight UTC).</returns>
        private static long ToUnixEpochDate(DateTime date)
        {
            return (long) Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                .TotalSeconds);
        }
    }
}