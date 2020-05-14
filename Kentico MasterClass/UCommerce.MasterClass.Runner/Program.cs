using System;
using System.Linq;
using UCommerce.MasterClass.BusinessLogic.Queries;
using NHibernate.Linq;
using UCommerce.EntitiesV2;
using UCommerce.Infrastructure;

namespace MyUCommerceApp.Integration
{
	class Program
	{
		static void Main(string[] args)
		{
		    log4net.Config.BasicConfigurator.Configure();

		    var order = ObjectFactory
		        .Instance
		        .Resolve<IRepository<PurchaseOrder>>()
		        .Select(new LatestOrderQuery()).ToList();
        }
    }
}
