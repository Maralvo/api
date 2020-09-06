using api.database;
using api.interfaces;
using api.Models;
using System.Collections.Generic;

namespace api.facade
{
    public class JogadaFacade : IJogadas
    {
        private readonly IJogadas _jogadas;

        public JogadaFacade(IJogadas jogadas)
        {
            _jogadas = jogadas;
        }

        public void Delete(Jogada jogada)
        {
            _jogadas.Delete(jogada);
        }

        public Jogada GetJogadaById(int? id)
        {
            return _jogadas.GetJogadaById(id);
        }

        public IList<Jogada> GetJogadas()
        {
            return _jogadas.GetJogadas();
        }

        public void InsertNew(Jogada jogada)
        {
            _jogadas.InsertNew(jogada);
        }

        public void Update(Jogada jogada)
        {
            _jogadas.Update(jogada);
        }
    }
}
