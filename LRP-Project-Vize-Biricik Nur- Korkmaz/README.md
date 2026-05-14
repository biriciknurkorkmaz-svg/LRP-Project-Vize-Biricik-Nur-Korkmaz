# LRP - Laboratuvar Yönetim ve Zimmet Sistemi

Bu proje, üniversite laboratuvarlarındaki bilgisayarların envanter takibini yapmak ve bu bilgisayarları öğrencilere zimmetlemek amacıyla geliştirilmiş bir Web API uygulamasıdır.

##  Projenin Amacı ve Özellikleri
- **Admin Paneli:** Laboratuvar ekleme, silme ve bilgisayar envanteri oluşturma.
- **Otomatik Demirbaş Kodu:** Laboratuvar adına göre otomatik `LAB1-PC-01` formatında kod üretimi.
- **Zimmet Sistemi:** Bilgisayarların öğrenci numarası üzerinden atanması.
- **Otomatik Hesap:** Bir öğrenciye bilgisayar atandığında, öğrenci için otomatik giriş hesabı oluşturulması.
- **Öğrenci Paneli:** Öğrencilerin kendi üzerlerine kayıtlı cihazları görüntüleyebilmesi.

## 🛠 Kullanılan Teknolojiler
- **Backend:** .NET 8.0 Web API
- **Veritabanı:** Entity Framework Core & SQLite
- **Frontend:** HTML5, CSS3, JavaScript (Fetch API) ve Bootstrap 5

##  Nasıl Çalıştırılır?

Projenin yerel bilgisayarınızda çalışması için aşağıdaki adımları takip edin:

1. **Projeyi Açın:** `LRPProject.sln` dosyasını Visual Studio 2022 ile açın.
2. **Bağımlılıkları Yükleyin:** Proje açıldığında NuGet paketlerinin otomatik yüklenmesini bekleyin.
3. **Uygulamayı Başlatın:** Visual Studio'nun üst kısmında bulunan yeşil **"Run" (Oynat)** butonuna veya klavyenizden `F5` tuşuna basın.
4. **Tarayıcı:** Uygulama başladığında otomatik olarak bir tarayıcı penceresi açılacaktır. Eğer açılmazsa, terminalde görünen `localhost` adresine gidin.
5. **Veritabanı:** Uygulama ilk kez çalıştığında `lrp.db` dosyası otomatik olarak oluşturulacaktır.

##  Giriş Bilgileri
- **Admin Kullanıcı Adı:** admin
- **Admin Şifre:** 123