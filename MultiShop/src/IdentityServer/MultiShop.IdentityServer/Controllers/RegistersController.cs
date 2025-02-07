using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers;

[Authorize(LocalApi.PolicyName)]
[Route("api/[controller]")]
[ApiController]
public class RegistersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    public RegistersController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> UserRegister(RegisterDto registerDto)
    {
        var value = new ApplicationUser
        {
            Email = registerDto.Email.Trim(),
            Name = registerDto.Name.Trim(),
            Surname = registerDto.Surname.Trim(),
            UserName = registerDto.Username.Trim()
        };

        var result = await _userManager.CreateAsync(value, registerDto.Password);

        if (result.Succeeded)
        {
            return Ok("User created successfully.");
        }
        else
        {
            return BadRequest("Something went wrong. Please try again.");
        }
    }
}
