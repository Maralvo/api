using api.database;
using api.interfaces;
using api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.facade
{
    public class JogosFacade : IJogos
    {
        private readonly IJogos _jogos;
        public JogosFacade(IJogos jogos)
        {
            _jogos = jogos;
        }
        public void Delete(Jogo jogo)
        {
            _jogos.Delete(jogo);
        }

        public Jogo GetJogoById(int? id)
        {
            return _jogos.GetJogoById(id);
        }

        public IList<Jogo> GetJogos()
        {
            return _jogos.GetJogos();
        }

        public void InsertNew(Jogo jogo)
        {
            _jogos.InsertNew(jogo);
        }

        public void Update(Jogo jogo)
        {
            _jogos.Update(jogo);
        }
    }
}
