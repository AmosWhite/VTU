using Amos.VTUCORE3._1.Models.BLL.Interface;
using Amos.VTUCORE3._1.Models.DTO;
using Amos.VTUCORE3._1.Models.Repo;
using Amos.VTUCORE3._1.Models.Repo.Infrastructure.Contract;
using Amos.VTUCORE3._1.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.BLL
{
    public class ProductBussiness : IProductBussiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ProductRepository _productRepo;

        public ProductBussiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._productRepo = new ProductRepository(_unitOfWork);
        }

        public ProductVm GetProductById(int id)
        {
            Product product = _productRepo.SingleOrDefault(x => x.Id == id);

            ProductVm model = new ProductVm()
            {
                id = product.Id,
                Title = product.Title
            };

            return model;
        }

        public bool UpdateProduct(ProductVm model)
        {
            //Check if description is unique
            if (_productRepo.Exists(x => x.Id != model.id && x.Title == model.Title))
                return false;

            //model your Dto
            Product product = _productRepo.SingleOrDefault(x => x.Id == model.id);
            product.Title = model.Title;
            try
            {
                _productRepo.Update(product);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<ProductVm> GetAllProducts()
        {

            List<ProductVm> model = _productRepo.GetAll().Select(x => new ProductVm
            {
                id = x.Id,
                Title = x.Title
            }).ToList();

            return model;
        }
    }
}
