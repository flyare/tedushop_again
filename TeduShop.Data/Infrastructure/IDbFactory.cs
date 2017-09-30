namespace TeduShop.Data.Infrastructure
{
    public interface IDbFactory : System.IDisposable
    {
        TeduShopDbContext Init();
    }
}