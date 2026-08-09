using System;

namespace Project01_MiniBankApp.src.Interfaces;

public interface ITransactionLogger
{
    void Log(Guid accountId, string operation, decimal amount, decimal balanceAfter); //Yeni bir işlem gerçekleştiğinde işlemin her detayını kaydedecek
    List<string> GetHistory(Guid accountId); //Hesabın işlem geçmişini görüntüleyecek
}
