--1. Operasyon ekranı ilk açıldığında tüm müşteri kayıtlarını görmek istiyorsunuz. Customer tablosundaki bütün kolonları listeleyin.

SELECT 
	*
FROM CUSTOMER c

--2.Müşteri kartı özetinde yalnızca firma adı, şehir ve sözleşme tipi yeter. Customer tablosundan sadece CompanyName, City ve ContractType kolonlarını getirin.

SELECT 
	c.CompanyName,
	c.City,
	c.ContractType
FROM Customer c

--3.Filodaki araçların plaka, tipi ve tonaj kapasitesini gösteren kısa bir liste hazırlayın. Vehicle tablosundan Plate, VehicleType ve CapacityTon kolonlarını seçin.

SELECT 
	v.Plate,
	v.VehicleType,
	v.CapacityTon
FROM Vehicle v

--4.Şoför listesinde ad ve soyadı tek kolonda, yanında ehliyet sınıfı görünsün. FirstName ile LastName değerlerini birleştirip AdSoyad adında bir kolon üretin; yanına LicenseClass ekleyin.

SELECT
	d.FirstName || ' ' || d.LastName AS AdSoyad,
	d.LicenseClass
FROM Driver d

--5.Yönetim, sistemde kaç sevkiyat kaydı olduğunu tek sayı olarak istiyor. Shipment tablosundaki satır sayısını SevkiyatSayisi adıyla döndürün.

SELECT 
	COUNT(*) AS SevkiyatSayisi
FROM Shipment s

--6.Güzergah açılır listesi için varış şehirlerinin tekrarsız listesini çıkarın. Shipment.DestCity için DISTINCT kullanın ve şehir adına göre artan sıralayın.

SELECT 
	DISTINCT
	s.DestCity
FROM Shipment s
ORDER BY s.DestCity

--7.Araç tiplerinin tekrarsız listesini alın (Vehicle.VehicleType, DISTINCT). Alfabetik sıralayın.

SELECT 
	DISTINCT
	v.VehicleType
FROM Vehicle v
ORDER BY v.VehicleType

--8.Sözleşmesi devam eden, yeni iş alınabilecek müşterileri bulun. IsActive = 1 olan müşterilerin firma adı, şehri ve sözleşme tipini listeleyin.

SELECT 
	c.CompanyName,
	c.City,
	c.ContractType
FROM Customer c
WHERE IsActive = 1

--9.Artık yeni iş verilmeyen (pasif) müşterileri bulun. IsActive = 0 olan kayıtların CompanyName ve City bilgilerini getirin.

SELECT 
	c.CompanyName,
	c.City
FROM Customer c
WHERE IsActive = 0

--10.Yüksek navlunlu işleri ayırmak istiyorsunuz. Freight değeri 20.000’den büyük olan sevkiyatların ShipmentId, OriginCity, DestCity ve Freight kolonlarını, navlun azalan olacak şekilde sıralayın.

SELECT 
	s.ShipmentId,
	s.OriginCity,
	s.DestCity,
	s.Freight
FROM Shipment s
WHERE s.Freight > 20000
ORDER BY s.Freight DESC

--11.Navlunu 21.000 veya daha fazla olan sevkiyatları bulun (>=). 10. sorudaki > ile farkı sonuçlarda görün.

SELECT 
	s.ShipmentId,
	s.OriginCity,
	s.DestCity,
	s.Freight
FROM Shipment s
WHERE s.Freight >= 21000
ORDER BY s.Freight DESC

--12.Kısa mesafe işleri: DistanceKm 200’den küçük olan sevkiyatların çıkış şehri, varış şehri, mesafe ve navlununu listeleyin.

SELECT 
	s.OriginCity,
	s.DestCity,
	s.DistanceKm,
	s.Freight
From Shipment s
WHERE s.DistanceKm < 200
ORDER BY s.DistanceKm

--13.Mesafesi 155 km veya daha kısa olan sevkiyatları getirin (<=).

SELECT 
	s.OriginCity,
	s.DestCity,
	s.DistanceKm,
	s.Freight
From Shipment s
WHERE s.DistanceKm <= 155
ORDER BY s.DistanceKm

--14.Orta bant navlun: Freight değeri 10.000 ile 20.000 arasında (iki uç dahil) olan sevkiyatları BETWEEN ile bulun. Navluna göre artan sıralayın.

SELECT 
	s.OriginCity,
	s.DestCity,
	s.DistanceKm,
	s.Freight
From Shipment s
WHERE s.Freight BETWEEN 10000 AND 21000
ORDER BY s.Freight

--15.Durumu tam olarak 'Yolda' olan sevkiyatları listeleyin. ShipmentId, güzergah (OriginCity, DestCity), ShipDate ve Freight görünsün.

SELECT 
	s.ShipmentId,
	s.OriginCity || ' - ' || s.DestCity AS Route,
	s.ShipDate,
	s.Freight
FROM Shipment s
WHERE s.Status = 'Yolda'

--16.Teslim edilmiş sevkiyatları (Status = 'Teslim') ShipDate’e göre yeniden eskiye sıralayın.

SELECT 
	s.ShipmentId,
	s.OriginCity || ' - ' || s.DestCity AS Route,
	s.ShipDate,
	s.Freight
FROM Shipment s
WHERE s.Status = 'Teslim'
ORDER BY s.ShipDate DESC

--17.Sözleşme tipi 'Spot' olan müşterilerin firma adı ve e-postasını getirin.

SELECT 
	c.CompanyName,
	c.Email
FROM Customer c
WHERE c.ContractType = 'Spot'

--18.Filodaki 'Tir' tipi araçları plaka ve kapasiteyle listeleyin.

SELECT 
	v.Plate,
	v.CapacityTon
FROM Vehicle v
WHERE v.VehicleType LIKE 'Tir'

--19.Ehliyet sınıfı 'CE' olan şoförlerin ad, soyad, işe giriş tarihi ve telefonunu getirin.

SELECT 
	d.FirstName || ' ' || d.LastName AS AdSoyad,
	d.HireDate,
	d.Phone
FROM Driver d
WHERE d.LicenseClass = 'CE'

--20.Firma adında Gida geçen müşterileri LIKE ile bulun (CompanyName).

SELECT 
	c.CompanyName
FROM Customer c
WHERE c.CompanyName LIKE '%Gida%'

--21.Plakası 34 ile başlayan araçları bulun (Plate LIKE '...').

SELECT 
	v.Plate
FROM Vehicle v
WHERE v.Plate LIKE '34%'

--22.Varış şehri an ifadesini herhangi bir yerinde içeren sevkiyatları listeleyin (DestCity LIKE). Çıkış, varış ve status kolonları olsun.

SELECT 
	s.OriginCity,
	s.DestCity,
	s.Status
FROM Shipment s
WHERE s.DestCity LIKE '%an%'
ORDER BY s.OriginCity 

--23.Şoför soyadı demir içeren kayıtları LIKE ile arayın (büyük/küçük harf ve Türkçe karakter yazımına dikkat edin; tablodaki hali Demir / Ozdemir olabilir).

SELECT
	d.FirstName,
	UPPER(d.LastName) AS LastName
FROM Driver d
WHERE d.LastName LIKE '%DEMIR%'

SELECT
	*
FROM Driver d
WHERE d.LastName LIKE '%Demir%' OR d.LastName LIKE '%demir%'

--24.Operasyon “şu an kapanmamış işler” istiyor: durumu 'Yolda' veya 'Planlandi' olan sevkiyatları IN ile tek listede getirin. OR zinciri yazmayın.

SELECT
	*
FROM Shipment s
WHERE s.Status IN ('Yolda', 'Planlandi')

--25.Çıkış şehri Izmir veya Istanbul olan sevkiyatları OriginCity IN (...) ile bulun. Navluna göre azalan sıralayın.

SELECT
	*
FROM Shipment s
WHERE s.OriginCity IN ('Istanbul', 'Izmir')
ORDER BY s.Freight DESC

--26.İptal edilmemiş tüm sevkiyatları bulun. Status NOT IN ('Iptal') kullanın. ShipmentId, güzergah, status ve navlun görünsün; ShipDate artan olsun.

SELECT 
	ShipmentId,
	s.OriginCity || ' - ' || s.DestCity AS Route,
	s.Status,
	s.Freight
FROM Shipment s
WHERE s.Status NOT IN ('Iptal')
ORDER BY ShipDate

--27.'Tir' olmayan araçları VehicleType <> 'Tir' veya NOT ile listeleyin (plaka, tip, kapasite).

SELECT 
	v.Plate,
	v.VehicleType,
	v.CapacityTon
FROM Vehicle v
WHERE v.VehicleType != 'Tir'

--28.Kartı eksik müşteriler: Email değeri NULL olan müşterilerin firma adı ve şehrini IS NULL ile bulun. (Email = NULL yazmayın.)

SELECT 
	c.CompanyName,
	c.City
FROM Customer c
WHERE c.Email IS NULL

--29.Telefonu kayıtlı olmayan şoförleri Phone IS NULL ile bulun (ad, soyad, ehliyet sınıfı).

SELECT
	d.FirstName,
	d.LastName,
	d.LicenseClass
FROM Driver d
WHERE d.Phone IS NULL

--30.Henüz teslim tarihi girilmemiş sevkiyatları bulun (DeliverDate IS NULL). Bunlar yoldaki veya planlanan işlerdir. ShipmentId, güzergah, ShipDate, Status gösterin.

SELECT 
	s.ShipmentId,
	s.OriginCity || ' - ' || s.DestCity AS Route,
	s.ShipDate,
	s.Status
FROM Shipment s
WHERE s.DeliverDate IS NULL

--31.Teslim tarihi dolu olan sevkiyatları DeliverDate IS NOT NULL ile getirin. Teslim tarihine göre azalan sıralayın.

SELECT 
	s.ShipmentId,
	s.OriginCity || ' - ' || s.DestCity AS Route,
	s.ShipDate,
	s.Status
FROM Shipment s
WHERE s.DeliverDate IS NOT NULL
ORDER BY s.DeliverDate DESC

--32.2026 yılında yola çıkan sevkiyatları bulun. ShipDate üzerinden yıl alın (strftime). ShipmentId, ShipDate, güzergah, Status listelensin; tarihe göre artan sıralayın.

SELECT
	s.ShipmentId,
	s.OriginCity || ' - ' || s.DestCity AS Route,
	s.ShipDate,
	s.Status
FROM Shipment s
WHERE strftime('%Y', s.ShipDate) = '2026'
ORDER BY s.ShipDate

--33.Ağustos ayında yola çıkan sevkiyatları bulun. Ay karşılaştırmasını '08' metniyle yapın. Yıl fark etmesin (tüm yıllardaki ağustoslar).

SELECT
	s.ShipmentId,
	s.OriginCity || ' - ' || s.DestCity AS Route,
	s.ShipDate,
	s.Status
FROM Shipment s
WHERE strftime('%m', s.ShipDate) = '08'
ORDER BY s.ShipDate DESC

--34.2025 yılının ilk yarısında kalkan işler: ShipDate 2025-01-01 ile 2025-06-30 arasında (dahil) olan sevkiyatları BETWEEN ile listeleyin.

SELECT
	s.ShipmentId,
	s.OriginCity || ' - ' || s.DestCity AS Route,
	s.ShipDate,
	s.Status
FROM Shipment s
WHERE ShipDate BETWEEN '2025-01-01' AND '2025-06-30'
ORDER BY s.ShipDate 

--35.Tüm sevkiyatları navluna göre en yüksekten en düşüğe sıralayın (ORDER BY Freight DESC). Kolonlar: ShipmentId, güzergah, Freight, Status.

SELECT 
	s.ShipmentId,
	s.OriginCity || ' - ' || s.DestCity AS Route,
	s.Freight,
	s.Status
FROM Shipment s
ORDER BY s.Freight DESC

--36.Şoförleri önce soyada, soyad eşitse ada göre A→Z sıralayın.

SELECT
	*
FROM Driver d
ORDER BY d.LastName, d.FirstName

--37.Her müşterinin kaç sevkiyatı olduğunu bulun. Sonuçta firma adı ve SevkiyatSayisi olsun. Bunun için Customer ile Shipment JOIN edilmeli; GROUP BY firma adına (ve gerekirse CustomerId) göre yapılmalı. Sayıya göre azalan sıralayın.

SELECT 
	c.CompanyName,
	COUNT(s.ShipmentId) AS SevkiyatSayisi
FROM Customer c
	JOIN Shipment s ON c.CustomerId = s.CustomerId
GROUP BY c.CompanyName, c.CustomerId
ORDER BY SevkiyatSayisi DESC

--38.Status değerine göre kaç sevkiyat olduğunu sayın (GROUP BY Status). Kolonlar: Status, Adet. Adede göre azalan sıralayın.

SELECT
	s.Status,
	COUNT(s.ShipmentId) AS Adet
FROM Shipment s
GROUP BY s.Status
ORDER BY Adet DESC

--39.Araç tipine göre filodaki araç sayısını bulun (GROUP BY VehicleType).

SELECT
	v.VehicleType,
	COUNT(v.VehicleId) AS Adet
FROM Vehicle v
GROUP BY v.VehicleType
ORDER BY Adet DESC

--40.Ortalama navlunu 15.000’den yüksek olan müşterileri bulun. Müşteri adı, sevkiyat adedi ve ortalama navlun (AVG(Freight)) görünsün. Grup filtresi için HAVING kullanın (WHERE ile ortalama süzülmez). Ortalamaya göre azalan sıralayın.

SELECT
	c.CompanyName,
	COUNT(s.ShipmentId) AS SevkiyatSayisi,
	AVG(s.Freight) AS OrtalamaNavlun
FROM Shipment s
	JOIN Customer c ON s.CustomerId = c.CustomerId
GROUP BY c.CompanyName
HAVING OrtalamaNavlun > 15000
ORDER BY OrtalamaNavlun DESC

--41.En az 4 sevkiyatı olan şoförleri bulun. Şoförün AdSoyad birleşik kolonu, sevkiyat sayısı. HAVING COUNT(*) >= 4. Sayıya göre azalan sıralayın.

SELECT
	d.FirstName || ' ' || d.LastName AS AdSoyad,
	COUNT(*) AS SevkiyatSayisi
FROM Shipment s
	JOIN Driver d ON s.DriverId = d.DriverId
GROUP BY d.DriverId, d.FirstName, d.LastName
HAVING COUNT(*) >= 4
ORDER BY SevkiyatSayisi DESC;

--42.Her sevkiyat satırında müşteri firma adı da görünsün. Shipment ile Customer arasında INNER JOIN kurun (CustomerId). Kolonlar: ShipmentId, CompanyName, OriginCity, DestCity, Freight, Status. ShipDate artan olsun.
--INNER JOIN sadece müşterisi olan sevkiyatları getirir.

SELECT 
	s.ShipmentId,
	c.CompanyName,
	s.OriginCity,
	s.DestCity,
	s.Freight,
	s.Status,
	s.ShipDate 
FROM Shipment s
	INNER JOIN Customer c ON s.CustomerId = c.CustomerId
ORDER BY s.ShipDate

--43.Sevkiyat + şoför + plaka: Shipment, Driver ve Vehicle tablolarını INNER JOIN ile bağlayın. Kolonlar: ShipmentId, şoför AdSoyad, Plate, VehicleType, güzergah, Status.

SELECT
	s.ShipmentId,
	d.FirstName || ' ' || d.LastName AS AdSoyad,
	v.Plate,
	v.VehicleType,
	s.OriginCity || ' - ' || s.DestCity AS Route,
	s.Status
FROM Driver d
	INNER JOIN Shipment s ON d.DriverId = s.DriverId
	INNER JOIN Vehicle v ON s.VehicleId = v.VehicleId

--44.Tam operasyon satırı: sevkiyata müşteri firma adı, şoför adı-soyadı ve plakayı birlikte getirin (üç JOIN: Customer, Driver, Vehicle). Kolonlar: ShipDate, CompanyName, AdSoyad, Plate, güzergah, Freight, Status. Tarihe göre yeniden eskiye sıralayın.

SELECT
	s.ShipDate,
	c.CompanyName,
	d.FirstName || ' ' || d.LastName AS AdSoyad,
	v.Plate,
	s.OriginCity || ' - ' || s.DestCity AS Route,
	s.Freight,
	s.Status
FROM Shipment s
	JOIN Customer c ON s.CustomerId = c.CustomerId
	JOIN Driver d ON s.DriverId = d.DriverId
	JOIN Vehicle v ON s.VehicleId = v.VehicleId
ORDER BY s.ShipDate DESC

--45.Yalnızca tır ile yapılan ve durumu 'Teslim' olan işleri bulun. JOIN ile araç tipini alın; WHERE VehicleType = 'Tir' AND Status = 'Teslim'. Navluna göre azalan sıralayın. Kolonlar: firma adı, plaka, güzergah, Freight.

SELECT 
	c.CompanyName,
	v.Plate,
	s.OriginCity || ' - ' || s.DestCity AS Route,
	s.Freight
FROM Vehicle v
	JOIN Shipment s ON v.VehicleId = s.VehicleId
	JOIN Customer c ON s.CustomerId = c.CustomerId
WHERE v.VehicleType = 'Tir' AND s.Status = 'Teslim'

--46.'Yolda' durumunda hiç işi olmayan müşterileri bulun. Customer tablosunu Shipment’a LEFT JOIN edin; JOIN koşuluna Status = 'Yolda' ekleyin. WHERE s.ShipmentId IS NULL. Firma adı ve şehir listelensin. (INNER JOIN bu müşterileri düşürür; LEFT JOIN + IS NULL eşleşmeyenleri bırakır.)

SELECT
	c.CompanyName,
	c.City
FROM Customer c
	LEFT JOIN Shipment s ON c.CustomerId = s.CustomerId AND s.Status = 'Yolda'
WHERE s.ShipmentId IS NULL 

--47.Telefonu olmayan şoförlerin yaptığı teslim edilmiş sevkiyatlar: Driver ile Shipment JOIN, Phone IS NULL ve Status = 'Teslim'. Şoför adı, güzergah, ShipDate, Freight.

SELECT
	d.FirstName || ' ' || d.LastName AS AdSoyad,
	s.OriginCity || ' - ' || s.DestCity AS Guzergah,
	s.ShipDate,
	s.Freight
FROM Driver d
	JOIN Shipment s ON d.DriverId = s.DriverId
WHERE d.Phone IS NULL AND s.Status = 'Teslim'

/*48.Navlunu iş kuralına göre etiketleyin. CASE ile:

10.000’den küçük → 'Dusuk'
10.000–20.000 (20.000 dahil) → 'Orta'
20.000’den büyük → 'Yuksek' Kolon adı NavlunDilimi olsun. ShipmentId, güzergah, Freight, NavlunDilimi. Navluna göre artan sıralayın. */

SELECT
	s.ShipmentId,
	s.OriginCity || ' - ' || s.DestCity AS Guzergah,
	s.Freight,
	CASE
		WHEN s.Freight < 10000 THEN 'Dusuk'
		WHEN s.Freight <= 20000 THEN 'Orta'
		ELSE 'Yuksek'
	END AS NavlunDilimi
FROM Shipment s
ORDER BY s.Freight

/*49.Sevkiyat durumunu operasyon kuyruğuna çevirin (CASE):

'Planlandi' → 'Bekliyor'
'Yolda' → 'Sahada'
'Teslim' → 'Kapandi'
diğerleri (iptal vb.) → 'Iptal/Diger' Kolon: Kuyruk. Yalnızca çıkış şehri IN ('Izmir', 'Istanbul', 'Bursa') olan kayıtlar. JOIN ile firma adı da gelsin. Önce kuyruk, sonra ShipDate sıralayın. */

SELECT
	s.ShipmentId,
	c.CompanyName,
	s.OriginCity,
	s.ShipDate,
	s.Status,
	CASE s.Status
		WHEN 'Planlandi' THEN 'Bekliyor'
		WHEN 'Yolda' THEN 'Sahada'
		WHEN 'Teslim' THEN 'Kapandi'
		ELSE 'Iptal/Diger'
	END AS Kuyruk
FROM Shipment s
	JOIN Customer c ON s.CustomerId = c.CustomerId
WHERE s.OriginCity IN ('Izmir', 'Istanbul', 'Bursa')
ORDER BY Kuyruk, s.ShipDate 

/*50.Tek raporda iki kümeyi alt alta birleştirin (UNION):

Birinci SELECT: aktif şoförler (IsActive = 1); kolonlar: AdSoyad (birleşik ad), 'Aktif Sefer' etiketi (Tip).
İkinci SELECT: durumu 'Yolda' olan sevkiyatların şoförleri (JOIN); aynı iki kolon, etiket 'Yoldaki Sefer'. Kolon sayısı ve tipler uyumlu olsun. ORDER BY yalnızca en sonda, Tip sonra AdSoyad olsun. UNION tekrarlayan satırları eker; UNION ALL hepsini tutar. Bu soruda UNION kullanın. Aynı şoför hem aktif hem yoldaysa iki farklı Tip ile iki satır gelebilir; bu beklenen davranıştır. */

SELECT 
	d.FirstName || ' ' || d.LastName AS AdSoyad,
	'Aktif Sefer' AS Tip
FROM Driver d
WHERE d.IsActive = 1

UNION

SELECT 
	d.FirstName || ' ' || d.LastName AS AdSoyad,
	'Yoldaki Sefer' AS Tip
FROM Driver d
	JOIN Shipment s ON d.DriverId = s.DriverId
WHERE s.Status = 'Yolda'

ORDER BY Tip, AdSoyad 