using Application.DTOs;
using Application.Interfaces;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly RegisterUserUseCase _useCase;
        public UserController(IUserRepository repo)
        {
            _useCase = new RegisterUserUseCase(repo);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserRequest request)
        {
            var result = _useCase.Execute(request);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}