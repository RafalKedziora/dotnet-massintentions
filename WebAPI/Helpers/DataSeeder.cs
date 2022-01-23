using Domain.Entities;
using Infrastructure.Data;

namespace WebAPI
{
    public class DataSeeder
    {
        private readonly MyIntentionsContext _intentionsContext;

        public DataSeeder(MyIntentionsContext intentionsContext)
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

                if(!_intentionsContext.Categories.Any())
                {
                    var categories = GetCategories();
                    _intentionsContext.Categories.AddRange(categories);
                    _intentionsContext.SaveChanges();
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

        private IEnumerable<Category> GetCategories()
        {
            var categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Powszednia"
                },
                new Category()
                {
                    Name = "Niedzielna"
                },
                new Category()
                {
                    Name = "Pogrzeb"
                },
                new Category()
                {
                    Name = "Ślub"
                },
                new Category()
                {
                    Name = "Chrzest"
                },
                new Category()
                {
                    Name = "Bierzmowanie"
                },
                new Category()
                {
                    Name = "Pierwsza Komunia Święta"
                }
            };
            return categories;
        }

    }
}
