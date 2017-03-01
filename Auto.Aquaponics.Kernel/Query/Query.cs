namespace Auto.Aquaponics.Kernel.Query
{
    public abstract class Query
    {
        public virtual string QueryVerb { get; } = string.Empty;
        public abstract string Key { get; }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(QueryVerb))
            {
                return QueryVerb;
            }

            return GetType().FullName;
        }
    }
}