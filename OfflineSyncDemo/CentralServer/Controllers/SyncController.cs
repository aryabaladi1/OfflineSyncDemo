using CentralServer.Models;
using CentralServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace CentralServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SyncController : ControllerBase
{
    [HttpPost("sales")]
    public IActionResult ReceiveSales(List<Sale> sales)
    {
        CentralStorage.Sales.AddRange(sales);

        return Ok(new
        {
            received = sales.Count
        });
    }


    [HttpGet("sales")]
    public IActionResult GetSales()
    {
        return Ok(CentralStorage.Sales);
    }
}