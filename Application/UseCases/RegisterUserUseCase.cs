using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public RegisterUserResponse Execute(RegisterUserRequest request)
        {
            if (_userRepository.EmailExists(request.Email))
                return new RegisterUserResponse { Success = false, Message = "Email already registered!" };

            var user = new User(request.Email, request.Password);
            if (!user.IsValid())
                return new RegisterUserResponse { Success = false, Message = "Invalid user data!" };

            _userRepository.Save(user);
            return new RegisterUserResponse { Success = true, Message = "User registered successfully." };
        }
    }
}