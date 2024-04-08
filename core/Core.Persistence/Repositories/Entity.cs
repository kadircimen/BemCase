namespace Core.Persistence.Repositories;
public class Entity : IEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; } = DateTime.Now;
    public bool IsActive { get; set; } = true;
    public Entity() { }
    public Entity(int id)
    {
        Id = id;
    }
}
