using BackEnd.Models;

namespace BackEnd.Business
{
    public interface IObraService
    {
        List<Obra> GetAll();
        void Add(Obra obra);
        Obra Get(int id);
        public void Update(int obraId, ObraUpdateDTO obraUpdate);
        void Delete (int id);


    }
}