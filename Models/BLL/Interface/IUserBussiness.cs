using Amos.VTUCORE3._1.Models.DomainModels;
using Amos.VTUCORE3._1.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using MVCTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.BLL.Interface
{
    public interface IUserBussiness
    {
        /// <summary>
        /// ...Saves user infromation to db 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> SaveUser(UserDM model);

        int TotalCountOfUsers(string sSearch);

        List<ManageUserWallet> SearchUser(string searchText, int pageNo, int pageSize);

        List<ManageUserWallet> GetUserRecords(int pageNo, int pageSize);

        int TotalCountOfUsers();
    }
}
