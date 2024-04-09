
## BEM Case Study 
Bu repo, Bem Case Study çözümünü içermektedir.


## Kullanılan Teknolojiler

**.Net 7, MSSql**

  ## Projeler

Proje, `app` ve `core` olmak üzere iki ana dizine ayrılmıştır.

### App

Bu dizin, uygulamanın çalışma zamanıyla ilgili projeleri içerir.

- `BemCase.Web`: Uygulamanın giriş noktası olan bu proje, dış dünya ile iletişim kurmak için MVC projesi içerir. Viewlar içerisinde actionlar ile asenkron haberleşme için AJAX kullanılmıştır.
Minimal seviyede Bootstrap framework yardımı ile bir UI sağlanmıştır.

- `BemCase.Application`: İş mantığını barındıran bu katman, Web ve veritabanı arasında köprü görevi görür.

- `BemCase.Domain`: Uygulamanın iş kurallarını ve nesne modellerini içerir. Veritabanı ile etkileşimde bulunmak için gereken entity'leri tanımlar.

- `BemCase.Persistence`: Veritabanı işlemleri için gerekli olan konfigürasyon ve erişim mekanizmalarını içerir. Hangfire ve Entity Framework Core MSSQL ile veritabanı işlemlerini yönetir.

### Core

Bu dizin, genel amaçlı, uygulama genelinde kullanılabilen yardımcı kütüphaneleri ve servisleri içerir.

- `Core.Application`: Tüm uygulama boyunca kullanılacak ortak servisler ve iş mantığı için bir temel sağlar.
MediatR ve FluentValidation gibi bağımlılıklar kullanarak iş mantığı işlemlerini yürütür.

- `Core.CrossCuttingConcerns`: Kesişen işleri (logging, validation, exception vs.) yönetmek için kullanılan yapıları içerir.
Serilog ve FluentValidation ile kesişen işleri yönetir. (Loglama MSSQL'e, ApplicationLogs tablosuna kaydedilir)

- `Core.Persistence`: Uygulamanın veritabanı erişim katmanlarında kullanılacak ortak mekanizmaları ve
veritabanı erişim katmanları için genel mekanizmaları içerir.

## Kurulum

VERİTABANLARI KULLANMAK İÇİN BİLGİSAYARINIZDA DOCKER KURULU OLMALIDIR.
Appsettings'de mssql localdb ayarları yapılmıştır. Bunun dışında bir server yapılandırması için comment olarak bir connection string daha bırakılmıştır. Kendi server ayarlarınızı yaparak uygulamayı dbye bağlayabilirsiniz.

## DB Migration

Migration klasörü önemlidir. Geliştirmeler boyunca attığım tüm migration'lar burada barındırılır. Program.cs içerisinde DbPopulation sınıfı yardımı ile migraton atılmış ayarların hepsi proje çalıştırıldığında migration yapacak ve tanımlanan entityler db'ye yansıyacaktır.


## Genel bilgiler

- Fluent validation ile validation işlemleri.
- Mediator ile CQRS pattern uygulaması.
- Serilog & MSSQL ile loglama yapılması.
- Exception middleware aracılığı ile exception yönetimi yapılması.
- Efektif EntityframeworkCore kullanılması.
- AutoMapper ile mapping işlemlerinin yapılması.
- Hangfire ile zamanlanmış görev tanımlaması.


ve daha fazlası uygulamada sağlanmıştır.