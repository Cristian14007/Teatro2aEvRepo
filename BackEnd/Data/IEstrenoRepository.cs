using System.Data;
using BackEnd.Models;

namespace BackEnd.Data
{
    public interface IEstrenoRepository
    {
        List<EstrenoGetDTO> GetAll();
        void Add(Estreno Estreno);
        EstrenoGetDTO Get(int id);

        /* EstrenoGetDTO GetDTO(int id); */
        void Update(Estreno Estreno);
        void Delete (int id);

        void SaveChanges();
    }
}
