using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace MultiShop.IdentityServer.Tools
{
	public class JwtTokenGenerator
	{
		public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
		{
			var cliams = new List<Claim>();
			if (!string.IsNullOrEmpty(model.Role))
			{
				cliams.Add(new Claim(ClaimTypes.Role, model.Role));
			}
			else
			{
				cliams.Add(new Claim(ClaimTypes.NameIdentifier, model.Id));
			}

			if (!string.IsNullOrEmpty(model.UserName))
			{
				cliams.Add(new Claim("UserName", model.UserName));
			}
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
				var signingCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
				var expireDate = DateTime.UtcNow.AddDays(1);
				JwtSecurityToken token = new JwtSecurityToken(issuer: JwtTokenDefaults.ValidIssuer, audience: JwtTokenDefaults.ValidAudience, claims: cliams, notBefore: DateTime.UtcNow, expires: expireDate, signingCredentials: signingCredential);
				JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
				return new TokenResponseViewModel(tokenHandler.WriteToken(token), expireDate: expireDate);
			}
		
	}
}
