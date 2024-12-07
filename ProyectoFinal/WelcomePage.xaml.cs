using ProyectoFinal.Models;
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
            string username = UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (username == "admin" && password == "1234") // Cambia esto según tu lógica
            {
                await Navigation.PushAsync(new AttendancePage());
            }
            else
            {
                ErrorMessage.Text = "Usuario o contraseña incorrectos. Intente de nuevo.";
                ErrorMessage.IsVisible = true;
            }
        }
    }

}
