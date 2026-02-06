using Common.Helpers;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;

namespace BusinessLogicLayer.Services.UserServiceContainer;

public sealed class UserService
{
    private readonly IRepository<User> _userRepository;

    public UserService(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CreateUserAsync(User user, string password, CancellationToken cancellationToken = default)
    {
        user.PasswordHash = PasswordHasher.HashPassword(password);
        await _userRepository.AddAsync(user, cancellationToken);
    }
}
