using DapperTutorial.Api.Models;
using DapperTutorial.Dal;
using DapperTutorial.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using DapperTutorial.Api.App_Start;

namespace DapperTutorial.Api.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        private readonly IMapper _mapper = AutomapperConfig.Init();
        [HttpPost]
        [Route("AddProduct")]
        public async Task<IHttpActionResult> AddProduct([FromBody]ProductModel model)
        {
            bool success = false;
            if (model == null)
            {
                return BadRequest("Please provide the product");
            }
            try
            {
                Product product = _mapper.Map<Product>(model);
                success = await ProductDal.AddProduct(product);
            }
            catch (Exception ex)
            {
                success = false;
            }
            return Ok(success);
        }
        [HttpGet]
        [Route("GetProducts")]
        public async  Task<IHttpActionResult> GetProducts([FromUri]string ProductName)
        {                  
            try
            {                
                List<Product> products = await ProductDal.GetProducts(ProductName);
                List<ProductModel> productModels = _mapper.Map<List<ProductModel>>(products);
                return Ok(products);

            }
            catch (Exception ex)
            {
                return BadRequest("Oops something went wrongs");
            }            
        }
    }
}
