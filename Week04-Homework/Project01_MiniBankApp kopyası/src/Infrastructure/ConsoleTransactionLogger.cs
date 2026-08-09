using System;
using Project01_MiniBankApp.src.Interfaces;

namespace Project01_MiniBankApp.src.Infrastructure;

public class ConsoleTransactionLogger : ITransactionLogger
{
    private readonly Dictionary<Guid, List<string>> _history = new();

    public List<string> GetHistory(Guid accountId)
    {
        if (_history.TryGetValue(accountId, out var logs))
        {
            return logs;
        }

        return new List<string>();
    }

    public void Log(Guid accountId, string operation, decimal amount, decimal balanceAfter)
    {
        string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] Hesap ID: {accountId} | İşlem: {operation} | Tutar: {amount:C2} | Kalan Bakiye: {balanceAfter:C2}";
        
        Console.WriteLine($"[LOG] {logMessage}");

        if (!_history.ContainsKey(accountId))
        {
            _history[accountId] = new List<string>();
        }

        _history[accountId].Add(logMessage);
    }
}
