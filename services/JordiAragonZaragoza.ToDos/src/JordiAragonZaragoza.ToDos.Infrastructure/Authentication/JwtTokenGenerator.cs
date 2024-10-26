namespace JordiAragonZaragoza.ToDos.Infrastructure.Authentication
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using JordiAragon.SharedKernel.Application.Contracts.Interfaces;
    using JordiAragon.SharedKernel.Contracts.DependencyInjection;
    using JordiAragon.SharedKernel.Domain.Contracts.Interfaces;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    public class JwtTokenGenerator : IJwtTokenGenerator, ISingletonDependency
    {
        private readonly JwtTokenGeneratorOptions jwtTokenGeneratorOptions;
        private readonly IDateTime datetime;

        public JwtTokenGenerator(
            IDateTime datetime,
            IOptions<JwtTokenGeneratorOptions> jwtTokenGeneratorOptions)
        {
            this.datetime = datetime;
            this.jwtTokenGeneratorOptions = jwtTokenGeneratorOptions.Value ?? throw new ArgumentNullException(nameof(jwtTokenGeneratorOptions));
        }

        public string GenerateToken(Guid accountId, string firstname, string lastname)
        {
            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(this.jwtTokenGeneratorOptions.Secret)),
                SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, accountId.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, firstname),
                new Claim(JwtRegisteredClaimNames.FamilyName, lastname),
                new Claim(JwtRegisteredClaimNames.UniqueName, Guid.NewGuid().ToString()),
            };

            var securityToken = new JwtSecurityToken(
                issuer: this.jwtTokenGeneratorOptions.Issuer,
                audience: this.jwtTokenGeneratorOptions.Audience,
                expires: this.datetime.UtcNow.AddMinutes(this.jwtTokenGeneratorOptions.ExpiryMinutes),
                claims: claims,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}