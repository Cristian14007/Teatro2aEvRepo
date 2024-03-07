using System.Data;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface IObraRepository
    {
        List<ObraGetDTO> GetAll();
        void Add(Obra obra);
        ObraGetDTO Get(int id);

        /* ObraGetDTO GetDTO(int id); */
        void Update(ObraGetDTO obra);
        void Delete (int id);

        void SaveChanges();
    }
}