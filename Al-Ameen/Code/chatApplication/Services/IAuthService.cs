using System.Collections.Generic;
using System.Threading.Tasks;
using chatApplication.Models;
using chatApplication.ViewModels;

namespace chatApplication.Services
{
    public interface SigInManager
    {
        Task<AuthModel> RegisterAsync(VM_CreateUser user, string role = "Customer", bool isIndividual = false);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
        public Task addRoomCustomerAsync(List<Room> rooms, bool isIndividual, myUser myuser);
        //Task SininAsync(string PhoneNumber);
        //Task SinoutAsync();
    }
}