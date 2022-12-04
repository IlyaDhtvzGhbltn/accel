using System;

namespace ShortLinkService.Web.Infrastructure
{
    public interface IFactory<out T>
    {
        T Create();
    }

    public class DbFactory<DbContext> : IFactory<DbContext>
    {
        private readonly Func<DbContext> _factory;
        public DbFactory(Func<DbContext> factory)
        {
            _factory = factory;
        }

        public DbContext Create()
        {
            return _factory();
        }
    }
}
