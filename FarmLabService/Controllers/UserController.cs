﻿using FarmLabService.Services;
using Microsoft.AspNetCore.Mvc;

namespace FarmLabService.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET api/UserItem/Billy@google.com
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    var user = await _userRepository.GetByIdAsync(id);

        //    if (user != null)
        //    {
        //        return Ok(new UserInfoXxxx(user));
        //    }

        //    return BadRequest("UserItem not registred");
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] UserItemXxxx item)
        //{
        //    try
        //    {
        //        if (item == null || !ModelState.IsValid)
        //        {
        //            return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
        //        }
        //        bool itemExists = await _userRepository.DoesItemExistAsync(item.Email);
        //        if (itemExists)
        //        {
        //            return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString());
        //        }
        //        await _userRepository.InsertAsync(item);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
        //    }
        //    return Ok(item);
        //}
    }
}
