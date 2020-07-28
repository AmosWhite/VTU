using Amos.VTUCORE3._1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.BLL.Interface
{
    public interface IAirtimeBussiness
    {
        IEnumerable<AirtimeDetailsVM> GetAirtimeDetails(int productId);

        AirtimeDetailsVM GetAirtimeDetailById(int AirtimeID);

        bool EditAirtimeDetails(AirtimeDetailsVM model);


    }
}
