using System.Net;
using System.Security.Claims;
using AutoMapper;
using CarsShop.Bll.Interfaces;
using CarsShop.Common.DTO.Address;
using CarsShop.Common.DTO.User;
using CarsShop.Common.Exceptions;
using CarsShop.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarsShop.APi.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
           var email = HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Email)
                ?.Value; 
                
            var user = await _userManager.FindByEmailAsync(email);

            return new UserDto
            {
                Email = user.Email,
                Token = _tokenService.CreateToken(user),
                UserName = user.UserName
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) 
                return Unauthorized(new RestException(HttpStatusCode.Unauthorized, "Wrong Password or Email"));

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) 
                return Unauthorized(new RestException(HttpStatusCode.Unauthorized, "Wrong Password or Email"));

            var token = _tokenService.CreateToken(user);
            
            return new UserDto
            {
                Email = user.Email,
                Token = token,
                UserName = user.UserName
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _userManager.Users.Where(x => x.Email == registerDto.Email).AnyAsync())
                throw new RestException(HttpStatusCode.BadRequest, new { Email = "Email already exists" });

            if (await _userManager.Users.Where(x => x.UserName == registerDto.UserName).AnyAsync())
                throw new RestException(HttpStatusCode.BadRequest, new { Username = "Username already exists" });

            var user = new User
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) 
                return BadRequest(new RestException(HttpStatusCode.BadRequest,"Problem to register"));

            return new UserDto
            {
                UserName = user.UserName,
                Token = _tokenService.CreateToken(user),
                Email = user.Email
            };
        }
        
        [Authorize]
        [HttpGet("address")]
        public async Task<ActionResult<AddressDto>> GetUserAddress()
        {
            var email = HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Email)
                ?.Value;
            
            var user = await _userManager.FindByEmailAsync(email);

            return _mapper.Map<Address, AddressDto>(user.Address);
        }

        [Authorize]
        [HttpPut("address")]
        public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto address)
        {
            var email = HttpContext
                .User
                .Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Email)
                ?.Value;
            
            
            
            var user = await _userManager.
                    Users
                    .Include(x => x.Address)
                    .FirstOrDefaultAsync( x => x.Email == email);

            user.Address = _mapper.Map<AddressDto, Address>(address);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) 
                return Ok(_mapper.Map<Address, AddressDto>(user.Address));

            return BadRequest("Problem updating the user");
        }
    }
}