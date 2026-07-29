namespace News.Application.Dtos;

public abstract class BaseEntity<TKey>
{
    public TKey Id { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreationDateTime { get; set; }
    public DateTime ModificationDateTime { get; set; }
}
public abstract class BaseEntity : BaseEntity<int>
{

}

