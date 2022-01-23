namespace WhooberInfrastructure.Data.Seeding.DataGeneratorAbstractions
{
    public interface IDataGenerator<out TEntity>
    {
        TEntity Generate();
    }
}