# Proje Notlarý


fluent validation attribute oluyor



blog ve diðerlerindeki dönüþlerde sayfalama ekle. 
Çoklu sýnýf yapýsýna bak yani actionlara yanlarýna PagenatiopnModel gibi ekleme olur mu bak


basede authorize ekledin onun configlerini ayarla test et sonra sikir git FE yap arayüz yok elde

### Notlar

* dotnet ef migrations add 1_test_mig -> migleme
* dotnet ef database update -> push db
* <del>min pool size 0 olmamalý hata veriyor nedene bakarsýn</del>
* IsRequired lar galiba zaten true onlarý kladýr olmadý þimdilik garanti için kalsýn

### Yapýlacaklar

* entitler doldurulacaklar.
* entitlere configleri hazýrla ve index hasdata totable gibi þeyleri detaylýca hazýrla
* <del> Idler guid oalcak </del>
* kategory - user - userstatus - blog - ekle ek olarak týklama sayýsý fantazi  istersek apriori algosu filan eklenebilir.
* az öz fonsiyon olmalý
* admin için post ekleme sayfasý
* mvvm kullanmaya çalýþ
* postgresql vs sql server farklarýný araþtýr
* dokðmanlarda ef core ile ilgili araþtýrmalarý yap
* gençayýn videolarý bak
* JWT kýsmýný düþün
* DB için kontrolleri yap ve sürekli geliþtirme hazýrla orasý en dertli yer
* fluent validation yap attributeleri turkcell kullanmýyor oraya uyum saðlamalýsýn. Attribute ikna ettin ama fluent olmalý kullanrak yapman lazým ben mimar deðilim. Henüz :D
* react js dalýnacak fakat önce BE sonra komple FE girilecek ve tükürülen yalanacak 
* týklamalarda istatistik kullanýlabbilir þu ilden þu yaþtan þu kadar giriþ gibi sonra olur bu
* blog eklemede resim ekleme, belirli tarihte ekleme, yazý tipi ayarlamalarý, gibi wordpress þeyleri yap hatta wordpress ile yapýlan blog sitesi gibi admin editör ve kullanýcý kýsmý yap.
* bloglarda IsRequired zaten true muþ onlara bak sonarcube de hata vermese bile git test et olmadý kaldýr gereksiz kod
* postgresql in içinde bir sürü farklýlýklar var sql server a göre bak sonra ona göre optimize et 
* bloglarda publicationDate için kontrol ekle iþte vakti gelince yayýnlasýn ama burasý nasýl olacak hangfire yapar mý bilemedinm.
* db de userid gibi þeyleri ef kendi ayarlýyor onlarý ilerde kaldýr þimdi karýþacak kalsýn
* yorumlarýda recursive yap yoruma yorum yapsýnlar
* bazý yerlerde view eklebilir
* BlogTag için ol ara sistemde Core lar ile çalýþýlmasý lazým bakýn
* servislere sonradan mail servisi eklemeyi dene
* CQRS yapýsý eklemeyi deneyebilrisin
* <del> özel IServicelerde IActionresult dön kalanlarýný oradan kullan. </del>
* <del> servisler httpstatus dönecek </del>
* jwt xecurity olan çalýþmadý hýz için vazgeçtim onu düzelt securty yap
* 



### sorulacaklar
* validationdaki Isrequired içindeki isrequired durmalý mý amacý config te require true dan false olursa exception fýrlatýp hatýrlatmak. config ve validation arasýnda constant içinden bað kurmak
* abstractservice ve abstractrepositorylerdeki parçalamalar mantýklý mý cevap alýndý yoðurt yiðiþ
* take hatasý sebebi nedir. _getallda göster hepsi dolu iken veriyor hatayý kaydetmeyi unuttum sadece sor hata exept etmek uzun sürebilir
* user tablosunda emaili de key yaparak herkesin farklý email e sahip olmasý garantilenecek ama baseden gelen Id sonrasý hata veriyor. birleþtirme yolu var mý (galiba yok sor yinede)
* bu jwt tokený program.cs içinde tanýmladýktan sonra oradaki ayarlarla nasýl kullanacaðýz nette süzgün bir sonuç bulamadým herkes iki kere jwt token üretici yapmýþ
* bu apiye istek geldikçe ram þiþiyor nasýl düzelticem anlamadým ve bulamadým. Idispose ekledim her yerede çok iþe yaramadý sonrasýnda birazcýk ram düþüyor ama 10 mb þiþti ise 1 mb düþüyor kullanýlmayýnca fark yok gibi
* react içinde (reactý gpt ile öðrendim bir döküman yada eðitim izlemedim) sayfalamada yada dosyalamada kýsaca mimaride nasýl bir yapý kullanýyorsunuz proje üzerinden gösterebilir misniz? aklýmda olsun
* controllerlarda frombody ile get methodunu almak için js de yöntem bulamadým postmende oluyordu fetch ile alýrken direk get isteklerinde body gönderilmez diyor. gpt ile tartýþtým saðlýklý deðil diyor mesela son x adet blog yazýsý getir derken ben bu x adeti body içinde json ile göndermek istiyorum ki validation iþlemleri kolay olsun methodu post yapsam çözerim ama get yöntemi bunu direk düz param ile mi çözeceðiz bana mantýklý gelmedi siz nasýl yapýyorsunuz.
* reactta tokený nasýl saklýyorsunuz ayrýca kullanýcý doðrulama için kullandýðýnýz jwt dýþý yöntem varsa nedir gösterir misiniz
* sayfalamyý nasýl yapýyorsunuz. benim yöntem olur mu
* isteklerde order filter gibi istekleri nasýl veriyorsunuz hepsine özel controller mý var yoksa bir controller içinden birdern fazla seçenek mi var
* güvenlik için sql injection dýþýnda taavsiyeniz var mý
* .net için tavsiye kütüphane veya program.cs de þunlarý kullan dediðiniz var mý
* son olarak iyi yazýlýmcý vs için deðilde direk þunlarý bilmen seni öne taþýr veya þu teknolojiler ilerde baskýn olabilir öðren dediðiniz veya þuanki aklýnýzla geçmiþinize tavsiye verseniz ne derdiniz yani benim durumumdakilere genel tavsiye ne derdiniz her þey olabilir sallýyom diþlerini düzenli fýrçala ilerde aðrýyor gibide olur
* anlayýþýnýz ve iyi niyetiniz için teþekkürler


### FrontEnd

* <del>link yönlendirmelerinde hata yaptým. sha256 yapýp güvenli olacaðýný düþündüm ama sayfa deðiþiminde veri gönderiminde zorluk yaþadým düzeltiriz inþallah</del>
* 


