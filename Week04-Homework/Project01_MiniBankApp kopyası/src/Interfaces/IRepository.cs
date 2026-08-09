using System.Collections.Generic;

namespace Project01_MiniBankApp.src.Interfaces;

public interface IRepository<T> //Generic yapıda kullandık çünkü sonradan sisteme farklı sınıflar eklenebilir.
{
   void Add(T item); //T tipinde bir item eklenecek yani yeni bir hesap ekleyecek
   T? GetById(Guid id); //Kimliğe göre veri getirecek yani müşteri işlem yapmak istediğinde bize müşterinin benzersiz kimliği ile hesabını getirecek
   List<T> GetAll(); //Sistemdeki tüm hesapları döndürecek
   void Delete(Guid id); //T tipinde bir item silecek yani bir hesabı sistemden kaldıracak


}
