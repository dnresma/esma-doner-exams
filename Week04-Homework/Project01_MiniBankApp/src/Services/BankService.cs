using System;
using Project01_MiniBankApp.src.Accounts;
using Project01_MiniBankApp.src.Interfaces;

namespace Project01_MiniBankApp.src.Services;

public class BankService
{
    private readonly IRepository<Account> _accountRepository;
    private readonly ITransactionLogger _logger;

    public BankService(IRepository<Account> accountRepository, ITransactionLogger logger)
    {
        _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void CreateAccount(Account account)
    {
        if (account == null)
            throw new ArgumentNullException(nameof(account));

        _accountRepository.Add(account);
        _logger.Log(account.AccountId, "Hesap Açılışı", account.Balance, account.Balance);
    }

    public void Deposit(Guid accountId, decimal amount)
    {
        var account = _accountRepository.GetById(accountId);
        if (account == null)
            throw new InvalidOperationException($"'{accountId}' ID'li hesap bulunamadı!");

        account.Deposit(amount);
        _logger.Log(account.AccountId, "Para Yatırma", amount, account.Balance);
    }

    public bool Withdraw(Guid accountId, decimal amount)
    {
        var account = _accountRepository.GetById(accountId);
        if (account == null)
            throw new InvalidOperationException($"'{accountId}' ID'li hesap bulunamadı!");

        bool success = account.Withdraw(amount);
        if (success)
        {
            _logger.Log(account.AccountId, "Para Çekme", amount, account.Balance);
        }
        else
        {
            Console.WriteLine($"[HATA] Çekim işlemi başarısız! Vade günü dolmadı veya limit yetersiz!");
        }

        return success;
    }

    public bool Transfer(Guid senderId, Guid receiverId, decimal amount)
    {
        if (senderId == receiverId)
            throw new InvalidOperationException("Aynı hesaba transfer yapılamaz!");

        var sender = _accountRepository.GetById(senderId);
        var receiver = _accountRepository.GetById(receiverId);

        if (sender == null || receiver == null)
            throw new InvalidOperationException("Gönderici veya alıcı hesap bulunamadı!");

        
        bool withdrawSuccess = sender.Withdraw(amount);
        if (!withdrawSuccess)
        {
            Console.WriteLine("[HATA] Gönderici hesabın bakiyesi veya limiti yetersiz!");
            return false;
        }

        receiver.Deposit(amount);

        _logger.Log(sender.AccountId, $"Transfer (Alıcı Hesap -> {receiver.AccountId})", amount, sender.Balance);
        _logger.Log(receiver.AccountId, $"Transfer (Gönderen Hesap <- {sender.AccountId})", amount, receiver.Balance);

        return true;
    }
    public Account? GetAccount(Guid accountId)
    {
        return _accountRepository.GetById(accountId);
    }

    public List<Account> GetAllAccounts()
    {
        return _accountRepository.GetAll();
    }

    public List<string> GetTransactionHistory(Guid accountId)
    {
        return _logger.GetHistory(accountId);
    }

    public decimal CalculateAccountInterest(Guid accountId)
    {
        var account = _accountRepository.GetById(accountId);
        if (account == null)
            throw new InvalidOperationException($"'{accountId}' ID'li hesap bulunamadı!");

        return account.CalculateInterest();
    }

    public decimal PrintInterestReport(Guid accountId)
    {
        var account = _accountRepository.GetById(accountId);
        if (account == null)
            throw new InvalidOperationException($"'{accountId}' ID'li hesap bulunamadı!");

        decimal interest = CalculateAccountInterest(accountId);

        Console.WriteLine("\n---------------------------------------------");
        Console.WriteLine("          HESAP FAİZ DETAY RAPORU            ");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine($"        ID          : {account.AccountId}");
        Console.WriteLine($"        Müşteri     : {account.OwnerName}");
        Console.WriteLine($"        Hesap Tipi  : {account.GetAccountType()}");
        Console.WriteLine($"        Mevcut Bakiye: {account.Balance:C2}");
        Console.WriteLine($"        Tahmini Faiz: {interest:C2}");
        Console.WriteLine("=============================================\n");

        return interest;
    }
}


