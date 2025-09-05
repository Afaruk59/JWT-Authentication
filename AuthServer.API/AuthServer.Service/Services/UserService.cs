using AuthServer.Core.Services;
using AuthServer.Core.Models;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;
using AuthServer.Core.Dtos;

namespace AuthServer.Service.Services;

public class UserService : IUserService
{
    private readonly UserManager<UserApp> _userManager;
    public UserService(UserManager<UserApp> userManager)
    {
        _userManager = userManager;
    }
    public async Task<Response<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
    {
        var user = new UserApp { UserName = createUserDto.UserName, Email = createUserDto.Email, City = null };
        var result = await _userManager.CreateAsync(user, createUserDto.Password);
        if (!result.Succeeded)
        {
            return Response<UserAppDto>.Fail(string.Join(",", result.Errors.Select(x => x.Description)), 400, true);
        }
        var userDto = new UserAppDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            City = user.City
        };
        return Response<UserAppDto>.Success(userDto, 200);
    }
    public async Task<Response<UserAppDto>> GetUserByNameAsync(string UserName)
    {
        var user = await _userManager.FindByNameAsync(UserName);
        if (user == null)
        {
            return Response<UserAppDto>.Fail("User not found.", 404, true);
        }
        var userDto = new UserAppDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            City = user.City
        };
        return Response<UserAppDto>.Success(userDto, 200);
    }
}
