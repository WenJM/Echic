namespace Echic.Core.Data
{
    public interface IDatabaseFactory
    {
        BaseDbContext Get();
    }
}