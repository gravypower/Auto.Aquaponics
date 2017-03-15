namespace Auto.Aquaponics.Kernel.Persistence
{
    public interface IMemento<in TData>
    {
        void Save(string type, string key, TData data);
        T Load<T>(string type, string key);
    }
}
