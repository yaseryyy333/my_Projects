using chatApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatApplication.Hubs
{
    public class CahtHub:Hub
    {
        private readonly UserManager<myUser> _userManager;

        public CahtHub(UserManager<myUser> userManager)
        {
            this._userManager = userManager;
        }
        public async Task SendMessage(string userId,string message,int roomId,int type ,DateTime time)
        {
            string userNaem = _userManager.FindByIdAsync(userId).Result.UserName;
            await Clients.Others.SendAsync("ReceiveMessage", userNaem, message, roomId, type, time);
        }
    }
}
