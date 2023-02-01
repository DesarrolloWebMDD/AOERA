using System.IdentityModel.Tokens.Jwt;

namespace Distributed.ServicesTest.Helper
{
    public class TokenHelper
    {
        private readonly string _encodedToken;

        public TokenHelper(string encodedToken)
        {
            _encodedToken = encodedToken;
        }

        //public string Token { get; set; }
        public JwtSecurityToken Decode()
        {
            //Assume the input is in a control called txtJwtIn,
            //and the output will be placed in a control called txtJwtOut
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtInput = _encodedToken;

            //Check if readable token (string is in a JWT format)
            var readableToken = jwtHandler.CanReadToken(jwtInput);

            if (readableToken != true) return null;
            return jwtHandler.ReadJwtToken(jwtInput);
        }
    }
}