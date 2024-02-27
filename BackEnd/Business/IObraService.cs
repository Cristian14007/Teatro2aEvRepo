using BackEnd.Models;

namespace BackEnd.Business
{
    public interface IObraService
    {
        List<Obra> GetAll();
        void Add(Obra obra);
        Obra Get(int id);
        void Update(Obra obra);
        void Delete (int id);


    }
}