using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Dating_API.Entity;
using Microsoft.EntityFrameworkCore;

namespace Dating_API.Data
{
    public class seed
    {
        public static async Task SeedUser(DataContext context)
        {
            if(await context.Users.AnyAsync()) return ;

            var userData= await File.ReadAllTextAsync("Data/UserSeedData.json");

            var options=new JsonSerializerOptions{PropertyNameCaseInsensitive=true};
            
            var users=JsonSerializer.Deserialize<List<AppUser>>(userData);
            
            foreach(var user in users){
               using var hmac=new HMACSHA512();
               user.Username=user.Username.ToLower();
               user.PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes("Pa$$w0rd")); 
               user.PasswordSalt=hmac.Key;

               context.Users.Add(user);
            }
            await context.SaveChangesAsync();
        }
    }
}