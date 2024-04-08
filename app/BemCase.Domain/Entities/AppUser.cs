using Core.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BemCase.Domain.Entities;
public class AppUser : IdentityUser<int>, IEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
}
