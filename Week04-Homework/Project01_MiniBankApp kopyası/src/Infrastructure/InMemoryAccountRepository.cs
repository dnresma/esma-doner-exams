using System;
using System.Collections.Generic;
using System.Linq;
using Project01_MiniBankApp.src.Accounts;
using Project01_MiniBankApp.src.Interfaces;

namespace Project01_MiniBankApp.src.Infrastructure;

public class InMemoryAccountRepository : IRepository<Account>
{
    private readonly Dictionary<Guid, Account> _accounts = new();
    // Anahtar guid yani hesap id'si, değer account yani hesap nesnesi

    public void Add(Account account)
    {
       if (account == null)
            throw new ArgumentNullException(nameof(account));

        // Dictionary'e eklerken Key olarak account.AccountId (Guid) kullanıyoruz
        if (!_accounts.TryAdd(account.AccountId, account))
        {
            throw new InvalidOperationException($"'{account.AccountId}' ID'li hesap zaten mevcut!");
        }
    }

    public Account? GetById(Guid id)
    {
        // Dictionary sayesinde doğrudan ID ile $O(1)$ hızında getiriyoruz
        _accounts.TryGetValue(id, out var account);
        return account;
    }

    public List<Account> GetAll()
    {
        // Dictionary'deki tüm değerleri (Values) Liste olarak geriye dönüyoruz
        return _accounts.Values.ToList();
    }

    public void Delete(Guid id)
    {
        if (!_accounts.ContainsKey(id))
            throw new Exception("Silinecek hesap bulunamadı.");

        _accounts.Remove(id);
    }
}
