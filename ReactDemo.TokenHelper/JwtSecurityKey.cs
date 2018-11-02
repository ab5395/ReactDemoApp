namespace ReactDemo.TokenHelper
{
    using Microsoft.IdentityModel.Tokens;
    using System.Text;

    public static class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes("fiver-secret-key"));
        }
    }
}
