namespace OncologyCore.Model
{
    public interface IIdentity<T>
    {
        int Id { get; set; }
        void UpdatePropertiesFrom(T that);
    }
}