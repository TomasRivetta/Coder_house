using IntegrandoApisConAdoNet.Controllers.DTOS;
using IntegrandoApisConAdoNet.Model;
using IntegrandoApisConAdoNet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace IntegrandoApisConAdoNet.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {

        //Cargar Venta
        [HttpPost]
        public bool CargarVenta([FromBody] PostVenta venta)
        {
            try
            {
                return VentaHandler.CargarVenta(new Venta
                {
                    
                    Comentarios = venta.Comentarios,
                    IdUsuario = venta.IdUsuario

                });
            }
            catch (Exception ex)
            {
                return false;
                Console.WriteLine(ex.Message);
            }
        }

    }
}
