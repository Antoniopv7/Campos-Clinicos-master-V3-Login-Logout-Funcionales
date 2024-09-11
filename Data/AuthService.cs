using System.Threading.Tasks;

namespace Campos_Clinicos.Data
{
    public class AuthService
    {
        public async Task<bool> LoginAsync(string username, string password)
        {
            // Por ahora, vamos a aceptar cualquier combinación de usuario/contraseña
            // Reemplaza esto con una verificación real cuando tengas tu base de datos
            if (username == "admin" && password == "password"){
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }

    
}