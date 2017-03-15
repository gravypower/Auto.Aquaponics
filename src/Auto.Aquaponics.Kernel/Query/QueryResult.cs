namespace Auto.Aquaponics.Kernel.Query
{
    public abstract class QueryResult
    {
        public override string ToString()
        {
            return GetType().FullName;
        }
    }
}