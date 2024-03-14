
using BackEnd.Models;

namespace BackEnd.Business
{
    public interface IEstrenoService
    {
        List<EstrenoGetDTO> GetAll();
        void Add(EstrenoCreateDTO EstrenoCreateDTO);
        EstrenoGetDTO Get(int id);

        /* EstrenoGetDTO GetDTO(int id); */
        public void Update(int id, EstrenoUpdateDTO EstrenoUpdate);
        void Delete (int id);


    }
}