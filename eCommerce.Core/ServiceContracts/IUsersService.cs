using eCommerce.Core.Dto;

namespace eCommerce.Core.ServiceContracts;

public interface IUsersService
{
    /// <summary>
    /// Method to handle user login use case and 
    /// return an authenticationResponse object that contains status of login
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
    /// <summary>
    /// Method to handle user registration use case and 
    /// return an authenticationResponse object that contains status of user registration
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Registration(RegisterRequest registerRequest);
}
