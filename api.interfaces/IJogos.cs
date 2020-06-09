using api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.interfaces
{
    public interface IJogos
    {
        IList<Jogo> GetJogos();
        Jogo GetJogoById(int? id);
        void InsertNew(Jogo jogo);
        void Update(Jogo jogo);
        void Delete(Jogo jogo);
    }
}
