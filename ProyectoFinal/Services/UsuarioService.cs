using ProyectoFinal.Models;
using ProyectoFinal.Services;
using System.Text.Json;


namespace ProyectoFinal.Services
{
    public static class UsuarioService
    {
        private static readonly string FilePath = Path.Combine(FileSystem.AppDataDirectory, "usuarios.json");

        // Carga los usuarios desde un archivo JSON
        public static async Task<List<Usuario>> LoadUsuariosAsync()
        {
            if (!File.Exists(FilePath))
            {
                // Crear un archivo con un usuario predeterminado si no existe
                var usuariosPredeterminados = new List<Usuario>
                {
                    new Usuario { NombreUsuario = "admin", Contraseña = "1234" }
                };

                var json = JsonSerializer.Serialize(usuariosPredeterminados);
                await File.WriteAllTextAsync(FilePath, json);
                return usuariosPredeterminados;
            }

            // Leer y deserializar usuarios desde el archivo
            var fileContent = await File.ReadAllTextAsync(FilePath);
            return JsonSerializer.Deserialize<List<Usuario>>(fileContent);
        }

        // Guarda los usuarios en el archivo JSON
        public static async Task SaveUsuariosAsync(List<Usuario> usuarios)
        {
            var json = JsonSerializer.Serialize(usuarios);
            await File.WriteAllTextAsync(FilePath, json);
        }
    }
}
