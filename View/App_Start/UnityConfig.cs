using System;

using Unity;
using Models;
using Repositorys;
using Domains;

namespace View
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<IDomainLogin, DomainLogin>();
            container.RegisterType<IDomainLogout, DomainLogout>();
            container.RegisterType<IDomainOneselfAssess, DomainOneselfAssess>();
            container.RegisterType<IDomainOtherAssess, DomainOtherAssess>();
            container.RegisterType<IDomainRegist, DomainRegist>();
            container.RegisterType<IDomainSkillMapAssess, DomainSkillMapAssess>();
            container.RegisterType<IDomainUserCoreSkills, DomainUserCoreSkills>();
            container.RegisterType<IDomainUserInfo, DomainUserInfo>();
            container.RegisterType<IDomainUserTeachSkills, DomainUserTeachSkills>();


            container.RegisterType<IRepositoryCoreLever, RepositoryCoreLever>();
            container.RegisterType<IRepositoryCoreSkills, RepositoryCoreSkills>();
            container.RegisterType<IRepositoryJob, RepositoryJob>();
            container.RegisterType<IRepositoryMapingCore, RepositoryMapingCore>();
            container.RegisterType<IRepositoryMapingTeach, RepositoryMapingTeach>();
            container.RegisterType<IRepositoryRole, RepositoryRole>();
            container.RegisterType<IRepositoryRoleContent, RepositoryRoleContent>();
            container.RegisterType<IRepositoryTeachLever, RepositoryTeachLever>();
            container.RegisterType<IRepositoryTeachSkills, RepositoryTeachSkills>();
            container.RegisterType<IRepositoryUser, RepositoryUser>();
            container.RegisterType<IRepositoryUserInfo, RepositoryUserInfo>();
            container.RegisterType<IRepositroyAssess, RepositroyAssess>();
        }
    }
}