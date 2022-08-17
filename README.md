Asp.Net-WebForm projemde kullandığım xml web servisi. WebForm projesini çalıştırabilmek için bu servisi çalıştırmak gerekiyor.

# WebService-WebForm
![image](https://user-images.githubusercontent.com/96024765/185206666-d6ce93b0-4e25-4df2-8b87-6b1cad409694.png)       
Veri tabanında Kullanıcılar ve Personeller tabloları ve bu tablolar için ekleme , silme , güncelleme , listeleme ve verilen ıd'ye göre veri getirme işlemlerini yapan stored procedureler oluşturdum. Oluşturduğum sp'leri kullanarak veri tabanı işlemlerini AuthenticationManagerLibrary ve PersonelManagerLibrary DLL leri ile gerçekleştirdim. Bu DLL leri oluşturma sebebim başka bir projede de lazım olursa yeniden yazmadan kullanabilmek. Veri Tabanı bağlantı yolunu Proje4WebService içerisindeki config dosyasında verdim. Proje4WebService içerisinde oluşturduğum service1 web servisinde dll leri kullanarak gerekli metodları yazdım.

# Projenin Çalıştırılması

[TSQL1.txt](https://github.com/ziyacanyldz/WebService-Webform/files/9365010/TSQL1.txt) Bu dosyadaki tsql kodlarını kendi sql serverinizde 
