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
        private readonly JogosFacade _jogosFacade;
        public JogosBusiness(JogosFacade jogosFacade)
        {
            _jogosFacade = jogosFacade;
        }

        public void Delete(Jogo jogo)
        {
            _jogosFacade.Delete(jogo);
        }

        public Jogo GetJogoById(int? id)
        {
            return _jogosFacade.GetJogoById(id);
        }

        public IList<Jogo> GetJogos()
        {
            return _jogosFacade.GetJogos();
        }

        public void InsertNew(Jogo jogo)
        {
            _jogosFacade.InsertNew(jogo);
        }

        public void Update(Jogo jogo)
        {
            _jogosFacade.Update(jogo);
        }
    }
}
