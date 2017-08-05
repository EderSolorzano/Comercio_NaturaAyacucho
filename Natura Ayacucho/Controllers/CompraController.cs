using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Natura_Ayacucho.Controllers
{
    public class CompraController : Controller
    {
        private Models.TiendaEntities1 bd = new Models.TiendaEntities1();
        // GET: Compra
        public ActionResult Paso1()
        {
            var cliente = bd.Cliente.Find(Helper.SessionHelper.GetUser());
            return View(cliente);
        }

        public ActionResult Paso2()
        {
            return View();
        }

        public ActionResult Paso4()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RealizarPedido(List<Pedidos> p)
        {
            // guardar en base de datos
            var clienteid = Helper.SessionHelper.GetUser();
        var pcab = new Models.Pedido
        {
            ClienteId = clienteid,
            Estado = "P",
                Fecha = DateTime.Now
    };

    bd.Pedido.Add(pcab);
            bd.SaveChanges();


            foreach (var item in p)
            {
                var pdet = new Models.PedidoDetalle
                {
                    PedidoId = pcab.PedidoId,
                    Cantidad = item.Cantidad,
                    ProductoId = item.ProductoId
                };
    bd.PedidoDetalle.Add(pdet);
                bd.SaveChanges();
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public class Pedidos
{
    public int ProductoId { get; set; }
    public string Denominacion { get; set; }
    public int Cantidad { get; set; }
    public string Imagen { get; set; }
    public decimal Precio { get; set; }
}
public ActionResult Paso3()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RealizarPedido(List<Pedido> p)
        {
            //guardar en bd
return Json(true, JsonRequestBehavior.AllowGet);
    }
    public class Pedido
    {
        public int ProductoId { get; set; }
        public string Denominacion { get; set; }
        public int Cantidad { get; set; }
        public string Imagen { get; set; }
        public decimal Precio { get; set; }
    }
}
}