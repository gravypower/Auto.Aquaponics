namespace Auto.Aquaponics.Kernel.Persistence
{
    public interface IMemento<in TData>
    {
        void Save(string systemKey, string type, string key, TData data);
        T Load<T>(string systemKey, string type, string key);
    }
}
