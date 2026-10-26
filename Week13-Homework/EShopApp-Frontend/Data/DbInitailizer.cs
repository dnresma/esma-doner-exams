using System;
using EShopApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EShopApp.Data;

public static class DbInitailizer
{
    public static async Task SeedAsync(IServiceProvider services)
    {
        var context = services.GetRequiredService<EShopAppDbContext>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        await SeedCategoriesAsync(context);
        await SeedProductsAsync(context);
        await SeedRolesAndUsersAsync(roleManager, userManager, context);
    }


    private static async Task SeedCategoriesAsync(EShopAppDbContext context)
    {
        // Eğer daha önceden kategori varsa çık
        if (await context.Categories.AnyAsync()) return;
        // Eğer herhangi bir kategori yoksa, bu kategorileri DbSet'e ekle
        await context.Categories.AddRangeAsync(
            new Category
            {
                Name = "Elektronik",
                Description = "Günlük yaşamınızı kolaylaştıran ve teknolojiyle buluşturan elektronik ürünleri bir arada keşfedin. Akıllı cihazlardan kablosuz hoparlörlere, taşınabilir elektroniklerden yenilikçi teknolojik ürünlere kadar geniş ürün seçenekleriyle ihtiyaçlarınıza uygun çözümler bulun. Teknolojinin sunduğu yenilikleri yaşamınıza dahil edin."
            },
            new Category
            {
                Name = "Telefon",
                Description = "İletişimden fotoğrafçılığa, eğlenceden günlük işlerinize kadar her an yanınızda olan akıllı telefonları keşfedin. Güçlü kameralar, yüksek performans, uzun pil ömrü ve şık tasarımlar sunan farklı modeller arasından ihtiyaçlarınıza en uygun telefonu bulun. Mobil deneyiminizi geliştiren yeni nesil teknolojilerle her an bağlantıda kalın."
            },
            new Category
            {
                Name = "Bilgisayar",
                Description = "İş, eğitim ve eğlence ihtiyaçlarınız için güçlü bilgisayar seçeneklerini keşfedin. Yüksek performanslı dizüstü bilgisayarlar, masaüstü bilgisayarlar ve farklı kullanım amaçlarına uygun sistemlerle dijital dünyadaki işlerinizi daha hızlı ve verimli hale getirin. İhtiyacınıza uygun bilgisayarı seçerek teknoloji deneyiminizi bir üst seviyeye taşıyın."
            },
            new Category
            {
                Name = "Tablet",
                Description = "Taşınabilirliğin ve çok yönlü kullanımın avantajlarını tabletlerle keşfedin. Ders çalışmak, dijital içerik tüketmek, çizim yapmak, not almak ve günlük işlerinizi yönetmek için farklı ihtiyaçlara uygun tablet seçeneklerini inceleyin. Hafif tasarımları ve kullanışlı özellikleriyle dijital dünyaya her yerden kolayca erişin."
            },
            new Category
            {
                Name = "Kulaklık",
                Description = "Müziğin keyfini çıkarın, oyunlarda ayrıntıları yakalayın ve görüşmelerinizi daha konforlu hale getirin. Kablosuz kulaklıklardan oyuncu kulaklıklarına, günlük kullanım modellerinden yüksek ses kalitesi sunan seçeneklere kadar farklı ihtiyaçlara hitap eden ürünleri keşfedin. Size uygun kulaklıkla ses deneyiminizi kişiselleştirin."
            },
            new Category
            {
                Name = "Televizyon",
                Description = "Eğlenceyi evinize taşıyan televizyon modelleriyle film, dizi, spor ve oyun deneyiminizi zenginleştirin. Yüksek çözünürlüklü ekranlar, canlı renkler, akıllı TV özellikleri ve farklı ekran boyutlarıyla yaşam alanınıza uygun seçenekleri keşfedin. İster sinema keyfi ister günlük izleme deneyimi için olsun, size en uygun televizyonu bulun."
            },
            new Category
            {
                Name = "Ev Aletleri",
                Description = "Evinizde konforu ve pratikliği artıran ev aletleriyle tanışın. Kahve makineleri, blenderlar, elektrikli süpürgeler, mutfak yardımcıları ve günlük işlerinizi kolaylaştıran ürünlerle zamandan tasarruf edin. İhtiyaçlarınıza uygun işlevsel ve modern ev aletleriyle yaşam alanınızı daha kullanışlı hale getirin."
            },
            new Category
            {
                Name = "Oyun",
                Description = "Oyun dünyasının heyecanını daha ileriye taşıyın! Oyun konsolları, kontrol cihazları, oyuncu ekipmanları ve oyun deneyiminizi geliştiren teknolojik ürünlerle favori oyunlarınızın tadını çıkarın. İster rekabetçi oyunlarda performansınızı artırmak ister arkadaşlarınızla eğlenceli vakit geçirmek isteyin, oyun kategorisindeki ürünleri keşfedin."
            },
            new Category
            {
                Name = "Fotoğraf ve Kamera",
                Description = "Anılarınızı en güzel şekilde ölümsüzleştirmek ve yaratıcılığınızı özgürce ifade etmek için fotoğraf ve kamera ürünlerini keşfedin. Profesyonel fotoğraf makineleri, lensler, tripodlar ve çekim ekipmanlarıyla her karede daha etkileyici sonuçlar elde edin. İster hobi ister profesyonel kullanım için olsun, fotoğrafçılık tutkunuzu destekleyen ekipmanları burada bulabilirsiniz."
            },
            new Category
            {
                Name = "Aksesuar",
                Description = "Teknoloji deneyiminizi tamamlayan aksesuarlarla tanışın! Günlük kullanımınızı kolaylaştıran şarj kabloları, adaptörler, bilgisayar çevre birimleri, akıllı saat kayışları ve daha birçok kullanışlı ürünü keşfedin. Tarzınıza ve ihtiyaçlarınıza uygun aksesuarlarla cihazlarınızdan daha fazla verim alın."
            }
        );
        // DbSet'e eklediğin verilerin veritabanına gerçekten kaydedilmesini sağla
        await context.SaveChangesAsync();
    }

    private static async Task SeedProductsAsync(EShopAppDbContext context)
    {
        if (await context.Products.AnyAsync()) return;
        await context.Products.AddRangeAsync(
            // CategoryId = 1 - Elektronik (6 ürün)
            new Product
            {
                Name = "Kablosuz Kulaklık",
                Description = "Aktif gürültü önleme özellikli, yüksek ses kalitesi sunan kablosuz kulaklık. Bluetooth bağlantısı sayesinde telefon, tablet ve bilgisayar gibi farklı cihazlarla kolayca eşleştirilebilir. Uzun süreli kullanım için ergonomik bir tasarıma sahip olan ürün, güçlü bas ve dengeli tiz sesleriyle müzik, film ve oyun deneyimini daha keyifli hale getirir. Şarj kutusu sayesinde gün içerisinde tekrar tekrar kullanılabilir ve taşıması oldukça kolaydır.",
                Price = 1799m,
                StockQuantity = 19,
                CategoryId = 1,
                ImageUrl = "https://productimages.hepsiburada.net/s/532/375-375/110000589593532.jpg"
            },
            new Product
            {
                Name = "Akıllı Saat Pro",
                Description = "Günlük aktivitelerinizi takip etmenize yardımcı olan gelişmiş özelliklere sahip akıllı saat. Kalp atış hızı, adım sayısı, uyku düzeni ve günlük hareketler gibi birçok bilgiyi takip edebilir. Renkli ekranı sayesinde bildirimleri kolayca görüntüleyebilir, telefon görüşmelerini ve uygulama bildirimlerini bileğinizden kontrol edebilirsiniz. Şık tasarımı hem spor hem de günlük kullanım için uygun bir görünüm sunar.",
                Price = 3299m,
                StockQuantity = 27,
                CategoryId = 1,
                ImageUrl = "https://cdn2.a101.com.tr/dbmk89vnr/CALL/Image/getcl/livephotos/8/26061382default/1.jpg"
            },
            new Product
            {
                Name = "Bluetooth Hoparlör",
                Description = "Kompakt tasarımı ve güçlü ses çıkışı ile evde, ofiste veya açık alanlarda kullanılabilecek taşınabilir Bluetooth hoparlör. Kablosuz bağlantı özelliği sayesinde akıllı telefon ve tabletlerden kolayca müzik oynatılabilir. Güçlü bataryası uzun süreli kullanım sunarken dayanıklı dış gövdesi günlük taşıma sırasında ürünü korur. Dengeli ses karakteri sayesinde hem müzik hem de podcast dinlemek için ideal bir seçenektir.",
                Price = 1499m,
                StockQuantity = 34,
                CategoryId = 1,
                ImageUrl = "https://shop.xenonsmart.com/cdn/shop/files/frame-385-png.png?v=1754488303&width=1920"
            },
            new Product
            {
                Name = "Powerbank 20000 mAh",
                Description = "Yüksek kapasiteli bataryası sayesinde akıllı telefon, tablet ve diğer USB destekli cihazları gün içerisinde şarj etmenize yardımcı olan taşınabilir powerbank. Birden fazla bağlantı noktası sayesinde aynı anda farklı cihazları şarj edebilir. Kompakt gövdesi çantada kolayca taşınabilirken güvenlik devreleri aşırı şarj ve aşırı ısınma gibi durumlara karşı koruma sağlar. Seyahatlerde ve yoğun kullanım günlerinde oldukça kullanışlıdır.",
                Price = 999m,
                StockQuantity = 42,
                CategoryId = 1,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQEMTbghecbTrlygQasfmw-JZGBrmUtpR-BkSGjTdHstA&s=10"
            },
            new Product
            {
                Name = "USB-C Çoklayıcı",
                Description = "Dizüstü bilgisayarların bağlantı seçeneklerini genişletmek için tasarlanmış çok işlevli USB-C dönüştürücü. USB, HDMI ve kart okuyucu gibi farklı bağlantı noktalarını tek bir kompakt gövdede bir araya getirir. Özellikle az sayıda port bulunan modern bilgisayar kullanıcıları için pratik bir çözüm sunar. Alüminyum gövdesi dayanıklı bir kullanım sağlarken küçük boyutu sayesinde çanta içerisinde fazla yer kaplamadan kolayca taşınabilir.",
                Price = 1199m,
                StockQuantity = 16,
                CategoryId = 1,
                ImageUrl = "https://cdn.dsmcdn.com/mnresize/420/620/ty1572/prod/QC/20240926/22/d36558bf-20f0-39f6-ac51-fd3f292f7f81/1_org_zoom.jpg"
            },
            new Product
            {
                Name = "Akıllı Ev Merkezi",
                Description = "Ev içerisinde bulunan uyumlu akıllı cihazları tek merkezden yönetmeye yardımcı olan modern akıllı ev kontrol ünitesi. Aydınlatma, priz ve çeşitli sensörlerle birlikte çalışarak günlük yaşamı daha pratik hale getirir. Mobil uygulama üzerinden kontrol edilebilmesi sayesinde kullanıcılar evde olmadıkları zamanlarda bile cihazlarını yönetebilir. Kolay kurulum özelliği ve sade arayüzü sayesinde teknoloji konusunda deneyimli olmayan kullanıcılar için de uygundur.",
                Price = 2499m,
                StockQuantity = 8,
                CategoryId = 1,
                ImageUrl = "https://www.vintas.com.tr/images/hizmetler/oi-akilli-ev-ve-villa-sistemleri98148.png"
            },

            // CategoryId = 2 - Telefon (4 ürün)
            new Product
            {
                Name = "Galaxy A55",
                Description = "Günlük kullanım ihtiyaçlarını karşılamak üzere tasarlanmış modern bir akıllı telefon. Yüksek çözünürlüklü ekranı sosyal medya, video ve oyun deneyimlerinde canlı görüntüler sunarken güçlü işlemcisi uygulamalar arasında hızlı geçiş yapılmasına yardımcı olur. Gelişmiş kamera sistemi farklı ışık koşullarında kaliteli fotoğraflar çekebilmenizi sağlar. Uzun pil ömrü sayesinde gün boyunca şarj ihtiyacını azaltarak yoğun kullanıcılar için pratik bir deneyim sunar.",
                Price = 18999m,
                StockQuantity = 21,
                CategoryId = 2,
                ImageUrl = "https://m.media-amazon.com/images/I/61Q6BzH+4vL._AC_UF1000,1000_QL80_.jpg"
            },
            new Product
            {
                Name = "iPhone 15",
                Description = "Güçlü işlemcisi, yüksek kaliteli ekranı ve gelişmiş kamera sistemi ile günlük kullanımda yüksek performans sunan akıllı telefon. İnce ve modern tasarımı sayesinde elde rahat bir kullanım sağlayan cihaz, uygulamaların hızlı açılmasına ve çoklu görevlerin sorunsuz şekilde gerçekleştirilmesine yardımcı olur. Kamera sistemi sayesinde günlük anları yüksek detay seviyesinde kaydetmek mümkündür. Uzun süreli yazılım desteği de cihazın kullanım ömrünü artıran önemli özelliklerden biridir.",
                Price = 42999m,
                StockQuantity = 14,
                CategoryId = 2,
                ImageUrl = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/apple/thumb/140315-6_large.jpg"
            },
            new Product
            {
                Name = "Redmi Note 13",
                Description = "Uygun fiyat seviyesinde güçlü özellikler sunmayı hedefleyen akıllı telefon modeli. Geniş ekranı sayesinde film, video ve sosyal medya içerikleri rahatlıkla görüntülenebilir. Yüksek kapasiteli bataryası yoğun kullanım sırasında gün içerisinde uzun süre dayanıklılık sağlar. Çoklu kamera sistemi günlük fotoğraf çekimleri için farklı seçenekler sunarken hızlı işlemcisi uygulamalar arasında rahat geçiş yapılmasına yardımcı olur. Modern tasarımı cihazı günlük kullanım için ideal hale getirir.",
                Price = 10999m,
                StockQuantity = 37,
                CategoryId = 2,
                ImageUrl = "https://assets.getmobil.com/uploads/76497/getmobil-xiaomi-redmi-note-13-pro-siyah-1-webp.webp"
            },
            new Product
            {
                Name = "Samsung Galaxy S24",
                Description = "Yüksek performans isteyen kullanıcılar için geliştirilen güçlü akıllı telefon modeli. Parlak ve yüksek çözünürlüklü ekranı oyun, film ve fotoğraf görüntüleme deneyimini iyileştirirken güçlü işlemcisi yoğun uygulamaların hızlı çalışmasını sağlar. Gelişmiş kamera sistemi farklı çekim modlarıyla kaliteli fotoğraflar elde etmeye yardımcı olur. Premium gövde tasarımı ve uzun süreli yazılım desteği sayesinde hem profesyonel hem de günlük kullanım için güçlü bir alternatif oluşturur.",
                Price = 35999m,
                StockQuantity = 9,
                CategoryId = 2,
                ImageUrl = "https://cdn.akakce.com/z/samsung/samsung-galaxy-s24-256-gb.jpg"
            },

            // CategoryId = 3 - Bilgisayar (5 ürün)
            new Product
            {
                Name = "Lenovo IdeaPad 5",
                Description = "Ofis çalışmaları, eğitim, internet kullanımı ve günlük bilgisayar ihtiyaçları için tasarlanmış dengeli bir dizüstü bilgisayar. Güçlü işlemcisi sayesinde belge düzenleme, web tarama ve çoklu görev işlemlerini rahatlıkla gerçekleştirebilir. Geniş ekranı uzun süreli çalışmalarda konforlu bir görüntüleme alanı sunarken hızlı depolama birimi uygulamaların daha kısa sürede açılmasına yardımcı olur. İnce ve taşınabilir tasarımı sayesinde farklı ortamlarda kolayca kullanılabilir.",
                Price = 24999m,
                StockQuantity = 12,
                CategoryId = 3,
                ImageUrl = "https://p3-ofp.static.pub//fes/cms/2024/06/21/ji0uxwlut2i6mezbci2bq0nwyrzo56131675.png"
            },
            new Product
            {
                Name = "ASUS Vivobook 15",
                Description = "Günlük bilgisayar kullanımı ve çalışma ihtiyaçları için geliştirilen ince ve hafif dizüstü bilgisayar. Geniş ekranı doküman hazırlama, internet kullanımı ve multimedya içeriklerinde rahat bir çalışma alanı sağlar. Hızlı depolama birimi sayesinde sistem ve uygulamalar kısa sürede açılırken güçlü işlemcisi aynı anda birden fazla program kullanıldığında akıcı bir performans sunar. Taşınabilir gövdesi öğrenciler ve mobil çalışanlar için oldukça kullanışlıdır.",
                Price = 22999m,
                StockQuantity = 18,
                CategoryId = 3,
                ImageUrl = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/asus/thumb/160587-1_large.jpg"
            },
            new Product
            {
                Name = "HP Pavilion 14",
                Description = "Kompakt boyutları ve güçlü donanımı bir araya getiren dizüstü bilgisayar modeli. Günlük ofis uygulamaları, eğitim programları, internet kullanımı ve multimedya içerikleri için yeterli performans sunar. Yüksek çözünürlüklü ekranı görüntülerin daha net ve canlı görünmesine yardımcı olur. Hızlı SSD depolama birimi dosyalara erişim ve programların açılış sürelerini kısaltırken ergonomik klavyesi uzun süreli yazı yazma işlemlerinde kullanıcı konforunu artırır.",
                Price = 26999m,
                StockQuantity = 7,
                CategoryId = 3,
                ImageUrl = "https://reimg-teknosa-cloud-prod.mncdn.com/mnresize/600/600/productimage/786280220/786280220_2_MC/5509acdaf4f44792b11b0fe478e57ec6.jpg"
            },
            new Product
            {
                Name = "Oyuncu Masaüstü PC",
                Description = "Yüksek grafik performansı gerektiren oyunlar ve uygulamalar için hazırlanmış güçlü masaüstü bilgisayar. Yüksek performanslı işlemcisi ve ekran kartı sayesinde modern oyunlarda akıcı görüntüler elde edilmesine yardımcı olur. Geniş RAM kapasitesi çoklu görevlerde sistemin rahat çalışmasını sağlarken hızlı SSD depolama birimi oyunların ve uygulamaların daha kısa sürede açılmasına katkıda bulunur. Yükseltilebilir yapısı sayesinde ilerleyen dönemlerde donanım güncellemesi yapılabilir.",
                Price = 45999m,
                StockQuantity = 5,
                CategoryId = 3,
                ImageUrl = "https://cdn.dsmcdn.com/mnresize/420/620/ty1738/prod/QC_PREP/20250829/16/f597264b-9128-327f-afd4-4fdc4bf07d16/1_org_zoom.jpg"
            },
            new Product
            {
                Name = "MacBook Air",
                Description = "İnce, hafif ve taşınabilir yapısıyla mobil çalışan kullanıcılar için tasarlanmış premium dizüstü bilgisayar. Güçlü işlemcisi günlük uygulamalardan profesyonel çalışma programlarına kadar geniş bir kullanım alanında yüksek performans sunar. Yüksek çözünürlüklü ekranı fotoğraf, video ve metin içeriklerinin ayrıntılı görüntülenmesine yardımcı olur. Uzun pil ömrü sayesinde prizden uzakta daha uzun süre çalışabilmek mümkün olurken sessiz çalışma yapısı kullanıcı deneyimini olumlu yönde etkiler.",
                Price = 54999m,
                StockQuantity = 11,
                CategoryId = 3,
                ImageUrl = "https://www.technopat.net/wp-content/uploads/2023/06/15-inc-macbook-air-tanitildi-iste-ozellikleri.jpg"
            },

            // CategoryId = 4 - Tablet (3 ürün)
            new Product
            {
                Name = "iPad 10. Nesil",
                Description = "Günlük kullanım, eğitim, eğlence ve üretkenlik ihtiyaçlarına yönelik modern tablet bilgisayar. Geniş ve yüksek çözünürlüklü ekranı video izleme, internette gezinme ve doküman okuma işlemlerinde konforlu bir deneyim sunar. Güçlü işlemcisi uygulamalar arasında hızlı geçiş yapılmasına yardımcı olurken uzun pil ömrü gün içerisinde kesintisiz kullanım imkanı sağlar. Hafif gövdesi sayesinde evde, okulda veya seyahat sırasında kolayca taşınabilir.",
                Price = 16999m,
                StockQuantity = 23,
                CategoryId = 4,
                ImageUrl = "https://www.incehesap.com/resim/urun/202503/67c83b9da2bd2.webp"
            },
            new Product
            {
                Name = "Galaxy Tab S9",
                Description = "Yüksek çözünürlüklü ekranı ve güçlü donanımı ile eğlence ve üretkenlik odaklı kullanım sunan gelişmiş tablet modeli. Büyük ekranı film izleme, dijital kitap okuma ve çizim gibi işlemlerde geniş bir çalışma alanı sağlar. Güçlü işlemcisi çoklu görev sırasında uygulamaların akıcı şekilde çalışmasına yardımcı olur. Kaliteli ses sistemi ve uzun pil ömrü sayesinde seyahatlerde, evde veya iş ortamında rahatlıkla kullanılabilir.",
                Price = 21999m,
                StockQuantity = 15,
                CategoryId = 4,
                ImageUrl = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/samsung/thumb/150377-1_large.jpg"
            },
            new Product
            {
                Name = "Lenovo Tab M11",
                Description = "Günlük tablet ihtiyaçlarını karşılamak üzere tasarlanmış kullanışlı ve ekonomik model. Geniş ekranı video izlemek, internette gezinmek, elektronik kitap okumak ve eğitim içeriklerini takip etmek için rahat bir kullanım alanı sunar. Hafif tasarımı cihazın uzun süre elde tutulmasını kolaylaştırırken güçlü bataryası gün boyunca farklı işlemler için yeterli kullanım süresi sağlar. Kablosuz bağlantı desteği sayesinde internete kolayca bağlanarak mobil kullanım avantajı sunar.",
                Price = 8999m,
                StockQuantity = 31,
                CategoryId = 4,
                ImageUrl = "https://cdn.akakce.com/z/lenovo/lenovo-tab-m11-zada0327tr-128-gb-11.jpg"
            },

            // CategoryId = 5 - Kulaklık (7 ürün)
            new Product
            {
                Name = "Sony WH-1000XM5",
                Description = "Gelişmiş aktif gürültü engelleme teknolojisi ve yüksek ses kalitesi ile öne çıkan premium kablosuz kulaklık. Dış ortamdan gelen sesleri azaltarak müzik dinleme ve telefon görüşmeleri sırasında daha sakin bir deneyim sunar. Uzun pil ömrü sayesinde sık sık şarj etme ihtiyacını azaltırken ergonomik kulaklık pedleri uzun süreli kullanımlarda konfor sağlar. Katlanabilir yapısı ve taşıma çantası sayesinde seyahatlerde kolayca taşınabilir.",
                Price = 11999m,
                StockQuantity = 13,
                CategoryId = 5,
                ImageUrl = "https://cdn.akakce.com/z/sony/sony-wh-1000xm5-kulak-ustu.jpg"
            },
            new Product
            {
                Name = "JBL Tune 770NC",
                Description = "Aktif gürültü engelleme özelliğiyle dış ortam seslerini azaltan, güçlü bas performansına sahip kablosuz kulaklık. Bluetooth bağlantısı sayesinde farklı cihazlarla hızlı şekilde eşleşebilir ve uzun süre kesintisiz müzik dinleme imkanı sunar. Hafif gövdesi ve yumuşak kulak pedleri uzun süreli kullanım sırasında rahatlık sağlarken katlanabilir tasarımı çanta içerisinde daha az yer kaplamasına yardımcı olur. Günlük kullanım ve seyahat için ideal bir seçenektir.",
                Price = 4299m,
                StockQuantity = 25,
                CategoryId = 5,
                ImageUrl = "https://cdn.akakce.com/z/jbl/jbl-live-770nc-kulak-ustu.jpg"
            },
            new Product
            {
                Name = "AirPods Pro",
                Description = "Kablosuz kullanım kolaylığı sağlayan ve aktif gürültü engelleme özelliği bulunan kompakt kulaklık modeli. Şarj kutusu ile birlikte taşınabilen ürün günlük kullanımda pratik bir deneyim sunar. Farklı silikon uç seçenekleri sayesinde kulağa daha uygun bir yapı oluşturulabilir. Müzik dinleme, telefon görüşmesi ve video izleme gibi işlemlerde dengeli ses kalitesi sağlayan kulaklık, küçük boyutları sayesinde çantada veya cepte kolaylıkla taşınabilir.",
                Price = 8999m,
                StockQuantity = 17,
                CategoryId = 5,
                ImageUrl = "https://cdn.akakce.com/z/apple/airpods-pro-3-nesil.jpg"
            },
            new Product
            {
                Name = "Anker Soundcore Q30",
                Description = "Uzun süreli kullanım için geliştirilen, aktif gürültü engelleme özelliğine sahip kablosuz kulaklık. Yüksek kapasiteli bataryası sayesinde tek şarjla uzun süre müzik dinlemeye imkan verir. Yumuşak kulak pedleri ve ayarlanabilir kafa bandı farklı kullanıcıların rahat şekilde kullanabilmesine yardımcı olur. Bluetooth bağlantısı ile telefon ve bilgisayarlara kolayca bağlanabilir. Günlük ulaşım, çalışma ve seyahat sırasında dış sesleri azaltarak daha keyifli bir dinleme deneyimi sunar.",
                Price = 2999m,
                StockQuantity = 29,
                CategoryId = 5,
                ImageUrl = "https://reimg-teknosa-cloud-prod.mncdn.com/mnresize/600/600/productimage/780291392/780291392_0_MC/fdabcde6f24f4ae7a5976db837ebcfa1.jpg"
            },
            new Product
            {
                Name = "Xiaomi Buds 4",
                Description = "Kompakt ve hafif tasarımıyla günlük kullanım için geliştirilen tamamen kablosuz kulaklık. Bluetooth bağlantısı sayesinde akıllı telefon ve tabletlerle hızlı şekilde eşleşebilir. Dengeli ses karakteri müzik, podcast ve video içeriklerinde tatmin edici bir dinleme deneyimi sunar. Şarj kutusu kulaklıkların taşınmasını kolaylaştırırken gün içerisinde ihtiyaç duyulduğunda ek kullanım süresi sağlar. Küçük boyutu ve sade tasarımı sayesinde spor ve günlük kullanım için uygundur.",
                Price = 2499m,
                StockQuantity = 36,
                CategoryId = 5,
                ImageUrl = "https://i02.appmifile.com/670_operator_sg/30/05/2023/4e4c4c7444c679bac6223840f93b3b0f.png"
            },
            new Product
            {
                Name = "Razer Kraken X",
                Description = "Oyuncular için tasarlanmış hafif ve konforlu kablolu oyuncu kulaklığı. Güçlü ses sürücüleri sayesinde oyunlardaki çevresel sesleri ve konuşmaları daha net şekilde duymanıza yardımcı olur. Dahili mikrofon takım arkadaşlarıyla iletişim kurulmasını kolaylaştırırken yumuşak kulak pedleri uzun oyun oturumlarında rahatlık sağlar. Bilgisayar ve uyumlu oyun cihazlarıyla kolayca kullanılabilen ürün, özellikle fiyat-performans odaklı oyuncular için başarılı bir alternatiftir.",
                Price = 2199m,
                StockQuantity = 20,
                CategoryId = 5,
                ImageUrl = "https://m.media-amazon.com/images/I/71pNzi4ROJL._AC_UF1000,1000_QL80_.jpg"
            },
            new Product
            {
                Name = "Huawei FreeBuds SE",
                Description = "Hafif yapısı ve kablosuz kullanım avantajıyla günlük müzik dinleme ve telefon görüşmeleri için tasarlanmış kulaklık. Bluetooth bağlantısı sayesinde akıllı telefonlarla kolayca eşleştirilebilir. Ergonomik tasarımı kulağa rahat şekilde otururken şarj kutusu ürünün güvenli biçimde taşınmasını sağlar. Dengeli ses performansı müzik, podcast ve video içeriklerinde yeterli kalite sunar. Kompakt boyutları sayesinde çantada veya cepte kolaylıkla taşınabilmesi günlük kullanımda önemli avantaj sağlar.",
                Price = 1599m,
                StockQuantity = 44,
                CategoryId = 5,
                ImageUrl = "https://consumer.huawei.com/dam/content/dam/huawei-cbg-site/common/mkt/pdp/headphones/freebuds-se-2-new/images/Huawei-freebuds-se-2-kv.jpg"
            },

            // CategoryId = 6 - Televizyon (4 ürün)
            new Product
            {
                Name = "Samsung 55 4K Smart TV",
                Description = "4K çözünürlük ve akıllı televizyon özelliklerini bir araya getiren geniş ekranlı televizyon modeli. Yüksek çözünürlük sayesinde film, dizi ve spor yayınlarında daha ayrıntılı görüntüler sunar. Dahili akıllı TV platformu üzerinden popüler yayın uygulamalarına erişilebilir. Geniş ekranı salon kullanımı için uygun bir izleme alanı oluştururken gelişmiş görüntü teknolojileri renklerin ve kontrastın daha dengeli görünmesine yardımcı olur. Modern ve ince çerçeveli tasarımı dekorasyona kolayca uyum sağlar.",
                Price = 24999m,
                StockQuantity = 6,
                CategoryId = 6,
                ImageUrl = "https://images.samsung.com/is/image/samsung/p6pim/tr/ue55u8000fuxtk/gallery/tr-uhd-u8000-556251-ue55u8000fuxtk-547695486?$1164_776_PNG$"
            },
            new Product
            {
                Name = "LG OLED 48",
                Description = "OLED ekran teknolojisi sayesinde yüksek kontrast ve derin siyah seviyeleri sunan gelişmiş televizyon modeli. 4K çözünürlük desteği sayesinde filmler, diziler ve oyunlar yüksek detay seviyesinde görüntülenebilir. Akıllı TV özellikleri sayesinde internet üzerinden çeşitli yayın platformlarına kolayca erişim sağlanabilir. İnce gövde tasarımı modern yaşam alanlarına uyum sağlarken gelişmiş görüntü işlemcisi farklı içerik türlerinde daha doğal ve dengeli görüntüler oluşturulmasına yardımcı olur.",
                Price = 32999m,
                StockQuantity = 4,
                CategoryId = 6,
                ImageUrl = "https://cdn.vatanbilgisayar.com/Upload/PRODUCT/lg/thumb/154663-1_large.jpg"
            },
            new Product
            {
                Name = "Philips Ambilight 50",
                Description = "Geniş ekranı ve Ambilight teknolojisi ile izleme deneyimini daha etkileyici hale getiren 4K akıllı televizyon. Ekranın arkasından duvara yansıyan ışıklar görüntüdeki renklere uyum sağlayarak daha geniş bir atmosfer oluşturur. Akıllı TV işletim sistemi üzerinden çeşitli uygulamalara erişilebilir. Yüksek çözünürlüklü panel film, dizi ve spor içeriklerinde net görüntüler sunarken modern tasarımı salon ve oturma odalarında şık bir görünüm oluşturur.",
                Price = 22999m,
                StockQuantity = 10,
                CategoryId = 6,
                ImageUrl = "https://cdn.akakce.com/z/lg/lg-55oled760-4k-ultra-hd-55-140-ekran-uydu-alicili-smart-ambilight-oled-tv.jpg"
            },
            new Product
            {
                Name = "TCL 55 QLED",
                Description = "QLED ekran teknolojisiyle canlı renkler ve yüksek görüntü kalitesi sunmayı hedefleyen 4K akıllı televizyon. Geniş ekran yapısı film, dizi, spor ve oyun içeriklerini daha etkileyici bir şekilde takip etmeye imkan verir. Dahili akıllı platform üzerinden çeşitli dijital yayın servislerine ulaşılabilir. İnce çerçeveli modern tasarımı yaşam alanlarına kolayca uyum sağlarken güçlü görüntü işlemcisi farklı içeriklerde renk, kontrast ve netlik değerlerinin dengeli şekilde oluşturulmasına yardımcı olur.",
                Price = 19999m,
                StockQuantity = 14,
                CategoryId = 6,
                ImageUrl = "https://m.media-amazon.com/images/I/81d6310fY7L._AC_UF1000,1000_QL80_.jpg"
            },

            // CategoryId = 7 - Ev Aletleri (5 ürün)
            new Product
            {
                Name = "Philips Airfryer",
                Description = "Daha az yağ kullanarak çeşitli yiyeceklerin hazırlanmasına yardımcı olan pratik sıcak hava fritözü. Geniş haznesi sayesinde patates, sebze, tavuk ve benzeri birçok yiyecek aynı cihaz içerisinde kolayca hazırlanabilir. Ayarlanabilir sıcaklık ve zaman seçenekleri farklı tariflere uygun pişirme imkanı sunar. Kolay temizlenebilen haznesi günlük kullanım sonrasında pratiklik sağlarken kompakt tasarımı mutfak tezgahında fazla yer kaplamadan kullanılmasına olanak tanır.",
                Price = 4999m,
                StockQuantity = 22,
                CategoryId = 7,
                ImageUrl = "https://cdn.dsmcdn.com/mnresize/420/620/ty1891/prod/QC_ENRICHMENT/20260717/15/6d66f891-9e0e-303d-9b91-c215204cdb75/1_org_zoom.jpg"
            },
            new Product
            {
                Name = "Arçelik Kahve Makinesi",
                Description = "Günlük kahve hazırlama işlemini pratik hale getirmek için tasarlanmış modern kahve makinesi. Kullanıcı dostu kontrol paneli sayesinde farklı kahve seçenekleri kolayca hazırlanabilir. Kompakt gövdesi mutfak tezgahında fazla yer kaplamadan kullanılmasına imkan verir. Su haznesinin kolay şekilde çıkarılabilmesi temizlik ve dolum işlemlerini pratikleştirirken şık tasarımı farklı mutfak dekorasyonlarına uyum sağlar. Evde düzenli olarak kahve tüketen kullanıcılar için kullanışlı bir yardımcıdır.",
                Price = 3299m,
                StockQuantity = 13,
                CategoryId = 7,
                ImageUrl = "https://www.arcelik.com.tr/media/resize/9252001100_MDM2_LOW_1.png/1000Wx1000H/image.webp"
            },
            new Product
            {
                Name = "Bosch Blender Seti",
                Description = "Mutfakta farklı hazırlama işlemlerini kolaylaştırmak üzere tasarlanmış çok parçalı blender seti. Güçlü motoru sayesinde çorba, smoothie, sos ve çeşitli karışımların kısa sürede hazırlanmasına yardımcı olur. Farklı aparatları sayesinde doğrama ve karıştırma gibi işlemler de gerçekleştirilebilir. Ergonomik tutma alanı uzun süreli kullanımlarda rahatlık sağlarken çıkarılabilir parçaların kolay temizlenebilmesi günlük kullanım sonrasında önemli bir avantaj sunar.",
                Price = 2899m,
                StockQuantity = 18,
                CategoryId = 7,
                ImageUrl = "https://media3.bsh-group.com/Product_Shots/5120x/22487352_MMB6654B_STP_def.webp"
            },
            new Product
            {
                Name = "Tefal Elektrikli Izgara",
                Description = "Et, tavuk, sebze ve sandviç gibi farklı yiyeceklerin pratik şekilde hazırlanmasına yardımcı olan elektrikli ızgara. Ayarlanabilir sıcaklık kontrolü sayesinde farklı yiyecek türlerine uygun pişirme seçenekleri sunar. Yapışmaz pişirme yüzeyi hem kullanım kolaylığı sağlar hem de temizlik işlemini hızlandırır. Kompakt tasarımı mutfak tezgahında rahatlıkla kullanılabilirken katlanabilir yapısı cihazın saklanmasını kolaylaştırır ve günlük yemek hazırlama sürecini pratik hale getirir.",
                Price = 3799m,
                StockQuantity = 9,
                CategoryId = 7,
                ImageUrl = "https://productimages.hepsiburada.net/s/777/375-375/110001368449585.jpg"
            },
            new Product
            {
                Name = "Dyson Dikey Süpürge",
                Description = "Kablosuz kullanım kolaylığı sağlayan güçlü dikey süpürge modeli. Farklı zemin türlerinde kullanılabilen başlıkları sayesinde halı, parke ve sert zeminlerde etkili temizlik yapılmasına yardımcı olur. Kablosuz tasarımı hareket özgürlüğü sağlarken ergonomik gövdesi ev içerisinde farklı alanlara kolayca ulaşmayı mümkün hale getirir. Toz haznesinin pratik şekilde boşaltılabilmesi temizlik sonrasında kullanım kolaylığı sunar. Günlük ve detaylı ev temizliği için kullanışlı bir çözümdür.",
                Price = 15999m,
                StockQuantity = 5,
                CategoryId = 7,
                ImageUrl = "https://cdn.dsmcdn.com/ty1633/prod/QC/20250207/15/fd206e32-ad98-3cd8-ae2e-14c5a94af89a/1_org_zoom.jpg"
            },

            // CategoryId = 8 - Oyun (3 ürün)
            new Product
            {
                Name = "PlayStation 5",
                Description = "Yeni nesil oyun deneyimi sunmak üzere geliştirilen güçlü oyun konsolu. Yüksek performanslı donanımı sayesinde desteklenen oyunlarda hızlı yükleme süreleri ve akıcı grafikler sunar. Yüksek çözünürlüklü görüntü desteği oyunların daha ayrıntılı görünmesine yardımcı olur. Geniş oyun kütüphanesi sayesinde farklı türlerde birçok oyuna erişilebilir. Modern tasarımı ve gelişmiş kontrolcü özellikleri ile evde kaliteli bir oyun deneyimi yaşamak isteyen kullanıcılar için güçlü bir seçenektir.",
                Price = 24999m,
                StockQuantity = 8,
                CategoryId = 8,
                ImageUrl = "https://reimg-teknosa-cloud-prod.mncdn.com/mnresize/600/600/productimage/125088447/125088447_0_MC/58352340.jpg"
            },
            new Product
            {
                Name = "Xbox Series X",
                Description = "Yüksek grafik performansı ve hızlı işlem kapasitesi sunan yeni nesil oyun konsolu. Güçlü donanımı desteklenen oyunlarda yüksek çözünürlük ve akıcı görüntü deneyimi sağlamaya yardımcı olur. Hızlı depolama birimi oyunların yüklenme sürelerini azaltırken geniş oyun kütüphanesi farklı türlerde birçok seçeneğe erişim sunar. Kompakt ve sade tasarımı yaşam alanlarına kolayca uyum sağlayan cihaz, uzun süreli oyun oturumlarında güçlü performans isteyen kullanıcılar için geliştirilmiştir.",
                Price = 23999m,
                StockQuantity = 6,
                CategoryId = 8,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSZ48KpMabSbLzEtbL7Lby2rF0rY-cqhNo008KpnEkvjg&s=10"
            },
            new Product
            {
                Name = "Gaming Mouse RGB",
                Description = "Bilgisayar oyunlarında hızlı ve hassas kontrol sağlamak amacıyla tasarlanmış ergonomik oyuncu mouse modeli. Yüksek hassasiyetli sensörü sayesinde özellikle rekabetçi oyunlarda küçük hareketlerin bile doğru şekilde algılanmasına yardımcı olur. Programlanabilir tuşları farklı oyun ve uygulamalarda kişiselleştirilebilir. RGB aydınlatması masaüstüne görsel bir görünüm kazandırırken ergonomik gövdesi uzun süreli kullanım sırasında el ve bilek konforunu artırmaya yönelik tasarlanmıştır.",
                Price = 1299m,
                StockQuantity = 32,
                CategoryId = 8,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTf6xo3JLLoXAyJE8VqGr9Oirs9xB_t5dhty0it9P81Uw&s=10"
            },

            // CategoryId = 9 - Fotoğraf ve Kamera (3 ürün)
            new Product
            {
                Name = "Canon EOS 250D",
                Description = "Fotoğrafçılığa yeni başlayan ve gelişmiş manuel kontrol seçenekleri arayan kullanıcılar için tasarlanmış DSLR fotoğraf makinesi. Yüksek çözünürlüklü sensörü sayesinde ayrıntılı fotoğraflar çekmeye yardımcı olurken değiştirilebilir lens desteği farklı çekim senaryolarına uyum sağlar. Döner ekranı farklı açılardan çekim yapmayı kolaylaştırır. Video kayıt özellikleri sayesinde fotoğrafın yanı sıra çeşitli video içerikleri de oluşturulabilir ve kompakt gövdesi seyahatlerde rahatlıkla taşınabilir.",
                Price = 24999m,
                StockQuantity = 7,
                CategoryId = 9,
                ImageUrl = "https://cdn.akakce.com/canon/canon-eos-250d-18-55-mm-lens-dijital-slr-fotograf-makinesi-z.jpg"
            },
            new Product
            {
                Name = "Sony Alpha ZV-E10",
                Description = "Video içerik üreticileri, vlog hazırlayanlar ve fotoğraf çekmeye ilgi duyan kullanıcılar için geliştirilen aynasız kamera. Değiştirilebilir lens yapısı farklı çekim koşullarında esneklik sağlarken yüksek kaliteli sensörü ayrıntılı görüntüler oluşturulmasına yardımcı olur. Kompakt gövdesi sayesinde seyahat ve dış çekimlerde kolay taşınabilir. Döner ekran özellikle kendi kendine video çeken kullanıcılar için büyük avantaj sağlarken dahili mikrofon sistemi temel ses kayıt ihtiyaçlarını karşılayabilir.",
                Price = 28999m,
                StockQuantity = 5,
                CategoryId = 9,
                ImageUrl = "https://productimages.hepsiburada.net/s/777/375-375/110000786233921.jpg"
            },
            new Product
            {
                Name = "GoPro Hero",
                Description = "Macera, seyahat ve açık hava aktivitelerini yüksek kaliteli görüntülerle kaydetmek için tasarlanmış kompakt aksiyon kamerası. Küçük ve dayanıklı gövdesi sayesinde bisiklet, yürüyüş, kamp ve çeşitli spor aktivitelerinde kolayca kullanılabilir. Geniş açılı lens farklı çekim senaryolarında daha fazla alanın kadraja girmesine yardımcı olur. Video kayıt özellikleri hareketli görüntülerin ayrıntılı şekilde kaydedilmesini sağlarken taşınabilir yapısı günlük geziler için önemli bir avantaj sunar.",
                Price = 15999m,
                StockQuantity = 19,
                CategoryId = 9,
                ImageUrl = "https://m.media-amazon.com/images/I/71RXyyhiFNL._AC_UF350,350_QL80_.jpg"
            },

            // CategoryId = 10 - Aksesuar (5 ürün)
            new Product
            {
                Name = "Anker USB-C Şarj Adaptörü",
                Description = "Akıllı telefon, tablet ve diğer uyumlu elektronik cihazların hızlı ve güvenli şekilde şarj edilmesine yardımcı olan kompakt USB-C güç adaptörü. Küçük boyutu sayesinde evde, ofiste veya seyahat sırasında kolayca taşınabilir. Uyumlu cihazlarda hızlı şarj desteği sunarak bekleme süresini azaltır. Güvenlik sistemleri aşırı akım, aşırı voltaj ve aşırı ısınma gibi durumlara karşı koruma sağlamaya yardımcı olur. Günlük elektronik cihaz kullanıcıları için pratik bir aksesuardır.",
                Price = 899m,
                StockQuantity = 45,
                CategoryId = 10,
                ImageUrl = "https://cdn.akakce.com/z/anker/anker-312-pd-hizli.jpg"
            },
            new Product
            {
                Name = "Baseus USB-C Kablo",
                Description = "Akıllı telefon, tablet, bilgisayar ve çeşitli elektronik cihazlarda veri aktarımı ve şarj işlemleri için kullanılabilen dayanıklı USB-C kablo. Esnek dış kaplaması günlük kullanım sırasında kablonun daha uzun süre dayanmasına yardımcı olur. Uyumlu cihazlarda hızlı şarj desteği sunabilir ve veri aktarımı için de kullanılabilir. Kompakt yapısı sayesinde çantada veya çalışma masasında kolayca taşınabilir. Ev, ofis ve seyahat kullanımı için pratik bir bağlantı çözümüdür.",
                Price = 499m,
                StockQuantity = 63,
                CategoryId = 10,
                ImageUrl = "https://productimages.hepsiburada.net/s/530/375-375/110000588088636.jpg"
            },
            new Product
            {
                Name = "Spigen Telefon Kılıfı",
                Description = "Akıllı telefonları günlük kullanım sırasında çizilme, darbe ve küçük düşmelere karşı korumaya yardımcı olmak üzere tasarlanmış dayanıklı telefon kılıfı. Telefonun bağlantı noktalarına ve tuşlarına kolay erişim sağlayacak şekilde üretilmiştir. İnce yapısı cihazın genel tasarımını fazla değiştirmeden koruma sağlamaya yardımcı olur. Kaymaz yüzeyi telefonun elde daha güvenli tutulmasını kolaylaştırırken kamera bölümünü çevreleyen yükseltilmiş kenarlar ek koruma sunar.",
                Price = 799m,
                StockQuantity = 38,
                CategoryId = 10,
                ImageUrl = "https://productimages.hepsiburada.net/s/777/375-375/110000766674082.jpg"
            },
            new Product
            {
                Name = "Samsung 25W Şarj Cihazı",
                Description = "Uyumlu Samsung cihazlar başta olmak üzere çeşitli USB-C destekli elektronik ürünlerin hızlı şekilde şarj edilmesine yardımcı olan kompakt güç adaptörü. 25W güç desteği sayesinde uygun cihazlarda standart adaptörlere kıyasla daha kısa sürede şarj imkanı sunabilir. Küçük ve hafif tasarımı sayesinde seyahatlerde kolayca taşınabilir. Güvenlik özellikleri cihazların daha güvenli şekilde şarj edilmesine yardımcı olurken sade tasarımı ev ve ofis kullanımına uygundur.",
                Price = 699m,
                StockQuantity = 52,
                CategoryId = 10,
                ImageUrl = "https://productimages.hepsiburada.net/s/334/375-375/110000339538582.jpg"
            },
            new Product
            {
                Name = "Kablosuz Şarj Standı",
                Description = "Uyumlu akıllı telefonları kablo bağlantısı olmadan şarj etmeye yardımcı olan masaüstü kablosuz şarj standı. Telefonun dik konumda tutulmasını sağlayan tasarımı sayesinde şarj sırasında bildirimleri ve ekranı kolayca görüntülemek mümkündür. Çalışma masası veya komodin üzerinde fazla yer kaplamadan kullanılabilir. Kaymaz tabanı cihazın sabit kalmasına yardımcı olurken kompakt gövdesi sayesinde seyahatlerde de kolaylıkla taşınabilir ve günlük kullanımda pratiklik sağlar.",
                Price = 1199m,
                StockQuantity = 26,
                CategoryId = 10,
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS3Lwpd8J_opk9YQi6R5oQeyjp2qtaMWkHKksBzwMaoZAOY48BkFii0E70&s=10"
            }
        );
        await context.SaveChangesAsync();
    }

    private static async Task SeedRolesAndUsersAsync(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, EShopAppDbContext context)
    {
        string[] roles = ["Admin", "Customer"];
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        #region Admin Kullanıcısı
        var adminEmail = "admin@eshopapp.com";
        var adminPassword = "Qwe123.,";
        var adminFullName = "Abdullah Bayrak";
        var adminRole = "Admin";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser is null)
        {
            adminUser = new AppUser
            {
                Email = adminEmail,
                UserName = adminEmail,
                FullName = adminFullName,
                EmailConfirmed = true
            };
            var adminResult = await userManager.CreateAsync(adminUser, adminPassword);
            if (adminResult.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }
            await context.Carts.AddAsync(new Cart { AppUserId = adminUser.Id });
            await context.SaveChangesAsync();
        }
        #endregion

        #region Customer Kullanıcısı
        var customerEmail = "customer@eshopapp.com";
        var customerPassword = "Qwe123.,";
        var customerFullName = "İsmail İpekçi";
        var customerRole = "Customer";
        var customerUser = await userManager.FindByEmailAsync(customerEmail);
        if (customerUser is null)
        {
            customerUser = new AppUser
            {
                Email = customerEmail,
                UserName = customerEmail,
                FullName = customerFullName,
                EmailConfirmed = true
            };
            var customerResult = await userManager.CreateAsync(customerUser, customerPassword);
            if (customerResult.Succeeded)
            {
                await userManager.AddToRoleAsync(customerUser, customerRole);
            }
            await context.Carts.AddAsync(new Cart { AppUserId = customerUser.Id });
            await context.SaveChangesAsync();
        }
        #endregion

    }
}
