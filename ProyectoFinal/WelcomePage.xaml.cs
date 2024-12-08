using ProyectoFinal.Services;
namespace ProyectoFinal
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var usuarios = await UsuarioService.LoadUsuariosAsync();
            var usuario = usuarios.FirstOrDefault(u =>
                u.NombreUsuario == UsernameEntry.Text &&
                u.Contrase�a == PasswordEntry.Text);

            if (usuario != null)
            {
                // Navegaci�n a AttendancePage
                await Shell.Current.GoToAsync("//AttendancePage");
            }
            else
            {
                // Mostrar mensaje de error
                ErrorMessage.Text = "Usuario o contrase�a incorrectos. Intente de nuevo.";
                ErrorMessage.IsVisible = true;
            }
        }
    }
}
