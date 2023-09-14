namespace Chagas.Extensions.Entities
{
    public abstract class BaseEntity : Notifiable<Notification>
    {
        public abstract void Validate();
    }
}