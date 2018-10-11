using Repositorys.Repositroy.Specific;
using Repositorys.Repositroy.Specific.Mapping;
using System;

using Unity;
using Profess_CoreSkillRepositroy = Repositorys.Repositroy.Specific.Mapping.Profess_CoreSkillRepositroy;

namespace UserInfoDomain
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

            container.RegisterType<IUserRepositroy, UserRepositroy>();
            container.RegisterType<IMenuRepositroy, MenuRepositroy>();
            container.RegisterType<IRoleRepositroy, RoleRepositroy>();
            container.RegisterType<IUserInfoRepositroy, UserInfoRepositroy>();

            container.RegisterType<IAssessRepositroy, AssessRepositroy>();
            container.RegisterType<IAssessInfoRepositroy, AssessInfoRepositroy>();

            container.RegisterType<IProfessRepositroy, ProfessRepositroy>();
            container.RegisterType<ICoreSkillRepositroy, CoreSkillRepositroy>();
            container.RegisterType<ICoreLeverRepositroy, CoreLeverRepositroy>();
            container.RegisterType<ITeachSkillRepositroy, TeachSkillRespositroy>();
            container.RegisterType<ITeachLeverRepositroy, TeachLeverRepositroy>();

            container.RegisterType<IUser_RoleRepositroy, User_RoleRepositroy>();
            container.RegisterType<IRole_MenuRepositroy, Role_MenuRepositroy>();
            container.RegisterType<IProfess_CoreSkillRepositroy, Profess_CoreSkillRepositroy>();
            container.RegisterType<IProfess_TeachSkillRepositroy, Profess_TeachSkillRepositroy>();
            container.RegisterType<IRole_ProfessRepositroy, Role_ProfessRepositroy>();
        }
    }
}