using System.Collections.Generic;
using DKO.EQualy.Domain.Entities;

namespace DKO.Equaly.DTO.Menu
{
    public class MenuSuperiorDto
    {
        public List<Mensagem> Mensagens { get; set; }
        public List<Atividade> Tarefas { get; set; }
        public EQualy.Domain.Entities.Usuario Usuario { get; set; }
    }
}