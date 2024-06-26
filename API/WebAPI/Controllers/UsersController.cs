
using System.Collections.Generic;
using System.Reflection;
using System.Security.Claims;
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

    [HttpPut]
    public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
    {
        var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var user = await _userRepository.GetUsersByUsernameAsync(username);
        if (user == null) return NotFound();
        _mapper.Map(memberUpdateDto, user);
        if (await _userRepository.SaveAllAsync()) return NoContent();
        return BadRequest("Failed to update user");
    }
}

