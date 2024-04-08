using Core.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
namespace BemCase.Domain.Entities;
public class AppRole : IdentityRole<int>, IEntity
{
    public DateTime Created { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
}
