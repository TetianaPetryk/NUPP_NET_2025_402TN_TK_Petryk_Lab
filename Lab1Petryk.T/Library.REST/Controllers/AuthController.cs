using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Library.Infrastruct.Models;
using Library.REST.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Library.REST.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _config;

    public AuthController(
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration config)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _config = config;
    }

    // POST: /api/Auth/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email))
            return BadRequest("Email is required");

        if (string.IsNullOrWhiteSpace(request.Password))
            return BadRequest("Password is required");

        // username робимо = email (щоб не було InvalidUserName)
        var userName = request.Email.Trim();

        // 1) перевіряємо, чи існує користувач
        var existingByName = await _userManager.FindByNameAsync(userName);
        if (existingByName != null)
            return Conflict("User already exists");

        var existingByEmail = await _userManager.FindByEmailAsync(request.Email);
        if (existingByEmail != null)
            return Conflict("Email already exists");

        // 2) створюємо користувача
        var user = new AppUser
        {
            UserName = userName,
            Email = request.Email.Trim()
        };

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        // 3) роль (за замовчуванням User)
        var role = string.IsNullOrWhiteSpace(request.Role) ? "User" : request.Role.Trim();

        // якщо ролі ще нема — створюємо автоматично
        if (!await _roleManager.RoleExistsAsync(role))
            await _roleManager.CreateAsync(new IdentityRole(role));

        await _userManager.AddToRoleAsync(user, role);

        return StatusCode(201, new
        {
            message = "Registered",
            userName = user.UserName,
            email = user.Email,
            role
        });
    }

    // POST: /api/Auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.UserName))
            return BadRequest("UserName is required (use Email here)");

        if (string.IsNullOrWhiteSpace(request.Password))
            return BadRequest("Password is required");

        var userName = request.UserName.Trim(); // тут ти вводиш email як username

        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
            return Unauthorized("Invalid credentials");

        var ok = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!ok)
            return Unauthorized("Invalid credentials");

        var roles = await _userManager.GetRolesAsync(user);

        var token = GenerateJwtToken(user, roles);

        return Ok(new
        {
            token,
            expiresMinutes = int.Parse(_config["Jwt:ExpiresMinutes"] ?? "60"),
            roles
        });
    }

    private string GenerateJwtToken(AppUser user, IList<string> roles)
    {
        var key = _config["Jwt:Key"]!;
        var issuer = _config["Jwt:Issuer"]!;
        var audience = _config["Jwt:Audience"]!;
        var expiresMinutes = int.Parse(_config["Jwt:ExpiresMinutes"] ?? "60");

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName ?? ""),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? "")
        };

        foreach (var r in roles)
            claims.Add(new Claim(ClaimTypes.Role, r));

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(expiresMinutes),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}
