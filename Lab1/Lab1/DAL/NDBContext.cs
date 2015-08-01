using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab1.Models;
using NHibernate;
using NHibernate.Linq;

namespace Lab1
{
    public class NDBContext :IDisposable
    {
        public NDBContext():this(null)
        {

        }
        private ISession _session;        
        public NDBContext(ISession session)
        {
            if (session == null)
                session = _sessionFactory.OpenSession();
            _session = session;                       
            
        }

        public IQueryable<Employee2> Employees
        {
            get
            {
                return _session.Query<Employee2>();
            }
        }

        private static ISessionFactory _sessionFactory;

        public static void Init()
        {
            var configuration = ConfigurationHelper.CreateConfiguration();
            _sessionFactory = configuration.BuildSessionFactory();       
     
            NHibernate.Validator.Cfg.Environment.SharedEngineProvider=new NHibernate.Validator.Event.NHibernateSharedEngineProvider();            
            NHibernate.Validator.Engine.ValidatorEngine validatorEngine = NHibernate.Validator.Cfg.Environment.SharedEngineProvider.GetEngine();
 //           validatorEngine.Configure();

        }

        public ISession NewSession()
        {
            return _sessionFactory.OpenSession();
        }

        public void Save<T>(T item)
        {
            _session.SaveOrUpdate(item);
        }


        public void Dispose()
        {
            _session.Dispose();
        }
    }
}