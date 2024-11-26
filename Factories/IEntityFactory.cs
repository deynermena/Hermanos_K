namespace HermanosK.Factories
{
    public interface IEntityFactory<T> where T : class
    {
        T Create();
    }
}
