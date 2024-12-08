namespace ProyectoFinal
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registro de rutas adicionales
            Routing.RegisterRoute("WelcomePage", typeof(WelcomePage));
            Routing.RegisterRoute("AttendancePage", typeof(AttendancePage));
            Routing.RegisterRoute("InfoPage", typeof(AboutPage));
        }
    }
}
