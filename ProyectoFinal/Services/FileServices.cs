using System.Text.Json;
using ProyectoFinal.Models;

namespace ProyectoFinal.Services
{
    public static class FileService
    {
        private static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "Listado.json");

        public static async Task<List<Estudiante>> LoadEstudiantesAsync()
        {
            if (!File.Exists(FilePath)) return new List<Estudiante>();

            var json = await File.ReadAllTextAsync(FilePath);
            return JsonSerializer.Deserialize<List<Estudiante>>(json) ?? new List<Estudiante>();
        }

        public static async Task SaveEstudiantesAsync(List<Estudiante> estudiantes)
        {
            var json = JsonSerializer.Serialize(estudiantes, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(FilePath, json);
        }
    }
}
