using System.Collections.Generic;
using CadastroSerie.Intefaces;
using CadastroSerie.Classes;


namespace CadastroSerie.Repositorio
{
    public class SerieRepositorio : IRepositorio<Serie>    
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }
        public void Exclui(int id)
        {
            listaSerie[id].Inativar();
        }
        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }
        public List<Serie> Lista()
        {
            return listaSerie; 
        }
        public int ProximoId()
        {
            return listaSerie.Count;
        }
        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}