using BranchServer.Models;
using BranchServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BranchServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly SaleService _saleService;

    public SalesController(SaleService saleService)
    {
        _saleService = saleService;
    }


    [HttpPost]
    public IActionResult CreateSale(Sale sale)
    {
        var created = _saleService.CreateSale(sale);

        return Ok(created);
    }

    [HttpGet("pending")]
    public IActionResult GetPending()
    {
        return Ok(LocalStorage.PendingSync);
    }
}