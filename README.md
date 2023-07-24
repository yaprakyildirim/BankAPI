# Banka API Uygulaması
Bu proje, kullanıcı oturum yönetimi ve ödeme bilgilerini formatlı bir şekilde döndürme özellikleri sunan bir banka uygulamasını temsil eden bir API'dir.


# İçerikler
1. Kullanılan Teknolojiler
2. Özellikler
3. Başlangıç


# Kullanılan Teknolojiler
- .NET 6.0: Bu projede ana çerçeve olarak .NET 6.0 kullanılmıştır.
- Swagger: API dokümantasyonu ve testi için Swagger kullanılmıştır.
- ASP.NET Core MVC: API'nin temel yapısı için kullanılmıştır.


# Özellikler
Kullanıcı Oturum Yönetimi: Kullanıcılar oturum açabilir ve yetkilendirme kontrolü gerçekleştirilebilir.
Ödeme Bilgisi Formatlama: Belirli bir ödeme miktarını belirli bir para birimi formatında döndürebilirsiniz.
Middleware Kullanımı: Global hata yakalama ve gelen HTTP isteğini loglama işlemleri için middleware kullanılmıştır.
Öznitelik Bazlı Yetkilendirme: Kullanıcının yetkilendirilip yetkilendirilmediğini kontrol etmek için özel bir öznitelik oluşturulmuştur.

# Detaylar

# Servisler (Services):

- IUserService: Kullanıcıların oturum açmasını sağlamak için bir hizmet tanımlar.
- FakeUserService: IUserService'in sahte bir uygulamasıdır. Kullanıcı adı "admin" ve şifre "password123" ise yetkilendirme başarılı kabul edilir.
- IPaymentService: Bir ödeme miktarını formatlı bir şekilde döndürmek için bir hizmet tanımlar.
- Extensions:

# DecimalExtensions: 
Decimal türündeki bir miktarı para birimi formatına dönüştüren bir uzantı metodu içerir.

# HttpRequestExtensions: 
HTTP isteğinin gövdesini bir dize olarak döndüren bir uzantı metodu sağlar.


# Middleware:
- LogMiddleware: Gelen her HTTP isteğini konsola loglar.
- GlobalExceptionMiddleware: Global hata yakalama için kullanılır. Bir hata yakalandığında, kullanıcıya genel bir hata mesajı döner.
- 

# Attributes
- FakeAuthAttribute: Basit bir yetkilendirme kontrolü sağlamak amacıyla kullanılan bir özniteliktir. Kullanıcının yetkilendirilip yetkilendirilmediğini kontrol eder.

# BankController: 
İki temel işlevi bulunmaktadır:
1- Kullanıcı oturumunu açmak için bir HTTP GET isteği kabul eder.
2- Formatlı ödeme bilgisi döndürmek için bir HTTP GET isteği kabul eder.


# API Dokümantasyonu:
Swagger kullanılarak oluşturulmuştur. Bu sayede API'nin tüm endpointleri hakkında dokümantasyon ve test imkanı sunulmuştur.

# Startup Ayarları (Program.cs):
Uygulama başlatıldığında kullanılacak servislerin tanımlandığı, middleware'lerin ve diğer konfigürasyonların ayarlandığı bölümdür.
