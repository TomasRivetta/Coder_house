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

        //Traer Venta
        [HttpGet]
        public List<Venta> GetVentas()
        {
            return VentaHandler.GetVentas();
        }

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
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
