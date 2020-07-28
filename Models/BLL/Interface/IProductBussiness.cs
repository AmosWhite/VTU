using Amos.VTUCORE3._1.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amos.VTUCORE3._1.Models.BLL.Interface
{
    public interface IProductBussiness
    {
        /// <summary>
        ///...for retrieving product title
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ProductVm GetProductById(int id);

        /// <summary>
        /// ...for Editing product title
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        bool UpdateProduct(ProductVm title);

        /// <summary>
        ///...Retrieving all product
        /// </summary>
        /// <returns></returns>
        List<ProductVm> GetAllProducts();

    }
}
