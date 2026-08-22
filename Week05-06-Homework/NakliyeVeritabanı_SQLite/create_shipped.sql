/*
====================================================================
 HAFTA 06 — NAKLİYE OPERASYONU (SQLite)
====================================================================

 Senaryo:
 Bölgesel bir nakliye firması, müşteri şirketlere karayolu
 sevkiyatı yapar. Operasyon masası hangi aracın, hangi şoförle,
 hangi müşterinin yükünü nereye götürdüğünü ve teslim olup
 olmadığını bu veritabanından takip eder. Navlun (Freight)
 sevkiyat ücretidir; faturalama ve hat kârlılığı bu alandan
 hesaplanır.

 Tablolar:

 Customer
   Sözleşmeli müşteri firma. City sevkiyat çıkış/varış
   planlamasında kullanılır. ContractType: Spot (tek sefer)
   veya Yillik (anlaşma). Email NULL olabilir (eksik kart).
   IsActive = 0 olan firma yeni iş almaz; geçmiş sevkiyatı
   durur.

 Vehicle
   Filodaki araç. Plate plaka, VehicleType kamyon/tir/kamyonet,
   CapacityTon taşıma kapasitesi (ton). IsActive = 0 bakımda
   veya satılmış araçtır.

 Driver
   Şoför. HireDate işe giriş, LicenseClass ehliyet sınıfı
   (C, CE, D). Phone NULL olabilir.

 Shipment
   Tek bir sevkiyat iş emri. CustomerId, VehicleId, DriverId
   yabancı anahtarları operasyonu bağlar.
   OriginCity / DestCity güzergah, ShipDate çıkış tarihi,
   DeliverDate teslim (NULL = yolda veya planlandı, henüz
   teslim yok). DistanceKm mesafedir.
   Status: 'Planlandi' | 'Yolda' | 'Teslim' | 'Iptal'.
   Freight navlun tutarı (TL).
   CHECK: DeliverDate boşsa sorun yok; doluysa ShipDate'ten
   önce olamaz.

 İlişkiler:
   Customer 1──* Shipment
   Vehicle  1──* Shipment
   Driver   1──* Shipment

 Seed özeti:
   6 müşteri, 5 araç, 6 şoför, 28 sevkiyat.
   Sorguda: Email/Phone/DeliverDate IS NULL, Status IN,
   şehir tekrarı, pasif müşteri/araç, iptal ve yoldaki işler,
   2026 teslimleri, navlun aralığı.

 Kullanım:
   veya DB Browser: New Database → shipped.sqlite,
   Execute SQL → create_shipped.sql
====================================================================
*/

PRAGMA foreign_keys = ON;

DROP TABLE IF EXISTS Shipment;
DROP TABLE IF EXISTS Driver;
DROP TABLE IF EXISTS Vehicle;
DROP TABLE IF EXISTS Customer;

CREATE TABLE Customer (
    CustomerId     INTEGER PRIMARY KEY AUTOINCREMENT,
    CompanyName    TEXT    NOT NULL,
    City           TEXT    NOT NULL,
    Email          TEXT    NULL,
    ContractType   TEXT    NOT NULL,
    IsActive       INTEGER NOT NULL DEFAULT 1
);

CREATE TABLE Vehicle (
    VehicleId      INTEGER PRIMARY KEY AUTOINCREMENT,
    Plate          TEXT    NOT NULL UNIQUE,
    VehicleType    TEXT    NOT NULL,
    CapacityTon    REAL    NOT NULL,
    IsActive       INTEGER NOT NULL DEFAULT 1
);

CREATE TABLE Driver (
    DriverId       INTEGER PRIMARY KEY AUTOINCREMENT,
    FirstName      TEXT    NOT NULL,
    LastName       TEXT    NOT NULL,
    LicenseClass   TEXT    NOT NULL,
    HireDate       TEXT    NOT NULL,
    Phone          TEXT    NULL,
    IsActive       INTEGER NOT NULL DEFAULT 1
);

CREATE TABLE Shipment (
    ShipmentId     INTEGER PRIMARY KEY AUTOINCREMENT,
    CustomerId     INTEGER NOT NULL,
    VehicleId      INTEGER NOT NULL,
    DriverId       INTEGER NOT NULL,
    OriginCity     TEXT    NOT NULL,
    DestCity       TEXT    NOT NULL,
    ShipDate       TEXT    NOT NULL,
    DeliverDate    TEXT    NULL,
    DistanceKm     INTEGER NOT NULL,
    Freight        REAL    NOT NULL,
    Status         TEXT    NOT NULL DEFAULT 'Planlandi',
    CONSTRAINT FK_Shipment_Customer
        FOREIGN KEY (CustomerId) REFERENCES Customer (CustomerId),
    CONSTRAINT FK_Shipment_Vehicle
        FOREIGN KEY (VehicleId) REFERENCES Vehicle (VehicleId),
    CONSTRAINT FK_Shipment_Driver
        FOREIGN KEY (DriverId) REFERENCES Driver (DriverId),
    CONSTRAINT CK_Shipment_Deliver
        CHECK (DeliverDate IS NULL OR DeliverDate >= ShipDate)
);

INSERT INTO Customer (CustomerId, CompanyName, City, Email, ContractType, IsActive) VALUES
(1, 'Ege Gida A.S.',          'Izmir',     'lojistik@egegida.com',     'Yillik', 1),
(2, 'Anadolu Celik Ltd.',     'Bursa',     'sevk@anadolucelik.com',    'Yillik', 1),
(3, 'Marmara Kimya',          'Istanbul',  NULL,                       'Spot',   1),
(4, 'Akdeniz Tekstil',        'Antalya',   'depo@akdeniztekstil.com',  'Yillik', 1),
(5, 'Karadeniz Orman Urunleri','Trabzon',  'info@kormun.com',          'Spot',   1),
(6, 'Iç Anadolu Yem',         'Konya',     'siparis@icyem.com',        'Yillik', 0);

INSERT INTO Vehicle (VehicleId, Plate, VehicleType, CapacityTon, IsActive) VALUES
(1, '34 ABC 120', 'Tir',      24.0, 1),
(2, '16 DEF 445', 'Kamyon',   12.0, 1),
(3, '35 GHI 778', 'Tir',      24.0, 1),
(4, '06 JKL 203', 'Kamyonet',  3.5, 1),
(5, '41 MNO 991', 'Kamyon',   10.0, 0);

INSERT INTO Driver (DriverId, FirstName, LastName, LicenseClass, HireDate, Phone, IsActive) VALUES
(1, 'Hasan',  'Demir',   'CE', '2018-04-10', '5321112233', 1),
(2, 'Murat',  'Kaya',    'CE', '2019-09-01', '5332223344', 1),
(3, 'Cem',    'Yilmaz',  'C',  '2021-02-15', NULL,         1),
(4, 'Okan',   'Aydin',   'CE', '2020-11-20', '5354445566', 1),
(5, 'Serkan', 'Ozdemir', 'C',  '2023-06-01', '5365556677', 1),
(6, 'Levent', 'Arslan',  'CE', '2016-01-12', '5376667788', 0);

INSERT INTO Shipment (CustomerId, VehicleId, DriverId, OriginCity, DestCity, ShipDate, DeliverDate, DistanceKm, Freight, Status) VALUES
(1, 1, 1, 'Izmir',     'Istanbul',  '2025-01-12', '2025-01-13', 480, 18500, 'Teslim'),
(1, 3, 2, 'Izmir',     'Ankara',    '2025-03-04', '2025-03-05', 580, 21000, 'Teslim'),
(1, 1, 1, 'Izmir',     'Bursa',     '2026-02-10', '2026-02-11', 330, 14200, 'Teslim'),
(1, 3, 4, 'Izmir',     'Istanbul',  '2026-04-02', NULL,         480, 19000, 'Yolda'),
(2, 2, 2, 'Bursa',     'Ankara',    '2024-11-18', '2024-11-19', 385, 12800, 'Teslim'),
(2, 1, 1, 'Bursa',     'Izmir',     '2025-06-09', '2025-06-10', 330, 13500, 'Teslim'),
(2, 2, 5, 'Bursa',     'Istanbul',  '2025-09-22', '2025-09-22', 155,  7200, 'Teslim'),
(2, 1, 4, 'Bursa',     'Antalya',   '2026-01-20', '2026-01-21', 540, 19800, 'Teslim'),
(3, 3, 2, 'Istanbul',  'Ankara',    '2025-02-14', '2025-02-15', 450, 16800, 'Teslim'),
(3, 4, 3, 'Istanbul',  'Bursa',     '2025-05-03', '2025-05-03', 155,  4800, 'Teslim'),
(3, 3, 1, 'Istanbul',  'Izmir',     '2025-12-11', '2025-12-12', 480, 17600, 'Teslim'),
(3, 1, 2, 'Istanbul',  'Ankara',    '2026-03-08', NULL,         450, 17200, 'Yolda'),
(4, 3, 4, 'Antalya',   'Izmir',     '2024-08-21', '2024-08-22', 470, 16400, 'Teslim'),
(4, 2, 5, 'Antalya',   'Istanbul',  '2025-04-16', '2025-04-17', 720, 24500, 'Teslim'),
(4, 3, 4, 'Antalya',   'Ankara',    '2025-10-05', '2025-10-07', 550, 22000, 'Teslim'),
(4, 1, 1, 'Antalya',   'Bursa',     '2026-02-28', NULL,         620, 20500, 'Planlandi'),
(5, 2, 2, 'Trabzon',   'Ankara',    '2025-01-28', '2025-01-30', 760, 26800, 'Teslim'),
(5, 1, 4, 'Trabzon',   'Istanbul',  '2025-07-14', '2025-07-16', 1070,31200, 'Teslim'),
(5, 3, 2, 'Trabzon',   'Bursa',     '2025-11-09', '2025-11-11', 980, 28900, 'Teslim'),
(5, 2, 5, 'Trabzon',   'Ankara',    '2026-03-15', NULL,         760, 27500, 'Yolda'),
(6, 5, 6, 'Konya',     'Ankara',    '2023-09-02', '2023-09-02', 260,  8900, 'Teslim'),
(6, 2, 3, 'Konya',     'Izmir',     '2024-02-19', '2024-02-20', 530, 15600, 'Teslim'),
(6, 5, 6, 'Konya',     'Istanbul',  '2024-06-07', '2024-06-08', 660, 18100, 'Iptal'),
(1, 4, 3, 'Izmir',     'Aydin',     '2025-08-01', '2025-08-01', 120,  3100, 'Teslim'),
(2, 4, 3, 'Bursa',     'Eskisehir', '2025-08-19', '2025-08-19', 150,  3600, 'Teslim'),
(3, 4, 5, 'Istanbul',  'Kocaeli',   '2026-01-05', '2026-01-05', 100,  2800, 'Teslim'),
(4, 2, 5, 'Antalya',   'Mersin',    '2024-12-20', '2024-12-21', 470, 14900, 'Iptal'),
(5, 1, 1, 'Trabzon',   'Samsun',    '2026-04-10', NULL,         330, 11200, 'Planlandi');
