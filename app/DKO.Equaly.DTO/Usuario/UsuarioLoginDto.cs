using System;

namespace DKO.Equaly.DTO.Usuario
{
    public class UsuarioLoginDto 
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public Boolean LembrarMe { get; set; }
    }
}
