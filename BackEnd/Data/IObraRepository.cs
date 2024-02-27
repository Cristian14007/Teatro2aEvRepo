using BackEnd.Models;

namespace BackEnd.Data
{
    public interface IObraRepository
    {
        List<Obra> GetAll();
        void Add(Obra obra);
        Obra Get(int id);
        void Update(Obra obra);
        void Delete (int id);


    }
}