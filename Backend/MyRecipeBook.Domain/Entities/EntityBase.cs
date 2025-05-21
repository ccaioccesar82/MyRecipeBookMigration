namespace MyRecipeBook.Domain.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
        public bool Active { get; protected set; } = true;


        public virtual void SetActivate(bool activate)
        {
            Active = activate;

        }

    }
}
