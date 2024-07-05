namespace Domain.Domain.Common
{
    public abstract class Entity
    {
        #region Properties
        public Guid Id { get; set; }
        #endregion


        protected Entity()
        {
            Id = Guid.NewGuid();
        }
        protected Entity(Guid id)
        {
            Id = id;
        }

    }
}
