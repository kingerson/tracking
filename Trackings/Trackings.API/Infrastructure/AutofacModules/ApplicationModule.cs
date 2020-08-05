using Trackings.Application.Queries.Implementations;
using Trackings.Application.Queries.Interfaces;
using Trackings.Application.Queries.Mappers;
using Trackings.Domain.Aggregates;
using Trackings.Repository;
using Autofac;
using RealPlaza.Libs.Util;
using System;
using Trackings.Application.Queries;

namespace Trackings.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string _connectionString { get; }
        public ApplicationModule(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }
        protected override void Load(ContainerBuilder builder)
        {
            #region Queries
            builder.Register(c => new BrandQuery(_connectionString))
                .As<IBrandQuery>()
                .InstancePerLifetimeScope();

            builder.Register(c => new StateQuery(_connectionString))
               .As<IStateQuery>()
               .InstancePerLifetimeScope();

            #endregion

            #region Repositories
            //builder.Register(c => new ItemComponentRepository(_connectionString))
            //   .As<IItemComponentRepository>()
            //   .InstancePerLifetimeScope();
            #endregion
        }
    }
}
