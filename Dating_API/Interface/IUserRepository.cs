using Dating_API.DTO;
using Dating_API.Entity;

namespace Dating_API.Interface
{
    public interface IUserRepository
    {
        void Update(AppUser u);
        Task<bool> SaveAllAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<IEnumerable<AppUser>> GetUserAsync();

        Task<AppUser> GetUserByUsernameAsync(string username);

        Task<IEnumerable<MemberDto>> GetMembersAsync();
        Task<MemberDto> GetMemberAsync(string username);
    }
}