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
            // Ejemplo para agregar un estudiante
            var nuevoEstudiante = new Estudiante
            {
                Nombre = "Nuevo",
                Apellido = "Estudiante",
                CI = "123456",
                Carrera = "Ingeniería"
            };
            Estudiantes.Add(nuevoEstudiante);
            await FileService.SaveEstudiantesAsync(Estudiantes.ToList());
        }

        private async void OnDeleteStudentClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var estudiante = button.BindingContext as Estudiante;

            if (estudiante != null)
            {
                Estudiantes.Remove(estudiante);
                await FileService.SaveEstudiantesAsync(Estudiantes.ToList());
            }
        }

    }

}
