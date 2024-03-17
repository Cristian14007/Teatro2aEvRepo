using BackEnd.Data;
using BackEnd.Business;
using BackEnd.Models;
using Microsoft.VisualBasic;
using System.Diagnostics.Metrics;


namespace BackEnd.Business
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public List<UserGetDTO> GetAll()
        {
            var users = _userRepository.GetAll();
            return users;
        }


        public UserGetDTO Get(int id)
        {
            var user = _userRepository.Get(id);
            return user;
        }


        public void Add(UserCreateDTO userCreateDTO)
        {
            var user = new User();
            var mappedUser = user.mapFromCreateDto(userCreateDTO);
            _userRepository.Add(mappedUser);
        }

        public void Update(int id, UserUpdateDTO userUpdateDTO)
        {
            var UserGetDTO = _userRepository.Get(id);
            if (UserGetDTO == null)
            {
                throw new KeyNotFoundException($"Obra con Id {id} no encontrada.");
            }

            // Mapea los datos del DTO a la entidad Obra
            var user = UserGetDTO.ToUser();
            user.Name = userUpdateDTO.Name;
            user.Email = userUpdateDTO.Email;
            user.Password = userUpdateDTO.Password;

            // Llama al método Update del repositorio con la entidad Obra actualizada
            _userRepository.Update(user);
        }



        public void Delete(int id)
        {
            _userRepository.Delete(id);
        }
    }




}