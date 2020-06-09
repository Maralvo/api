using api.facade;
using api.interfaces;
using api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace api.business
{
    public class JogadasBusiness : IJogadas
    {
        private readonly JogadaFacade jogadaFacade;
        public JogadasBusiness()
        {
            jogadaFacade = new JogadaFacade();
        }

        public void Delete(Jogada jogada)
        {
            jogadaFacade.Delete(jogada);
        }

        public Jogada GetJogadaById(int? id)
        {
            return jogadaFacade.GetJogadaById(id);
        }

        public IList<Jogada> GetJogadas()
        {
            return jogadaFacade.GetJogadas();
        }

        public void InsertNew(Jogada jogada)
        {
            jogadaFacade.InsertNew(jogada);
        }

        public void Update(Jogada jogada)
        {
            jogadaFacade.Update(jogada);
        }
    }
}
