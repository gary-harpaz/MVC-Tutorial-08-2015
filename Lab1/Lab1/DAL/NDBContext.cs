using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
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

        public IQueryable<Employee3> Employees
        {
            get
            {
                return _session.Query<Employee3>();
            }
        }

        private static ISessionFactory _sessionFactory;

        public static void InitOld()
        {
            var configuration = ConfigurationHelper.CreateConfiguration();
            _sessionFactory = configuration.BuildSessionFactory();       
     
            NHibernate.Validator.Cfg.Environment.SharedEngineProvider=new NHibernate.Validator.Event.NHibernateSharedEngineProvider();            
            NHibernate.Validator.Engine.ValidatorEngine validatorEngine = NHibernate.Validator.Cfg.Environment.SharedEngineProvider.GetEngine();
 //           validatorEngine.Configure();

        }

        public static void Init()
        {
           
            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(csb=>
                    {
                        csb.FromConnectionStringWithKey("dbConnection");
                    }))
                .Mappings(x => x.FluentMappings.AddFromAssembly(typeof(Employee3Map).Assembly))
           .BuildSessionFactory();

            NHibernate.Validator.Cfg.Environment.SharedEngineProvider = new NHibernate.Validator.Event.NHibernateSharedEngineProvider();
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