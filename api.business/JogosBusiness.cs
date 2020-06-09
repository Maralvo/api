using api.facade;
using api.interfaces;
using api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.business
{
    public class JogosBusiness : IJogos
    {
        private readonly JogosFacade jogosFacade;
        public JogosBusiness()
        {
            jogosFacade = new JogosFacade();
        }

        public void Delete(Jogo jogo)
        {
            jogosFacade.Delete(jogo);
        }

        public Jogo GetJogoById(int? id)
        {
            return jogosFacade.GetJogoById(id);
        }

        public IList<Jogo> GetJogos()
        {
            return jogosFacade.GetJogos();
        }

        public void InsertNew(Jogo jogo)
        {
            jogosFacade.InsertNew(jogo);
        }

        public void Update(Jogo jogo)
        {
            jogosFacade.Update(jogo);
        }
    }
}
