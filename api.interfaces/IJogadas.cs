using api.Models;
using System.Collections.Generic;

namespace api.interfaces
{
    public interface IJogadas
    {
        IList<Jogada> GetJogadas();
        Jogada GetJogadaById(int? id);
        void InsertNew(Jogada jogada);
        void Update(Jogada jogada);
        void Delete(Jogada jogada);
    }
}
