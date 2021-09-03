using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
		public static string Added => "Added";
        public static string Deleted => "Deleted";
        public static string Updated => "Updated";
        public static string Unknown => "Unknown";
        public static string SelectedList => "SelectedList";
        public static string Selected => "SelectedItem";

        public static string UserRegistered = "Başarıyla kayıt olundu";
        public static string UserNotFound = "Böyle bir kullanıcı mevcut değildir";
        public static string PasswordError = "Şifremiz hatalı";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı";
        public static string UserAlreadyExists = "Bu kullanıcı adı zaten bulunmakta";
        public static string AccessTokenCreated = "Access token oluşturuldu";

        public static string ContentTypeOfImageNotSupport = "Hatalı dosya türü!";
        public static string ThereIsNotImageOfTheVehicle = "Araca ait resim bulunmamaktadır!";
        public static string VehicleImagesExceededTheUploadLimit = "Araç için belirtilmiş olan yükleme sınırını aştınız!";
        public static string AuthorizationDenied = "Bu işlemi yapmak için yetkiniz bulunmamaktadır!";
        public static string NotImage = "Resim bulunamadı!";
    }
}
