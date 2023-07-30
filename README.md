# Proje Notlarý




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


### sorulacaklar
* validationdaki Isrequired içindeki isrequired durmalý mý amacý config te require true dan false olursa exception fýrlatýp hatýrlatmak
* abstractservice ve abstractrepositorylerdeki parçalamalar mantýklý mý 
