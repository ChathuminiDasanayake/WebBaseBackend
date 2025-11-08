using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebBaseBackend.Entities;
using WebBaseBackend.Models;
using WebBaseBackend.Services;

namespace WebBaseBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {

            var user = await authService.RegisterAsync(request);
            if (user is null) {
                return BadRequest("Username already exists. ");
            }
            return Ok(user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<String>> Login(UserDto request)
        {
            var token = await authService.LoginAsync(request);
            if (token is null)
            {
                return BadRequest("Invalid Username or Password.");
            }

            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public IActionResult AuthenticatedOnlyEndpoint() 
        {
            return Ok("You are authenticated!");
        
        }

        
    }
// Dynamic 

    /*[Route("api/[controller]")]
[ApiController]
public class AuthController(IConfiguration configuration) : ControllerBase
{
    public static User user = new ();
    [HttpPost("Register")]
    public ActionResult<User> Register(UserDto request) {

        var hasedPassword = new PasswordHasher<User>()
            .HashPassword(user, request.PasswordHash);

        user.UserName = request.UserName;
        user.PasswordHash = hasedPassword;

        return Ok(user);
    }

    [HttpPost("Login")]
    public ActionResult<String> Login(UserDto request)
    {

        if (user.UserName != request.UserName) {
            return BadRequest("User not Found");
        }

        if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, request.PasswordHash)== PasswordVerificationResult.Failed) {
            return BadRequest("Wrong Password");
        }

        string token = CreateToken(user);

        return Ok(token);
    }

    private string CreateToken(User user) {

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName)
        };
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!)
            );
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: configuration.GetValue<string>("AppSettings:Issuer"),
            audience: configuration.GetValue<string>("AppSettings:Audience"),
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}*/
}
