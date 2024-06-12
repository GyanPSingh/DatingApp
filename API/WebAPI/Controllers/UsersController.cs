
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTOs;
using WebAPI.Entities;
using WebAPI.interfaces;

namespace WebAPI.Controllers;


[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UsersController(IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        this._userRepository = userRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MembetDto>>> GetUsers()
    {
        var users = await _userRepository.GetMembersAsync();
        //var userToReturn = _mapper.Map<IEnumerable<MembetDto>>(users);
        return Ok(users);
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MembetDto>> GetUser(string username)
    {
        return await _userRepository.GetMemberAsync(username);      
    }
}

