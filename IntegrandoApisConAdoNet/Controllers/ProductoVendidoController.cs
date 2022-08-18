using IntegrandoApisConAdoNet.Model;
using IntegrandoApisConAdoNet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IntegrandoApisConAdoNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoVendidoController : ControllerBase
    {

        //Traer Productos vendidos
        [HttpGet(Name = "GetProductosVendidos")]
        public List<ProductoVendido> GetProductosVendidos()
        {
            return ProductoVendidoHandler.GetProductosVendidos();
        }

    }
}
