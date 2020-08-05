using Trackings.Application.Behaviors;
using Trackings.Application.Commands;
using Trackings.Application.Validations;
using Autofac;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace Trackings.API.Infrastructure.AutofacModules
{
    public class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            //builder.RegisterAssemblyTypes(typeof(CreateItemComponentCommand).GetTypeInfo().Assembly)
            //   .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            //builder.RegisterAssemblyTypes(typeof(CreateItemComponentValidator).GetTypeInfo().Assembly)
            //.Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            //.AsImplementedInterfaces();
            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
