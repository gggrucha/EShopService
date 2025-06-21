using AutoMapper;
using User.Domain.Models.Response;
using User.Domain.Repositories;

namespace User.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IMapper _mapper;
        private readonly UsrDataContext _db;

        public UserService(IMapper mapper, UsrDataContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public UserResponseDTO GetUser(int userId)
        {
            var user = _db.Users.Find(userId);
            /*var user = new User.Domain.Models.Entities.User() { 
                Username = "aaa", 
                PasswordHash = "asas",
                IsActive=true, Id = userId, 
                Email= "User@email.commmm" 
            };*/

            if (user == null)
                throw new Exception("Record not found");

            return _mapper.Map<UserResponseDTO>(user);
        }
    }
}
