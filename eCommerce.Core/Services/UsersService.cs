using AutoMapper;
using eCommerce.Core.Dto;
using eCommerce.Core.Entities;
using eCommerce.Core.Entities.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Core.Services;

internal class UsersService : IUsersService
{
    private readonly IUserRepository _usersRepository;
    private readonly IMapper _mapper;
    public UsersService(IUserRepository usersRepository, IMapper mapper)
    {
        _usersRepository = usersRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await
            _usersRepository.GetUserByEmailAndPassword
            (loginRequest.Email, loginRequest.Password);
        if (user == null)
        {
            return null;
        }
        // return new AuthenticationResponse
        // (user.UserId, user.Email, user.Gender, user.PersonName, "Token", Success: true);

        return _mapper.Map<AuthenticationResponse>(user) with
        {
            Success = true,
            Token = "Token"
        };
    }

    public async Task<AuthenticationResponse?> Registration(RegisterRequest registerRequest)
    {
        ApplicationUser newUser = _mapper.Map<ApplicationUser>(registerRequest);
        ApplicationUser? registeredUser = await _usersRepository.AddUser(newUser);
        if (registeredUser == null)
        {
            return null;
        }
        return _mapper.Map<AuthenticationResponse>(registeredUser) with {
            Success = true,
            Token = "Token" 
        };
    }
}
