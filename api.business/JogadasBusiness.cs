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
        private readonly JogadaFacade _jogadaFacade;
        public JogadasBusiness(JogadaFacade jogadaFacade)
        {
            _jogadaFacade = jogadaFacade;
        }

        public void Delete(Jogada jogada)
        {
            _jogadaFacade.Delete(jogada);
        }

        public Jogada GetJogadaById(int? id)
        {
            return _jogadaFacade.GetJogadaById(id);
        }

        public IList<Jogada> GetJogadas()
        {
            return _jogadaFacade.GetJogadas();
        }

        public void InsertNew(Jogada jogada)
        {
            _jogadaFacade.InsertNew(jogada);
        }

        public void Update(Jogada jogada)
        {
            _jogadaFacade.Update(jogada);
        }
    }
}
