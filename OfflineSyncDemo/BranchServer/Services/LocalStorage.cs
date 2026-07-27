using BranchServer.Models;

namespace BranchServer.Services;

public static class LocalStorage
{
    public static List<Sale> Sales { get; } = new();

    public static List<Sale> PendingSync { get; } = new();
}