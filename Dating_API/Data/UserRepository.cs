using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dating_API.DTO;
using Dating_API.Entity;
using Dating_API.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dating_API.Data
{
    public class UserRepository:IUserRepository
    {
        private readonly DataContext _db;
        private readonly IMapper _mapper;

        public UserRepository(DataContext db,IMapper mapper)
        {
            _db=db;
            _mapper = mapper;
        }

        public async Task<MemberDto> GetMemberAsync(string username)
        {
            //return await _db.Users.Where(x=>x.Username==username)
            //    .Select(user=>new MemberDto
            //    {
            //        id=user.id,
            //        City=user.City
            //    }
            //    ).SingleOrDefaultAsync();
            //automapper use

            return await _db.Users
                .Where(x => x.Username == username)
               .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
               .SingleOrDefaultAsync();
                
        }

        public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _db.Users.ProjectTo<MemberDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<IEnumerable<AppUser>> GetUserAsync()
        {
           return await _db.Users
           .Include(p=>p.Photos)
           .ToListAsync();
        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {
          return await _db.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
           return await _db.Users
           
           .Include(u=>u.Photos).FirstOrDefaultAsync(u=>u.Username==username);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _db.SaveChangesAsync()>0;
        }

        public void Update(AppUser user)
        {
            _db.Entry(user).State=EntityState.Modified;
        }
    }
}