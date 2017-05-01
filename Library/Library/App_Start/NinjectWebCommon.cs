[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Library.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Library.App_Start.NinjectWebCommon), "Stop")]

namespace Library.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Data.Context;
    using System.Data.Entity;
    using Data.Repositories.Base;
    using Data.Repositories.Base.Interfaces;
    using Data.Repositories.Book.Interfaces;
    using Data.Repositories.Book;
    using Data.Repositories.Writer;
    using Data.Repositories.Writer.Interfaces;
    using Data.Repositories.Publisher.Interfaces;
    using Data.Repositories.Publisher;
    using Services.Interfaces;
    using Services;
    using Data.Entities;
    using Microsoft.Owin.Security;
    using Ninject.Parameters;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using EasyFlights.Web.Infrastructure;
    using Microsoft.AspNet.Identity.Owin;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IAuthenticationManager>().ToMethod((context) => System.Web.HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
            kernel.Bind<IApplicationUserManager>().To<ApplicationUserManager>().InRequestScope();
            //// kernel.Bind<IUserStore<ApplicationUser>>().To<UserStore<ApplicationUser>>().InRequestScope();
            // kernel.Bind<IUserStore<ApplicationUser>>().To<ApplicationUserStore>().InRequestScope();

            //kernel.Bind<IdentityFactoryOptions<ApplicationUserManager>>()
            //    .ToMethod(x => new IdentityFactoryOptions<ApplicationUserManager>()
            //    {
            //        DataProtectionProvider = Startup.DataProtectionProvider
            //    });

            kernel.Bind<LibraryDatabaseContext>().ToSelf().InRequestScope();
            kernel.Bind<IDataContext>().To<LibraryDatabaseContext>().InRequestScope();

            kernel.Bind<IUserStore<ApplicationUser>>().To<ApplicationUserStore>().InRequestScope();

            //kernel.Bind<IUserStore<ApplicationUser>>()
            //    .To<UserStore<ApplicationUser>>().InRequestScope();
            //.WithConstructorArgument(new ConstructorArgument("context", new LibraryDatabaseContext()));

            kernel.Bind<IRepository<Data.Entities.Book>>().To<Repository<Data.Entities.Book>>().InRequestScope();
            kernel.Bind<IBookRepository>().To<BookRepository>().InRequestScope();
            kernel.Bind<IRepository<Data.Entities.Publisher>>().To<Repository<Data.Entities.Publisher>>().InRequestScope();
            kernel.Bind<IPublisherRepository>().To<PublisherRepository>().InRequestScope();
            kernel.Bind<IRepository<Data.Entities.Writer>>().To<Repository<Data.Entities.Writer>>().InRequestScope();
            kernel.Bind<IWriterRepository>().To<WriterRepository>().InRequestScope();

            kernel.Bind<ISearchService>().To<SearchService>().InRequestScope();
        }

        public class ApplicationUserStore : UserStore<ApplicationUser>
        {
            public ApplicationUserStore(LibraryDatabaseContext context)
                : base(context)
            {
            }
        }
    }
}
