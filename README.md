# **ShopFlow API**



ShopFlow API , ASP.NET Core 8 kullanılarak geliştirilmiş basit bir e-ticaret backend projesidir..



Bu proje sırasında katmanlı mimari, Entity Framework Core , JWT Authentication , FluentValidation ve AutoMapper gibi teknolojiler kullanılarak temel backend geliştirme konuları uygulanmıştır.



## **Kullanılan Teknolojiler**

•	ASP.NET Core 8

•	Entity Framework Core

•	SQL Server

•	JWT Authentication

•	BCrypt Password Hashing

•	AutoMappere

•	FluentValidation

•	Swagger



## **Proje Yapısı**

Proje aşağıdaki katmanlardan oluşmaktadır:



#### **ShopFlow.API**

API endpointleri , middleware yapıları ve uygulama yapılandırmaları bu katmanda yer alır.



#### **ShopFlow.Application**

İş kuralları , servisler , DTO’lar , validasyonlar ve arayüzler bu katmanda bulunur.



#### **ShopFlow.Domain**

Entity sınıfları bu katmanda yer alır.



#### **ShopFlow.Infrastructure**

Veritabanı işlemleri , DbContext yapısı ve repository implementasyonları bu katmanda bulunur.



## **Özellikleri**



#### **Ürün İşlemleri**

•	Ürün ekleme

•	Ürün listeleme

•	Ürün güncelleme

•	Ürün silme

•	Sayfalama (Pagination)



#### **Kullanıcı İşlemleri**

•	Kullanıcı kayıt olma

•	Kullanıcı giriş yapma



#### **Güvenlik**

•	JWT Authentication

•	Authorization

•	BCrypt ile şifre hashleme



#### **Kurulum**

1\.	Projeyi klonlayın.

Git clone REPOSITORY\_URL

2\.	Veritabanı bağlantı bilgisini appsettings.json dosyasına ekleyin.

3\.	Migrationları çalıştırın.

Update-Database

4\.	Uygulamayı başlatın

dotnet run



#### **API Testi**

API endpointleri Swagger üzerinden test edilebilir.

Swagger adresi:

https://localhost:{port}/swagger



#### **Geliştirme Sürecinde Kullanılan Konular**

•	Clean Architecture yaklaşımı

•	Repository Pattern

•	Dependency Injection

•	DTO kullanımı

•	Validation işlemleri

•	Global Exception Handling

•	Authentication ve Authorization

