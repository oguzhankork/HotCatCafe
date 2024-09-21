															# HOTCAT CAFE PROJECT

PROJE �ZELL�KLER�

�	ASP.NET 8: Proje, ASP.NET 8 kullan�larak geli�tirilmi�tir ve g�ncel web geli�tirme standartlar�na uygun bir yap� sunmaktad�r.

�	N-Tier Mimari: Uygulama, katmanl� mimari ile tasarlanm�� olup, i� mant���, veri eri�imi ve sunum katmanlar� birbirinden ayr�lm��t�r. Bu sayede uygulama		   y�netilebilir, �l�eklenebilir ve bak�m yap�labilir hale getirilmi�tir.

�	Generic Repository: Veri eri�im katman�nda generic repository deseni kullan�larak, veri i�lemleri merkezi bir �ekilde y�netilmi� ve tekrar kullan�labilir kod   yap�lar� olu�turulmu�tur.

�	SOLID Prensipleri: Proje, SOLID prensiplerine uygun olarak yaz�lm��t�r. Bu, projenin esnek, s�rd�r�lebilir ve geni�letilebilir olmas�n� sa�lamaktad�r.

�	ASP.NET Identity: Kullan�c� y�netimi ve kimlik do�rulama i�lemleri i�in ASP.NET Identity k�t�phanesi entegre edilmi�tir. Bu sayede kullan�c� kayd�, giri�,     rol y�netimi gibi i�lemler g�venli bir �ekilde sa�lanmaktad�r.

		- Kullan�c� Do�rulama: Kullan�c�lar, �ye olduktan sonra email adreslerine g�nderilen bir do�rulama maili ile hesaplar�n� aktif hale getirebilirler. Bu do�rulama maili, kullan�c�ya �zel bir token i�ermektedir ve bu token kullan�larak hesap do�rulamas� yap�lmaktad�r.

�	Email G�nderme ��lemleri: Sistem, belirli durumlarda email g�nderebilmektedir. �rne�in, stok seviyesi belirli bir e�i�in alt�na d��t���nde, yetki verilen      personel sat�n alma birimine uyar� emaili g�nderebilir.

�	�r�n Foto�raf Y�kleme: Yeni bir �r�n eklendi�inde, �r�nle birlikte foto�raf y�klenebilir. 

�	Web API: Proje, masa, sipari� gibi i�lemler i�in RESTful API i�ermektedir. API sistemin harici uygulamalar veya mobil cihazlarla entegrasyonunu				   kolayla�t�r�r.

�   Admin Dashboard: Y�netici aray�z�, AdminLTE temas� kullan�larak tasarlanm��t�r. Bu dashboard, y�neticilerin sistemdeki verileri izlemesi, raporlamas� ve       y�netmesi i�in modern ve kullan�c� dostu bir aray�z sunar.

�	HTML5, CSS3 ve JavaScript: Projenin kullan�c� aray�z� HTML5, CSS3 JavaScript ve BootStrap kullan�larak tasarlanm��t�r. Modern ve duyarl� bir web tasar�m�      sunulmu�tur.

�	MS SQL Server: Projede, veritaban� olarak Microsoft SQL Server kullan�lm��t�r. T�m veri i�lemleri ve saklama bu veritaban� �zerinde ger�ekle�tirilir.


KURULUM

Gerekli Yaz�l�mlar
�	.NET SDK 8.0
�	MS SQL Server (veya ba�ka bir ili�kisel veritaban�)
�	Visual Studio 2022 veya �zeri

Ad�mlar
1.	Proje Dosyalar�n� �ndirin: Projeyi bilgisayar�n�za indirin veya kopyalay�n.
2.	Veritaban�n� Yap�land�r�n: appsettings.json dosyas�ndaki ba�lant� dizesini (ConnectionString) kendi veritaban�n�za g�re g�ncelleyin.
3.	Veritaban� Migrasyonlar�n� Uygulay�n: Paket Y�neticisi Konsolu'nu a�arak komutlar� �al��t�r�n.
4.	Projeyi �al��t�r�n: Visual Studio'dan projeyi ba�lat�n.

Kullan�m
�	Kullan�c� Y�netimi: Proje, ASP.NET Identity kullanarak kullan�c�lar�n kaydolmas�n�, giri� yapmas�n� ve rollerle y�netilmesini sa�lar.
�	Masa Y�netimi: Kafedeki masalar API veya MVC �zerinden y�netilebilir. Masalara sipari�ler eklenebilir veya mevcut sipari�ler g�ncellenebilir.
�	Sipari� Y�netimi: Garsonlar, masalar i�in sipari� alabilir, �r�n ekleyebilir veya sipari�leri kapatabilir.
�	Stok Y�netimi: �r�nlerin stok seviyeleri takip edilir ve belirli bir seviyenin alt�na d��t���nde sat�n alma birimine email g�nderilebilinir.
�	Admin Dashboard: Y�netici paneli, AdminLTE temas� ile tasarlanm��t�r ve y�neticilerin verileri izlemesi, raporlamas� ve y�netmesi i�in modern bir kullan�c�    aray�z� sa�lar.

Proje Yap�s�
�	HotCatCafe.MVC: Uygulaman�n web katman�, MVC yap� ile kullan�c� aray�z�n� ve kontrolc�lerini i�erir.
�	HotCatCafe.Model: Uygulaman�n temel entity modelleri ve aray�zleri burada bulunur.
�	HotCatCafe.DAL: Veri eri�im katman�, veritaban� i�lemlerinin ger�ekle�tirildi�i yerdir. Entity Framework Core kullan�larak veri taban� i�lemleri yap�l�r.
�	HotCatCafe.BLL: �� servisleri, veritaban� eri�im katman�yla i� mant��� katman� aras�nda k�pr� g�revi g�r�r. Business logic burada yer al�r.
�	HotCatCafe.IOC: Uygulaman�n ba��ml�l�k y�netim katman�, ba��ml�l�klar� ay�rarak proje y�netimini kolayla�t�r�r.
�	HotCatCafe.Common: Projenin daha esnek olabilmesi i�in her bir katmanda ortak olarak kullan�lacak i�lemler/yap�lar bu katmanda yer almaktad�rlar.
�	HotCatCafe.API: Uygulaman�n API katman�, RESTful servisleri sunar ve d�� sistemlerle entegrasyon sa�lar.


GEL��T�RME S�REC�

Bu projeyi geli�tirmek i�in �u teknolojiler ve k�t�phaneler kullan�lm��t�r:
�	.NET 8
�	Entity Framework Core
�	ASP.NET Identity
�	Fluent Validation
�	Swagger (API dok�mantasyonu i�in)
�	HTML5, CSS3 ve JavaScript (Frontend tasar�m� i�in)
�	MS SQL Server (Veritaban� i�in)
�	7 katmandan meydana getirildi. 

- Model 

	- Model Katman� : Model katman� Data Access Layer katman�nda varl�klar� temsil eden Entity'leri bar�nd�ran katmand�r.
	- Interfaces : B�t�n classlara �nc�l�k eden �zellikleri bar�nd�r�r.
	- Base : Interface' den al�nan �zellikleri b�nyesine dahil eder.
	- Enums : Modellerde kullan�lan sabitleri temsil eder.

- DAL (Data Access Layer)

	- Veritaban�na ula��m katman�d�r. Veritaban� ile ilgili modeller, tasar�m desenleri vs gibi varl�klar bu katman i�erisinde kullan�lmaktad�r.
	- Context : Veritaban� modellerini temsil eder.
	- Configuration : Veritaban� modellerinin kurulum a�amas�nda alan isimlerinin �zellikleri, i�erisinde bulunmas�n� istedi�imiz verileri configure etmek i�in olu�turuldu.

- BLL (Business Logic Layer) 

	- �� mant��� katman� olarak kullan�ld�. Kullan�c�n�n istekte bulundu�u b�t�n i�lemler ilk olarak bu katman taraf�ndan kar��lan�yor. 
	- Repositories : 
		-- Abstracts : 
			--- Base Abstracts :
				IRepository : Bu interface b�t�n i�lemlere �nc�l�k edecek metotlar�n kurallar�n� bar�nd�rmaktad�r. Interface d��ar�dan bir T al�r. Bu interface e gelen T tipinde model set edilip b�t�n modellerde CRUD i�lemleri yap�ld�. 

				ITableSessionService(T) : Bu ve T tipinde t�revi servisler IRepository'de olu�turulan eylemleri b�nyesine al�r. IRepository'de olu�turulan kurallar�n haricinde spesifik eylemlerin kurallar� olu�turuldu. �rne�in TableSEssionService'de ger�ekle�tirildi�i gibi. (Bknz. TableSessionService)
  
		-- Concretes
			---BaseConcrete :
				BaseRepository : IRepository'den miras alarak eylemleri somut hale d�n��t�ren s�n�ft�r. D��ar�dan T al�r.

- UI (User Interface) 

	- G�r�nt�leme katman�n� temsil eder.
	- MVC projesi bu katman i�erisinde olu�turuldu.

- Common (Ortak Katman)
	
	- Projenin daha esnek olabilmesi i�in her bir katmanda ortak olarak kullan�lacak i�lemler/yap�lar bu katmanda yer almaktad�rlar.
	- ImageHelper: ��erisinde bulunan static metot vas�tas�yla d��ar�dan iletilen dosyan�n bir g�rsel olup olmad���n� kontrol edilmesini ard�ndan bu g�rselin projeye dahil edilmesini ger�ekle�tirir.
	- EmailHelper : ��erisinde bulunan static metot vas�tas�yla d��ar�dan iletilen parametreler ile mail g�nderen bir class.
	- ProductHelper : �r�n stoklar� kritik seviyeye ula�t��� zaman sat�nalma personeline mail g�nderen static class� bar�nd�r�r.

- IOC (Inversion of Control)
	
	- MVC projesindeki Program.cs class�nda yer alan ba��ml�l�klar�n y�netimini kolayla�t�rmak amac� ile olu�turuldu.
	- Ba��ml�l�klar� ayr� bir katmana alarak clean code mant��� ve ba��ml�l�klar�n y�netiminin kolayla�t�r�lmas� amac�yla olu�turuldu.

- API (Application Programming Interface)

	- Kullan�c� deneyimini artt�rmak amac�yla api ayr� bir katmanda olu�turuldu. 
	- Web api da kullan�c�n�n masalara �r�n ekleme silme ve g�ncelleme i�lemlerini ger�ekle�tirebilmesi eylemlerini bar�nd�r�r.
	- Burada yap�lan i�lemler BLL katman�ndan referans al�narak ger�ekle�ir.
	- Mobil veya ba�ka bir cihaz i�in api yaz�lmak istenirse ayr� bir katman olu�turarak projenin y�netimini mod�ler yap�s�n� bozmadan ayr� bir api eklenip kullan�ma sunulabilir.
	



