> 1. Mimari Tasarım ve Nesne Yönelimli Programlama (OOP)

* Kapsülleme (Encapsulation): Account sınıfı içerisindeki bakiye (_balance) değişkenini private tutarak dışarıdan doğrudan müdahaleye kapattım. Bakiyenin yalnızca Deposit ve Withdraw metotlarındaki iş kurallarından (bakiye kontrolü, aktiflik durumu, limit takibi) geçtikten sonra güvenli bir şekilde güncellenmesini sağladım.  


* Kalıtım (Inheritance) ve Soyutlama (Abstraction): Account temel sınıfını abstract olarak kurgulayarak ortak özellikleri (ID, OwnerName, Balance vb.) tek bir merkezde topladım. CheckingAccount, SavingAccount ve PremiumAccount sınıflarını bu temel sınıftan türeterek kod tekrarının önüne geçtim.  


* Çok Biçimlilik (Polymorphism): CalculateInterest, CanWithdraw ve GetAccountType metotlarını soyut/sanal olarak tanımlayıp türetilen sınıflarda override ettim. Böylece BankService veya raporlama katmanı hesaba özel faiz kurallarını veya para çekme kısıtlarını bilmek zorunda kalmadan, polimorfik olarak her hesabın kendi iş kuralını çalıştırmasını sağladı.  


> 2. SOLID Prensipleri ve Esnek Yazılım Mimarisi

* Tek Sorumluluk Prensibi (SRP): Veri saklama işini InMemoryAccountRepository, loglama işini ConsoleTransactionLogger ve iş mantığı/bankacılık süreçlerini BankService üstlendi. Sorumluluklar tamamen ayrıştırılmış oldu.  


* Açık/Kapalı Prensibi (OCP): Sisteme üçüncü bir hesap türü olan PremiumAccount eklendiğinde; mevcut Account, BankService veya Repository kodlarında hiçbir değişiklik yapılması gerekmedi. Sistem yeni gelişmelere açık, mevcut kod değişimine kapalı tutuldu.  


* Bağımlılıkların Tersi Prensibi (DIP) ve Dependency Injection: BankService, somut sınıflara değil IRepository<Account> ve ITransactionLogger arayüzlerine (interface) bağımlı kılındı. Bu sayede bellekte çalışan repo yerine yarın bir gün veritabanı reposunu servise tek satırla enjekte edebilecek esnekliğe ulaştım.  


* Generic Arayüz Kullanımı: IRepository<T> yapısını generic kurgulayarak altyapının gelecekte sadece hesaplar için değil, farklı nesneler için de kullanılabilmesini sağladım.  


> 3. Karşılaşılan Zorluklar ve Çözüm Yaklaşımları

- Vadeli vs. Vadesiz Hesap Para Çekme Mantığı: Vadesiz hesaplarda günlük limit (DailyWithdrawLimit) ve tarih takibi (_lastWithdrawDate) gerekirken; vadeli hesaplarda vade tarihi (TermDate) kontrolünün gerekmesi durumu, CanWithdraw metodunun her sınıfa özel override edilmesiyle temiz bir şekilde çözüldü.  


- Transfer İşlemlerinde Atomik Yapı: Transfer metodunda, göndericiden para çekilip (Withdraw) çekilemediği kontrol edilerek, yalnızca işlem başarılı olursa alıcıya para yatırılması (Deposit) sağlandı. Böylece tutarsız bakiye durumlarının önüne geçildi.  


- İstisna / Hata Yönetimi (Exception Handling): Sistemde olmayan bir hesap ID'si ile işlem yapılmaya çalışıldığında uygulamanın çökmesini önlemek amacıyla BankService katmanında InvalidOperationException fırlatıldı ve Program.cs içinde try-catch bloklarıyla kontrol altına alındı.  
 

> 4. Kişisel Kazanımlar ve Öz Değerlendirme

Bir projenin sadece "çalışan kodlar" yazmaktan ibaret olmadığını; doğru sınıf mimarisi, interface bağımlılıkları ve katmanlı mimari kurgulamanın kodun okunabilirliğini ve sürdürülebilirliğini ne kadar artırdığını deneyimledim. İlk başta çok zor gelse de kod ilerledikçe yapıyı başarılı bir şekilde tamamladım. Karmaşık gibi görünen bankacılık kurallarının (vade süresi, günlük limit, transfer loglama) doğru OOP tasarımıyla nasıl sade ve kontrol edilebilir parçalara bölünebildiğini kavradım.