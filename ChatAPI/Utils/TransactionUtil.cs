using System;
using DataAccessLayer.Utils;
using Microsoft.Extensions.DependencyInjection;


namespace ChatAPI.Utils
{
    public class TransactionUtil
    {
        private readonly IServiceProvider _serviceProvider;
        public TransactionUtil(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public ITransactionManager GeTransactionObjectFromContainer()
        {
            return _serviceProvider.GetService<ITransactionManager>();
        }
    }
}
