using System.Security.Cryptography;
using System.Text;
using API.DTOs;
using Dating_API.Data;
using Dating_API.Entity;
using Dating_API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController:BaseApiController
    {
        private readonly DataContext _db;
        private readonly ITokenServices _tokens;
        public AccountController(DataContext db,ITokenServices tokens)
        {
            _db=db;
            _tokens=tokens;
        }
        [HttpPost("register")] 
        public async Task<ActionResult<UserDto>> Register(RegisterDto r)
        {
            if(r.username==null){
                return BadRequest("UserName Is null");
            }
            else if(r.password==null){
                return BadRequest("password Is null");
            }
            else{
            
            if(await UserExists(r.username)) return BadRequest("UserName Is Taken");

            using var hmac=new HMACSHA512();
            AppUser u=new AppUser();
            u.Username=r.username.ToLower();
            u.PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(r.password));
            u.PasswordSalt=hmac.Key;
             _db.Users.Add(u);
            await _db.SaveChangesAsync();

                UserDto ad=new UserDto();
                ad.username=u.Username;
                ad.token=_tokens.CreateToken(u);
            return ad;
            }
        }

        [NonAction]
        public async Task<bool> UserExists(string UserName){
        return  await _db.Users.AnyAsync(u=>u.Username==UserName.ToLower());
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(loginDto l){
            var res=await _db.Users.SingleOrDefaultAsync(u=>u.Username==l.username);
            if(res==null) return Unauthorized("Invalid UserName");
            using  var hmac=new HMACSHA512(res.PasswordSalt);

            var computinghas=hmac.ComputeHash(Encoding.UTF8.GetBytes(l.password));
            for(int i=0;i<=computinghas.GetUpperBound(0);i++)
            {
                if(computinghas[i]!=res.PasswordHash[i])return Unauthorized("Invalid Password");
            }
            UserDto ad=new UserDto();
                ad.username=res.Username;
                ad.token=_tokens.CreateToken(res);
            return ad;
        }
    }
}