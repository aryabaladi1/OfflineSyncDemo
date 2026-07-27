using CentralServer.Models;

namespace CentralServer.Services;

public static class CentralStorage
{
    public static List<Sale> Sales { get; } = new();
}