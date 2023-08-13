# Proje Notlar�


fluent validation attribute oluyor



blog ve di�erlerindeki d�n��lerde sayfalama ekle. 
�oklu s�n�f yap�s�na bak yani actionlara yanlar�na PagenatiopnModel gibi ekleme olur mu bak


basede authorize ekledin onun configlerini ayarla test et sonra sikir git FE yap aray�z yok elde

### Notlar

* dotnet ef migrations add 1_test_mig -> migleme
* dotnet ef database update -> push db
* <del>min pool size 0 olmamal� hata veriyor nedene bakars�n</del>
* IsRequired lar galiba zaten true onlar� klad�r olmad� �imdilik garanti i�in kals�n

### Yap�lacaklar

* entitler doldurulacaklar.
* entitlere configleri haz�rla ve index hasdata totable gibi �eyleri detayl�ca haz�rla
* <del> Idler guid oalcak </del>
* kategory - user - userstatus - blog - ekle ek olarak t�klama say�s� fantazi  istersek apriori algosu filan eklenebilir.
* az �z fonsiyon olmal�
* admin i�in post ekleme sayfas�
* mvvm kullanmaya �al��
* postgresql vs sql server farklar�n� ara�t�r
* dok�manlarda ef core ile ilgili ara�t�rmalar� yap
* gen�ay�n videolar� bak
* JWT k�sm�n� d���n
* DB i�in kontrolleri yap ve s�rekli geli�tirme haz�rla oras� en dertli yer
* fluent validation yap attributeleri turkcell kullanm�yor oraya uyum sa�lamal�s�n. Attribute ikna ettin ama fluent olmal� kullanrak yapman laz�m ben mimar de�ilim. Hen�z :D
* react js dal�nacak fakat �nce BE sonra komple FE girilecek ve t�k�r�len yalanacak 
* t�klamalarda istatistik kullan�labbilir �u ilden �u ya�tan �u kadar giri� gibi sonra olur bu
* blog eklemede resim ekleme, belirli tarihte ekleme, yaz� tipi ayarlamalar�, gibi wordpress �eyleri yap hatta wordpress ile yap�lan blog sitesi gibi admin edit�r ve kullan�c� k�sm� yap.
* bloglarda IsRequired zaten true mu� onlara bak sonarcube de hata vermese bile git test et olmad� kald�r gereksiz kod
* postgresql in i�inde bir s�r� farkl�l�klar var sql server a g�re bak sonra ona g�re optimize et 
* bloglarda publicationDate i�in kontrol ekle i�te vakti gelince yay�nlas�n ama buras� nas�l olacak hangfire yapar m� bilemedinm.
* db de userid gibi �eyleri ef kendi ayarl�yor onlar� ilerde kald�r �imdi kar��acak kals�n
* yorumlar�da recursive yap yoruma yorum yaps�nlar
* baz� yerlerde view eklebilir
* BlogTag i�in ol ara sistemde Core lar ile �al���lmas� laz�m bak�n
* servislere sonradan mail servisi eklemeyi dene
* CQRS yap�s� eklemeyi deneyebilrisin
* <del> �zel IServicelerde IActionresult d�n kalanlar�n� oradan kullan. </del>
* <del> servisler httpstatus d�necek </del>
* jwt xecurity olan �al��mad� h�z i�in vazge�tim onu d�zelt securty yap
* 



### sorulacaklar
* validationdaki Isrequired i�indeki isrequired durmal� m� amac� config te require true dan false olursa exception f�rlat�p hat�rlatmak. config ve validation aras�nda constant i�inden ba� kurmak
* abstractservice ve abstractrepositorylerdeki par�alamalar mant�kl� m� cevap al�nd� yo�urt yi�i�
* take hatas� sebebi nedir. _getallda g�ster hepsi dolu iken veriyor hatay� kaydetmeyi unuttum sadece sor hata exept etmek uzun s�rebilir
* user tablosunda emaili de key yaparak herkesin farkl� email e sahip olmas� garantilenecek ama baseden gelen Id sonras� hata veriyor. birle�tirme yolu var m� (galiba yok sor yinede)
* bu jwt token� program.cs i�inde tan�mlad�ktan sonra oradaki ayarlarla nas�l kullanaca��z nette s�zg�n bir sonu� bulamad�m herkes iki kere jwt token �retici yapm��
* bu apiye istek geldik�e ram �i�iyor nas�l d�zelticem anlamad�m ve bulamad�m. Idispose ekledim her yerede �ok i�e yaramad� sonras�nda birazc�k ram d���yor ama 10 mb �i�ti ise 1 mb d���yor kullan�lmay�nca fark yok gibi
* react i�inde (react� gpt ile ��rendim bir d�k�man yada e�itim izlemedim) sayfalamada yada dosyalamada k�saca mimaride nas�l bir yap� kullan�yorsunuz proje �zerinden g�sterebilir misniz? akl�mda olsun
* controllerlarda frombody ile get methodunu almak i�in js de y�ntem bulamad�m postmende oluyordu fetch ile al�rken direk get isteklerinde body g�nderilmez diyor. gpt ile tart��t�m sa�l�kl� de�il diyor mesela son x adet blog yaz�s� getir derken ben bu x adeti body i�inde json ile g�ndermek istiyorum ki validation i�lemleri kolay olsun methodu post yapsam ��zerim ama get y�ntemi bunu direk d�z param ile mi ��zece�iz bana mant�kl� gelmedi siz nas�l yap�yorsunuz.
* reactta token� nas�l sakl�yorsunuz ayr�ca kullan�c� do�rulama i�in kulland���n�z jwt d��� y�ntem varsa nedir g�sterir misiniz
* sayfalamy� nas�l yap�yorsunuz. benim y�ntem olur mu
* isteklerde order filter gibi istekleri nas�l veriyorsunuz hepsine �zel controller m� var yoksa bir controller i�inden birdern fazla se�enek mi var
* g�venlik i�in sql injection d���nda taavsiyeniz var m�
* .net i�in tavsiye k�t�phane veya program.cs de �unlar� kullan dedi�iniz var m�
* son olarak iyi yaz�l�mc� vs i�in de�ilde direk �unlar� bilmen seni �ne ta��r veya �u teknolojiler ilerde bask�n olabilir ��ren dedi�iniz veya �uanki akl�n�zla ge�mi�inize tavsiye verseniz ne derdiniz yani benim durumumdakilere genel tavsiye ne derdiniz her �ey olabilir sall�yom di�lerini d�zenli f�r�ala ilerde a�r�yor gibide olur
* anlay���n�z ve iyi niyetiniz i�in te�ekk�rler


### FrontEnd

* <del>link y�nlendirmelerinde hata yapt�m. sha256 yap�p g�venli olaca��n� d���nd�m ama sayfa de�i�iminde veri g�nderiminde zorluk ya�ad�m d�zeltiriz in�allah</del>
* 


