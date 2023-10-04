using AutoMapper;
using Dating_API.DTO;
using Dating_API.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _user;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository user,IMapper mapper)
        {
            _user=user;
            _mapper=mapper;
        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetallUsers(){
            var users= await _user.GetMembersAsync();
            return Ok(users);
        }
       
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username){
            return await _user.GetMemberAsync(username);
        }
    }
}