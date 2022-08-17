Asp.Net-WebForm projemde kullandığım xml web servisi. WebForm projesini çalıştırabilmek için bu servisi çalıştırmak gerekiyor.

Veri tabanında Kullanıcılar ve Personeller tabloları ve bu tablolar için ekleme , silme , güncelleme , listeleme ve verilen ıd'ye göre veri getirme işlemlerini yapan stored procedureler oluşturdum. Oluşturduğum sp'leri kullanarak veri tabanı işlemlerini AuthenticationManagerLibrary ve PersonelManagerLibrary DLL leri ile gerçekleştirdim. Bu DLL leri oluşturma sebebim başka bir projede de lazım olursa yeniden yazmadan kullanabilmek. Veri Tabanı bağlantı yolunu Proje4WebService içerisindeki config dosyasında verdim. Proje4WebService içerisinde oluşturduğum service1 web servisinde dll leri kullanarak gerekli metodları yazdım.

