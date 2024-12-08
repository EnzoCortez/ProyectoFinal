using ProyectoFinal.Models;
using ProyectoFinal.Services;
using System.Collections.ObjectModel;

namespace ProyectoFinal
{
    public partial class AttendancePage : ContentPage
    {
        public ObservableCollection<Estudiante> Estudiantes { get; set; } = new ObservableCollection<Estudiante>();

        public AttendancePage()
        {
            InitializeComponent();
            LoadData();
            BindingContext = this;
        }

        private async void LoadData()
        {
            var estudiantes = await FileService.LoadEstudiantesAsync();
            foreach (var estudiante in estudiantes)
            {
                Estudiantes.Add(estudiante);
            }
        }

        private async void OnAddStudentClicked(object sender, EventArgs e)
        {
            // Crear un nuevo estudiante desde los campos del formulario
            var nuevoEstudiante = new Estudiante
            {
                Nombre = NombreEntry.Text,
                Apellido = ApellidoEntry.Text,
                CI = CIEntry.Text,
                Carrera = CarreraEntry.Text,
                TieneFalta = FaltaSwitch.IsToggled
            };

            Estudiantes.Add(nuevoEstudiante);
            await FileService.SaveEstudiantesAsync(Estudiantes.ToList());
            await DisplayAlert("Éxito", "Estudiante agregado correctamente.", "OK");

            // Limpiar los campos
            NombreEntry.Text = string.Empty;
            ApellidoEntry.Text = string.Empty;
            CIEntry.Text = string.Empty;
            CarreraEntry.Text = string.Empty;
            FaltaSwitch.IsToggled = false;
        }

        private async void OnDeleteStudentClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var estudiante = button.BindingContext as Estudiante;

            if (estudiante != null)
            {
                var confirm = await DisplayAlert("Confirmar", $"¿Eliminar a {estudiante.Nombre} {estudiante.Apellido}?", "Sí", "No");
                if (confirm)
                {
                    Estudiantes.Remove(estudiante);
                    await FileService.SaveEstudiantesAsync(Estudiantes.ToList());
                }
            }
        }
    }
}
