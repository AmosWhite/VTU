using Amos.VTUCORE3._1.Models.BLL.Interface;
using Amos.VTUCORE3._1.Models.DTO;
using Amos.VTUCORE3._1.Models.Repo;
using Amos.VTUCORE3._1.Models.Repo.Infrastructure.Contract;
using Amos.VTUCORE3._1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.BLL
{
    public class AirtimeBussiness : IAirtimeBussiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AirtimeRepository _airtimeRepo;

        public AirtimeBussiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._airtimeRepo = new AirtimeRepository(_unitOfWork);
        }
        public bool EditAirtimeDetails(AirtimeDetailsVM model)
        {
            bool response = false;
            //Check if Description Exist
            if (_airtimeRepo.Exists(x => x.Id != model.Id && x.Description == model.Description))
                return response = false;

            //retrieve the data from db
            Airtime airtimeDTO = _airtimeRepo.SingleOrDefault(x => x.Id == model.Id);

            //Checking for null
            if (airtimeDTO != null)
            {
                // implement the changes
                airtimeDTO.Description = model.Description;
                airtimeDTO.Discount = model.Discount;

                //commit the changes to db
                try
                {
                    _airtimeRepo.Update(airtimeDTO);
                    response = true;
                }
                catch (Exception)
                {

                    response = false;
                }

            }
            return response;

        }

        public AirtimeDetailsVM GetAirtimeDetailById(int AirtimeId)
        {
            var airtimeDTO = _airtimeRepo.SingleOrDefault(x => x.Id == AirtimeId);

            AirtimeDetailsVM model = new AirtimeDetailsVM();

            model.Id = airtimeDTO.Id;
            model.Description = airtimeDTO.Description;
            model.Discount = airtimeDTO.Discount;
           

            return model;
        }

        public IEnumerable<AirtimeDetailsVM> GetAirtimeDetails(int productId)
        {
            IEnumerable<AirtimeDetailsVM> model = _airtimeRepo.GetAll(x => x.ProductId == productId)
                                                 .Select(x => new AirtimeDetailsVM
                                                 {
                                                     Id = x.Id,
                                                     Description = x.Description,
                                                     Discount = x.Discount
                                                 }).ToList();

            return model;

        }
    }
}
