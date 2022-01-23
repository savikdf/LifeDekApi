using LifeDekApi.Services.Interfaces;
using LifeDekApi.Dtos;
using Microsoft.AspNetCore.Mvc;
using LifeDekApi.Services;

namespace LifeDekApi.Controllers;

[ApiController]
[Route("users")] //[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController()
    {
        userService = new UserService();   
    }

    //public CardController() : this(new CardService()) { }

    //public CardController(ICardService cardService)
    //{
    //    this.cardService = cardService;
    //}

    //GET /cards/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(Guid id)
    {
        try
        {
            UserDto user = userService.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);

        }
        catch (Exception ex)
        {
            throw new ApplicationException($"GetUser() of UserController thew an error: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser(UserDto request)
    {
        try
        {
            if (request == null)
            {
                return BadRequest("A new User cannot be empty.");
            }

            UserDto createdUser = userService.CreateUser(request);
            return Ok(createdUser);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"CreateUser() of UserController thew an error: {ex.Message}");
        }
    }

    [HttpPut]
    public async Task<ActionResult<UserDto>> UpdateUser(UserDto request)
    {
        try
        {
            UserDto updatedUser = userService.UpdateUser(request);
            if (updatedUser == null)
            {
                return BadRequest("Updates were unable to be made for this request.");
            }
            return Ok(updatedUser);

        }
        catch (Exception ex)
        {
            throw new ApplicationException($"UpdateUser() of UserController thew an error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<UserDto>> DeleteUser(Guid id)
    {
        try
        {
            UserDto deletedUser = userService.DeleteUser(id);
            if (deletedUser == null)
            {
                return BadRequest("No User found to delete with that Id.");
            }
            return Ok(deletedUser);

        }
        catch (Exception ex)
        {
            throw new ApplicationException($"DeleteUser() of UserController thew an error: {ex.Message}");
        }
    }

}
