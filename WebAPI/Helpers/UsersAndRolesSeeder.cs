using Domain.Entities;
using Infrastructure.Data;

namespace WebAPI
{
    public class UsersAndRolesSeeder
    {
        private readonly MyIntentionsContext _intentionsContext;

        public UsersAndRolesSeeder(MyIntentionsContext intentionsContext)
        {
            _intentionsContext = intentionsContext;
        }

        public void Seed()
        {
            if(_intentionsContext.Database.CanConnect())
            {
                if(!_intentionsContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _intentionsContext.Roles.AddRange(roles);
                    _intentionsContext.SaveChanges();
                }    

                if(!_intentionsContext.Users.Any())
                {

                }
            }    
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };

            return roles;
        }

    }
}
