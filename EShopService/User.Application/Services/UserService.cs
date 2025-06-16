using AutoMapper;
using User.Domain.Models.Response;

namespace User.Application.Services
{
    public class UserService: IUserService
    {
        private readonly IMapper _mapper;
        
        public UserService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserResponseDTO GetUser(int userId)
        {
            //var user = _db.Users.Find(userId);
            var user = new User.Domain.Models.Entities.User() { 
                Username = "aaa", 
                PasswordHash = "asas",
                IsActive=true, Id = userId, 
                Email= "User@email.commmm" 
            };
            if (user == null)
                throw new Exception("Record not found");

            return _mapper.Map<UserResponseDTO>(user);
        }
    }
}
