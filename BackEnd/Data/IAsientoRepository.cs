using BackEnd.Models;
namespace BackEnd.Data;

public interface IAsientoRepository
{
    List<AsientoGetDTO> GetAll();
    
    void Add(Asiento asiento);
    Asiento Get(int id);
    //List<Asiento> GetFromFunction(int idObra, int num_asiento);
    void Update(Asiento asiento);
    void Delete(int id);

    void SaveChanges();
}