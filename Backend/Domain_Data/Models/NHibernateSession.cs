using NHibernate;
using System.Web;

namespace Domain_Data.Models
{
    public class NHibernateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new NHibernate.Cfg.Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var domainConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Mappings\Domain.hbm.xml");
            configuration.AddFile(domainConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}
