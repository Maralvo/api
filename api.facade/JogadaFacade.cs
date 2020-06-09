using api.database;
using api.interfaces;
using api.Models;
using System.Collections.Generic;

namespace api.facade
{
    public class JogadaFacade : IJogadas
    {
        private readonly JogadasDatabase jogadasDatabase;

        public JogadaFacade()
        {
            jogadasDatabase = new JogadasDatabase();
        }

        public void Delete(Jogada jogada)
        {
            jogadasDatabase.Delete(jogada);
        }

        public Jogada GetJogadaById(int? id)
        {
            return jogadasDatabase.GetJogadaById(id);
        }

        public IList<Jogada> GetJogadas()
        {
            return jogadasDatabase.GetJogadas();
        }

        public void InsertNew(Jogada jogada)
        {
            jogadasDatabase.InsertNew(jogada);
        }

        public void Update(Jogada jogada)
        {
            jogadasDatabase.Update(jogada);
        }
    }
}
