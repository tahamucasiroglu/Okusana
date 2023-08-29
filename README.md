# Proje Notları


fluent validation attribute oluyor



blog ve diğerlerindeki dönüşlerde sayfalama ekle. 
Çoklu sınıf yapısına bak yani actionlara yanlarına PagenatiopnModel gibi ekleme olur mu bak


basede authorize ekledin onun configlerini ayarla test et sonra git FE yap arayüz yok elde

### Notlar

* dotnet ef migrations add 1_test_mig -> migleme
* dotnet ef database update -> push db
* <del>min pool size 0 olmamalı hata veriyor nedene bakarsın</del>
* IsRequired lar galiba zaten true onları kladır olmadı şimdilik garanti için kalsın

### Yapılacaklar

* entitler doldurulacaklar.
* entitlere configleri hazırla ve index hasdata totable gibi şeyleri detaylıca hazırla
* <del> Idler guid oalcak </del>
* kategory - user - userstatus - blog - ekle ek olarak tıklama sayısı fantazi  istersek apriori algosu filan eklenebilir.
* az öz fonsiyon olmalı
* admin için post ekleme sayfası
* mvvm kullanmaya çalış
* postgresql vs sql server farklarını araştır
* dokğmanlarda ef core ile ilgili araştırmaları yap
* gençayın videoları bak
* JWT kısmını düşün
* DB için kontrolleri yap ve sürekli geliştirme hazırla orası en dertli yer
* fluent validation yap attributeleri turkcell kullanmıyor oraya uyum sağlamalısın. Attribute ikna ettin ama fluent olmalı kullanrak yapman lazım ben mimar değilim. Henüz :D
* react js dalınacak fakat önce BE sonra komple FE girilecek ve tükürülen yalanacak 
* tıklamalarda istatistik kullanılabbilir şu ilden şu yaştan şu kadar giriş gibi sonra olur bu
* blog eklemede resim ekleme, belirli tarihte ekleme, yazı tipi ayarlamaları, gibi wordpress şeyleri yap hatta wordpress ile yapılan blog sitesi gibi admin editör ve kullanıcı kısmı yap.
* bloglarda IsRequired zaten true muş onlara bak sonarcube de hata vermese bile git test et olmadı kaldır gereksiz kod
* postgresql in içinde bir sürü farklılıklar var sql server a göre bak sonra ona göre optimize et 
* bloglarda publicationDate için kontrol ekle işte vakti gelince yayınlasın ama burası nasıl olacak hangfire yapar mı bilemedinm.
* db de userid gibi şeyleri ef kendi ayarlıyor onları ilerde kaldır şimdi karışacak kalsın
* yorumlarıda recursive yap yoruma yorum yapsınlar
* bazı yerlerde view eklebilir
* BlogTag için ol ara sistemde Core lar ile çalışılması lazım bakın
* servislere sonradan mail servisi eklemeyi dene
* CQRS yapısı eklemeyi deneyebilrisin
* <del> özel IServicelerde IActionresult dön kalanlarını oradan kullan. </del>
* <del> servisler httpstatus dönecek </del>
* jwt xecurity olan çalışmadı hız için vazgeçtim onu düzelt securty yap
* 



### sorulacaklar
* validationdaki Isrequired içindeki isrequired durmalı mı amacı config te require true dan false olursa exception fırlatıp hatırlatmak. config ve validation arasında constant içinden bağ kurmak
* abstractservice ve abstractrepositorylerdeki parçalamalar mantıklı mı cevap alındı yoğurt yiğiş
* take hatası sebebi nedir. _getallda göster hepsi dolu iken veriyor hatayı kaydetmeyi unuttum sadece sor hata exept etmek uzun sürebilir
* user tablosunda emaili de key yaparak herkesin farklı email e sahip olması garantilenecek ama baseden gelen Id sonrası hata veriyor. birleştirme yolu var mı (galiba yok sor yinede)
* bu jwt tokenı program.cs içinde tanımladıktan sonra oradaki ayarlarla nasıl kullanacağız nette süzgün bir sonuç bulamadım herkes iki kere jwt token üretici yapmış
* bu apiye istek geldikçe ram şişiyor nasıl düzelticem anlamadım ve bulamadım. Idispose ekledim her yerede çok işe yaramadı sonrasında birazcık ram düşüyor ama 10 mb şişti ise 1 mb düşüyor kullanılmayınca fark yok gibi
* react içinde (reactı gpt ile öğrendim bir döküman yada eğitim izlemedim) sayfalamada yada dosyalamada kısaca mimaride nasıl bir yapı kullanıyorsunuz proje üzerinden gösterebilir misniz? aklımda olsun
* controllerlarda frombody ile get methodunu almak için js de yöntem bulamadım postmende oluyordu fetch ile alırken direk get isteklerinde body gönderilmez diyor. gpt ile tartıştım sağlıklı değil diyor mesela son x adet blog yazısı getir derken ben bu x adeti body içinde json ile göndermek istiyorum ki validation işlemleri kolay olsun methodu post yapsam çözerim ama get yöntemi bunu direk düz param ile mi çözeceğiz bana mantıklı gelmedi siz nasıl yapıyorsunuz.
* reactta tokenı nasıl saklıyorsunuz ayrıca kullanıcı doğrulama için kullandığınız jwt dışı yöntem varsa nedir gösterir misiniz
* sayfalamyı nasıl yapıyorsunuz. benim yöntem olur mu
* isteklerde order filter gibi istekleri nasıl veriyorsunuz hepsine özel controller mı var yoksa bir controller içinden birdern fazla seçenek mi var
* güvenlik için sql injection dışında taavsiyeniz var mı
* .net için tavsiye kütüphane veya program.cs de şunları kullan dediğiniz var mı
* son olarak iyi yazılımcı vs için değilde direk şunları bilmen seni öne taşır veya şu teknolojiler ilerde baskın olabilir öğren dediğiniz veya şuanki aklınızla geçmişinize tavsiye verseniz ne derdiniz yani benim durumumdakilere genel tavsiye ne derdiniz her şey olabilir sallıyom dişlerini düzenli fırçala ilerde ağrıyor gibide olur
* anlayışınız ve iyi niyetiniz için teşekkürler


### FrontEnd

* <del>link yönlendirmelerinde hata yaptım. sha256 yapıp güvenli olacağını düşündüm ama sayfa değişiminde veri gönderiminde zorluk yaşadım düzeltiriz inşallah</del>
* 


