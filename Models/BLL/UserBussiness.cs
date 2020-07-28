using Amos.VTUCORE3._1.Models.BLL.Interface;
using Amos.VTUCORE3._1.Models.DomainModels;
using Amos.VTUCORE3._1.Models.DTO;
using Amos.VTUCORE3._1.Models.Repo;
using Amos.VTUCORE3._1.Models.Repo.Infrastructure.Contract;
using Amos.VTUCORE3._1.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.BLL
{
    public class UserBussiness : IUserBussiness
    {
        UserProfileRepository _userprofileRepo;
        private readonly IUnitOfWork _unitOfWork;
        public UserBussiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
           _userprofileRepo = new UserProfileRepository(_unitOfWork);
        }
        public async Task<bool> SaveUser(UserDM model)
        {
            bool result = false;
            //var user = new User()
            //{
            //    FirstName = model.FirstName,
            //    LastName = model.LastName,
            //    Email = model.Email,
            //    UserName = model.UserName
            //};

            //IdentityResult result = await userManager.CreateAsync(user, model.Password);

            return result;
        }

        public int TotalCountOfUsers()
        {
            int count = _userprofileRepo.GetAll().Count();
            return count;
        }

        public int TotalCountOfUsers(string Search)
        {
            string NormaliseSearch = Search.ToUpper();
            int totalount = _userprofileRepo.GetAll(x => x.UserName == NormaliseSearch ||
                                                x.PhoneNumber == NormaliseSearch ||
                                                x.NormalizedEmail == NormaliseSearch).Count();
            return totalount;

        }

        public List<ManageUserWallet> SearchUser(string searchText, int pageNo, int pageSize)
        {
            List<ManageUserWallet> list = new List<ManageUserWallet>();

            string normalisedSearchText = searchText.ToUpper();
            try
            {
                list = _userprofileRepo.GetPagedRecords(x => (x.NormalizedUserName.Contains(searchText) ||
                                                            x.NormalizedEmail.Contains(searchText) ||
                                                            x.PhoneNumber.Contains(searchText)),
                                                             y => y.UserName, pageNo, pageSize)
                                                             .Select(x => new ManageUserWallet
                                                             {
                                                                 CustomerFirstname = x.FirstName,
                                                                 CustomerId = x.Id,
                                                                 CustomerUserName = x.UserName,
                                                                 WalletBalance = x.Wallet
                                                             }).ToList();
                return list;
            }
            catch (Exception)
            {

                return list;
            }
           
        }

        public List<ManageUserWallet> GetUserRecords(int pageNo, int pageSize)
        {
            List<ManageUserWallet> List = new List<ManageUserWallet>();

            List = _userprofileRepo.GetPagedRecords(x => x.UserName, pageNo, pageSize)
                .Select(x => new ManageUserWallet
                {
                    CustomerFirstname = x.FirstName,
                    CustomerUserName = x.UserName,
                    CustomerId = x.Id,
                   WalletBalance= x.Wallet,
                }).ToList();

            return List;
            
        }
    }
}
