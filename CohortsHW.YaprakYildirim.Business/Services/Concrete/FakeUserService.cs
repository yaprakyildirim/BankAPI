using CohortsHW.YaprakYildirim.Business.Services.Abstract;

namespace CohortsHW.YaprakYildirim.Business.Services.Concrete
{
    /// FakeUserService, kullanıcı hizmetlerinin fake (dummy) bir implementasyonudur.
    /// Bu sınıf, gerçek bir veritabanı veya dış servis kullanmadan basit kullanıcı yetkilendirmesi sağlar.
    public class FakeUserService : IUserService
    {
        public bool Login(string username, string password) => username == "admin" && password == "password123";



    }
}
