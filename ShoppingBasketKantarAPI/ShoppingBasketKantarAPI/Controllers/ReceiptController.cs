using Microsoft.AspNetCore.Mvc;
using ShoppingBasketKantarAPI.DTO;
using ShoppingBasketKantarAPI.Services.Interfaces;
using System.IO;

namespace ShoppingBasketKantarAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : Controller
    {
        private readonly IReceiptService _receiptService;
        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpPost]
        public IActionResult GetReceipt([FromBody] BasketDTO basket)
        {
            return File(_receiptService.GetReceiptAsync(basket), "application/pdf", "invoice.pdf");
        }
    }
}
