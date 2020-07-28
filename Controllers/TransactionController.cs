using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amos.VTUCORE3._1.Models.BLL.Interface;
using Amos.VTUCORE3._1.Models.DTO;
using Amos.VTUCORE3._1.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCTutorial.Models;
using Newtonsoft.Json;

namespace Amos.VTUCORE3._1.Controllers
{
    public class TransactionController : Controller
    {

        private readonly UserManager<UserProfile> _userManager;
        private readonly SignInManager<UserProfile> _signInManager;
        private readonly IUserBussiness _userBussiness;

        public TransactionController(UserManager<UserProfile> userManager, 
                                     SignInManager<UserProfile> signInManager,
                                     IUserBussiness userBussiness)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._userBussiness = userBussiness;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ManageWalletView()
        {
            return View("ManageWallet");
        }
      
        [AcceptVerbs("Post", "Get")]
        public IActionResult ManageWallet(DataTablesParam param, string EName)
        {
            List<ManageUserWallet> list = new List<ManageUserWallet>();

            int pageNo = 1;

            if (param.iDisplayStart >= param.iDisplayLength)
            {
                pageNo = (param.iDisplayStart / param.iDisplayLength) + 1;

            }

            int totalCount = 0; //total records in table 

            //Search by department,employeeName,and Country. 'param.sSearch' has the character from the implicit search on the view
            if (param.sSearch != null)
            {
                //get tottal count of search employee
                totalCount = _userBussiness.TotalCountOfUsers(param.sSearch);

                //retrieve the list of search of searched employee
                list = _userBussiness.SearchUser(param.sSearch, pageNo, param.iDisplayLength);

            }

            //Datatable Exrernal Search (by employeeName)
            else if (!string.IsNullOrEmpty(EName))
            {
                totalCount = _userBussiness.TotalCountOfUsers(EName);

                list = _userBussiness.SearchUser(EName, pageNo, param.iDisplayLength);

            }
             //Get All Employee without any search params
            else
            {
                
                totalCount = _userBussiness.TotalCountOfUsers();
                
                list = _userBussiness.GetUserRecords(pageNo, param.iDisplayLength);
                
            }
            return Json(new
            {
                aaData = list, // contains actual data to be posted.
                sEcho = param.sEcho,// tells the sequence of display.
                iTotalDisplayRecords = totalCount,//specify the total records to be displayed
                iTotalRecords = totalCount,// the total number of data posted

            });
              

        }
    }
}
