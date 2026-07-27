using BranchServer.Models;

namespace BranchServer.Services;

public class SaleService
{
    public Sale CreateSale(Sale sale)
    {
        LocalStorage.Sales.Add(sale);

        LocalStorage.PendingSync.Add(sale);

        return sale;
    }
}