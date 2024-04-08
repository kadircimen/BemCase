namespace Core.Persistence.Repositories;
public interface IEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; }
    public bool IsActive { get; set; }
}
