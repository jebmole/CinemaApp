using CinemaApp.Application.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CinemaApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        [HttpPost]
        public IActionResult GetToken(UserLoginRequest loginRequest)
        {
            //Validar si el usuario existe en la BD y la contraseña es correcta
            var isValidUser = ValidateUser(loginRequest);
            if(!isValidUser)
                return Unauthorized();

            //Si el usuario es valido genero el token de autenticación
            var token = GenerateToken(loginRequest.UserName);
            return Ok(new { token });
        }


        private bool ValidateUser(UserLoginRequest loginRequest)
        {
            // TODO: Ir a la BD y validar el usuario
            if(loginRequest.UserName == "admin" && loginRequest.Password == "abc123")
                return true;

            return false;
        }

        private string GenerateToken(string userName)
        {
            //Header
            var privateKey = "asdfawdfsdfqwerwefcwaefewtwassdas";
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Payload
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userName),
                new Claim(ClaimTypes.Role, "Administrador"),
            };

            var payload = new JwtPayload
            (
                "https://localhost:44357", // Issuer
                "https://localhost:44357", // Audience
                claims,
                DateTime.Now, // Fecha de generación del token
                DateTime.Now.AddMinutes(5) // Fecha expiración del token
            );


            //Signature
            var token = new JwtSecurityToken(header, payload);
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
    }
}
