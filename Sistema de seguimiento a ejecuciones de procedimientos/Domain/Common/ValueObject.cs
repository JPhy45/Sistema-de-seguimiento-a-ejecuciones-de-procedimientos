namespace Domain.Domain.Common
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<Object> GetEqualityComponent();
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            var other = (ValueObject)obj;
            return this.GetEqualityComponent().SequenceEqual(other.GetEqualityComponent());
        }


    }
}
