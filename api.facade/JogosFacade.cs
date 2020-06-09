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
        private readonly JogosDatabase jogosDatabase;
        public JogosFacade()
        {
            jogosDatabase = new JogosDatabase();
        }
        public void Delete(Jogo jogo)
        {
            jogosDatabase.Delete(jogo);
        }

        public Jogo GetJogoById(int? id)
        {
            return jogosDatabase.GetJogoById(id);
        }

        public IList<Jogo> GetJogos()
        {
            return jogosDatabase.GetJogos();
        }

        public void InsertNew(Jogo jogo)
        {
            jogosDatabase.InsertNew(jogo);
        }

        public void Update(Jogo jogo)
        {
            jogosDatabase.Update(jogo);
        }
    }
}
