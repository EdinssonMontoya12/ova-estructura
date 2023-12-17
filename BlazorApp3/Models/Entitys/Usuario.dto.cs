using Microsoft.AspNetCore.Identity;

namespace OvaEstructura.Models.Entitys
{
    public class UsuarioLogin
    {
        public string? Email { get; set; }

        public string? Contrasenia { get; set; }
    }

    public class UsuarioRegister
    {
        public string? Username { get; set; }

        public string? Name { get; set; }

        public string? Lastname { get; set; }

        public string? Email { get; set; }

        public string? Contrasenia { get; set; }
    }

    public class UsuarioAuth : IdentityUser
    {
        public string? Name { get; set; }

        public string? Lastname { get; set; }

        public sbyte? Verificado { get; set; }
    }
}
