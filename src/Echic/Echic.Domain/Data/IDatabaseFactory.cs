namespace Echic.Domain.Data
{
    public interface IDatabaseFactory
    {
        BaseDbContext Get();
    }
}