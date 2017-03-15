namespace Auto.Aquaponics.Kernel.Query
{
    public abstract class Query<TResult>
        where TResult: QueryResult
    {
        public virtual string QueryVerb { get; } = string.Empty;

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