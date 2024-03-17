using BackEnd.Models;

namespace BackEnd.Business
{
    public interface IObraService
    {
        List<ObraGetDTO> GetAll();
        void Add(ObraCreateDTO obraCreateDTO);
        ObraGetDTO Get(int id);

        /* ObraGetDTO GetDTO(int id); */
        public void Update(int id, ObraUpdateDTO obraUpdate);
        void Delete (int id);


    }
}