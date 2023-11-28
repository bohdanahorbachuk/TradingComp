using BusinessLogic.Concrete;
using BusinessLogic.Interfaces;
using DAL.ADO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.Injection;
using Unity.Resolution;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnityContainer container;
        static string conn;

        protected override void OnStartup(StartupEventArgs e)
        {
            Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            base.OnStartup(e);
            conn = ConfigurationManager.ConnectionStrings["TC"].ConnectionString;
            ConfigureUnity();

            WindowLogin loginPage = container.Resolve<WindowLogin>();
            loginPage.Show();
        }

        private static void ConfigureUnity()
        {
            container = new UnityContainer().AddExtension(new Diagnostic());
            container.RegisterInstance<string>("conn", conn);
            container.RegisterType<IPersonDAL, PersonDAL>(new InjectionConstructor(new ResolvedParameter("conn")))
                .RegisterType<ISupplyDAL, SupplyDAL>(new InjectionConstructor(new ResolvedParameter("conn")))
                .RegisterType<IRolesDAL, RolesDAL>(new InjectionConstructor(new ResolvedParameter("conn")))
                .RegisterType<ICategoryDAL, CategoryDAL>(new InjectionConstructor(new ResolvedParameter("conn")))
                .RegisterType<IAuthManager, AuthManager>()
                .RegisterType<ISupplyManager, SupplyManager>();
        }
    }
}
