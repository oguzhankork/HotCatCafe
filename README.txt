															# HOTCAT CAFE PROJECT

PROJE ÖZELLÝKLERÝ

•	ASP.NET 8: Proje, ASP.NET 8 kullanýlarak geliþtirilmiþtir ve güncel web geliþtirme standartlarýna uygun bir yapý sunmaktadýr.

•	N-Tier Mimari: Uygulama, katmanlý mimari ile tasarlanmýþ olup, iþ mantýðý, veri eriþimi ve sunum katmanlarý birbirinden ayrýlmýþtýr. Bu sayede uygulama		   yönetilebilir, ölçeklenebilir ve bakým yapýlabilir hale getirilmiþtir.

•	Generic Repository: Veri eriþim katmanýnda generic repository deseni kullanýlarak, veri iþlemleri merkezi bir þekilde yönetilmiþ ve tekrar kullanýlabilir kod   yapýlarý oluþturulmuþtur.

•	SOLID Prensipleri: Proje, SOLID prensiplerine uygun olarak yazýlmýþtýr. Bu, projenin esnek, sürdürülebilir ve geniþletilebilir olmasýný saðlamaktadýr.

•	ASP.NET Identity: Kullanýcý yönetimi ve kimlik doðrulama iþlemleri için ASP.NET Identity kütüphanesi entegre edilmiþtir. Bu sayede kullanýcý kaydý, giriþ,     rol yönetimi gibi iþlemler güvenli bir þekilde saðlanmaktadýr.

		- Kullanýcý Doðrulama: Kullanýcýlar, üye olduktan sonra email adreslerine gönderilen bir doðrulama maili ile hesaplarýný aktif hale getirebilirler. Bu doðrulama maili, kullanýcýya özel bir token içermektedir ve bu token kullanýlarak hesap doðrulamasý yapýlmaktadýr.

•	Email Gönderme Ýþlemleri: Sistem, belirli durumlarda email gönderebilmektedir. Örneðin, stok seviyesi belirli bir eþiðin altýna düþtüðünde, yetki verilen      personel satýn alma birimine uyarý emaili gönderebilir.

•	Ürün Fotoðraf Yükleme: Yeni bir ürün eklendiðinde, ürünle birlikte fotoðraf yüklenebilir. 

•	Web API: Proje, masa, sipariþ gibi iþlemler için RESTful API içermektedir. API sistemin harici uygulamalar veya mobil cihazlarla entegrasyonunu				   kolaylaþtýrýr.

•   Admin Dashboard: Yönetici arayüzü, AdminLTE temasý kullanýlarak tasarlanmýþtýr. Bu dashboard, yöneticilerin sistemdeki verileri izlemesi, raporlamasý ve       yönetmesi için modern ve kullanýcý dostu bir arayüz sunar.

•	HTML5, CSS3 ve JavaScript: Projenin kullanýcý arayüzü HTML5, CSS3 JavaScript ve BootStrap kullanýlarak tasarlanmýþtýr. Modern ve duyarlý bir web tasarýmý      sunulmuþtur.

•	MS SQL Server: Projede, veritabaný olarak Microsoft SQL Server kullanýlmýþtýr. Tüm veri iþlemleri ve saklama bu veritabaný üzerinde gerçekleþtirilir.


KURULUM

Gerekli Yazýlýmlar
•	.NET SDK 8.0
•	MS SQL Server (veya baþka bir iliþkisel veritabaný)
•	Visual Studio 2022 veya üzeri

Adýmlar
1.	Proje Dosyalarýný Ýndirin: Projeyi bilgisayarýnýza indirin veya kopyalayýn.
2.	Veritabanýný Yapýlandýrýn: appsettings.json dosyasýndaki baðlantý dizesini (ConnectionString) kendi veritabanýnýza göre güncelleyin.
3.	Veritabaný Migrasyonlarýný Uygulayýn: Paket Yöneticisi Konsolu'nu açarak komutlarý çalýþtýrýn.
4.	Projeyi Çalýþtýrýn: Visual Studio'dan projeyi baþlatýn.

Kullaným
•	Kullanýcý Yönetimi: Proje, ASP.NET Identity kullanarak kullanýcýlarýn kaydolmasýný, giriþ yapmasýný ve rollerle yönetilmesini saðlar.
•	Masa Yönetimi: Kafedeki masalar API veya MVC üzerinden yönetilebilir. Masalara sipariþler eklenebilir veya mevcut sipariþler güncellenebilir.
•	Sipariþ Yönetimi: Garsonlar, masalar için sipariþ alabilir, ürün ekleyebilir veya sipariþleri kapatabilir.
•	Stok Yönetimi: Ürünlerin stok seviyeleri takip edilir ve belirli bir seviyenin altýna düþtüðünde satýn alma birimine email gönderilebilinir.
•	Admin Dashboard: Yönetici paneli, AdminLTE temasý ile tasarlanmýþtýr ve yöneticilerin verileri izlemesi, raporlamasý ve yönetmesi için modern bir kullanýcý    arayüzü saðlar.

Proje Yapýsý
•	HotCatCafe.MVC: Uygulamanýn web katmaný, MVC yapý ile kullanýcý arayüzünü ve kontrolcülerini içerir.
•	HotCatCafe.Model: Uygulamanýn temel entity modelleri ve arayüzleri burada bulunur.
•	HotCatCafe.DAL: Veri eriþim katmaný, veritabaný iþlemlerinin gerçekleþtirildiði yerdir. Entity Framework Core kullanýlarak veri tabaný iþlemleri yapýlýr.
•	HotCatCafe.BLL: Ýþ servisleri, veritabaný eriþim katmanýyla iþ mantýðý katmaný arasýnda köprü görevi görür. Business logic burada yer alýr.
•	HotCatCafe.IOC: Uygulamanýn baðýmlýlýk yönetim katmaný, baðýmlýlýklarý ayýrarak proje yönetimini kolaylaþtýrýr.
•	HotCatCafe.Common: Projenin daha esnek olabilmesi için her bir katmanda ortak olarak kullanýlacak iþlemler/yapýlar bu katmanda yer almaktadýrlar.
•	HotCatCafe.API: Uygulamanýn API katmaný, RESTful servisleri sunar ve dýþ sistemlerle entegrasyon saðlar.


GELÝÞTÝRME SÜRECÝ

Bu projeyi geliþtirmek için þu teknolojiler ve kütüphaneler kullanýlmýþtýr:
•	.NET 8
•	Entity Framework Core
•	ASP.NET Identity
•	Fluent Validation
•	Swagger (API dokümantasyonu için)
•	HTML5, CSS3 ve JavaScript (Frontend tasarýmý için)
•	MS SQL Server (Veritabaný için)
•	7 katmandan meydana getirildi. 

- Model 

	- Model Katmaný : Model katmaný Data Access Layer katmanýnda varlýklarý temsil eden Entity'leri barýndýran katmandýr.
	- Interfaces : Bütün classlara öncülük eden özellikleri barýndýrýr.
	- Base : Interface' den alýnan özellikleri bünyesine dahil eder.
	- Enums : Modellerde kullanýlan sabitleri temsil eder.

- DAL (Data Access Layer)

	- Veritabanýna ulaþým katmanýdýr. Veritabaný ile ilgili modeller, tasarým desenleri vs gibi varlýklar bu katman içerisinde kullanýlmaktadýr.
	- Context : Veritabaný modellerini temsil eder.
	- Configuration : Veritabaný modellerinin kurulum aþamasýnda alan isimlerinin özellikleri, içerisinde bulunmasýný istediðimiz verileri configure etmek için oluþturuldu.

- BLL (Business Logic Layer) 

	- Ýþ mantýðý katmaný olarak kullanýldý. Kullanýcýnýn istekte bulunduðu bütün iþlemler ilk olarak bu katman tarafýndan karþýlanýyor. 
	- Repositories : 
		-- Abstracts : 
			--- Base Abstracts :
				IRepository : Bu interface bütün iþlemlere öncülük edecek metotlarýn kurallarýný barýndýrmaktadýr. Interface dýþarýdan bir T alýr. Bu interface e gelen T tipinde model set edilip bütün modellerde CRUD iþlemleri yapýldý. 

				ITableSessionService(T) : Bu ve T tipinde türevi servisler IRepository'de oluþturulan eylemleri bünyesine alýr. IRepository'de oluþturulan kurallarýn haricinde spesifik eylemlerin kurallarý oluþturuldu. Örneðin TableSEssionService'de gerçekleþtirildiði gibi. (Bknz. TableSessionService)
  
		-- Concretes
			---BaseConcrete :
				BaseRepository : IRepository'den miras alarak eylemleri somut hale dönüþtüren sýnýftýr. Dýþarýdan T alýr.

- UI (User Interface) 

	- Görüntüleme katmanýný temsil eder.
	- MVC projesi bu katman içerisinde oluþturuldu.

- Common (Ortak Katman)
	
	- Projenin daha esnek olabilmesi için her bir katmanda ortak olarak kullanýlacak iþlemler/yapýlar bu katmanda yer almaktadýrlar.
	- ImageHelper: Ýçerisinde bulunan static metot vasýtasýyla dýþarýdan iletilen dosyanýn bir görsel olup olmadýðýný kontrol edilmesini ardýndan bu görselin projeye dahil edilmesini gerçekleþtirir.
	- EmailHelper : Ýçerisinde bulunan static metot vasýtasýyla dýþarýdan iletilen parametreler ile mail gönderen bir class.
	- ProductHelper : Ürün stoklarý kritik seviyeye ulaþtýðý zaman satýnalma personeline mail gönderen static classý barýndýrýr.

- IOC (Inversion of Control)
	
	- MVC projesindeki Program.cs classýnda yer alan baðýmlýlýklarýn yönetimini kolaylaþtýrmak amacý ile oluþturuldu.
	- Baðýmlýlýklarý ayrý bir katmana alarak clean code mantýðý ve baðýmlýlýklarýn yönetiminin kolaylaþtýrýlmasý amacýyla oluþturuldu.

- API (Application Programming Interface)

	- Kullanýcý deneyimini arttýrmak amacýyla api ayrý bir katmanda oluþturuldu. 
	- Web api da kullanýcýnýn masalara ürün ekleme silme ve güncelleme iþlemlerini gerçekleþtirebilmesi eylemlerini barýndýrýr.
	- Burada yapýlan iþlemler BLL katmanýndan referans alýnarak gerçekleþir.
	- Mobil veya baþka bir cihaz için api yazýlmak istenirse ayrý bir katman oluþturarak projenin yönetimini modüler yapýsýný bozmadan ayrý bir api eklenip kullanýma sunulabilir.
	



