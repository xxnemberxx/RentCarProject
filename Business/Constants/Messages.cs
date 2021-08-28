using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
		internal static string Added => "Added";
		internal static string Deleted => "Deleted";
		internal static string Updated => "Updated";
		internal static string Unknown => "Unknown";
		internal static string SelectedList => "SelectedList";
		internal static string Selected => "SelectedItem";

        public static string UserRegistered { get; internal set; }
        public static User UserNotFound { get; internal set; }
        public static User PasswordError { get; internal set; }
        public static string SuccessfulLogin { get; internal set; }
        public static string UserAlreadyExists { get; internal set; }
        public static string AccessTokenCreated { get; internal set; }

        internal static string ContentTypeOfImageNotSupport = "Hatalı dosya türü!";
        internal static string ThereIsNotImageOfTheVehicle = "Araca ait resim bulunmamaktadır!";
        internal static string VehicleImagesExceededTheUploadLimit = "Araç için belirtilmiş olan yükleme sınırını aştınız!";
        internal static string AuthorizationDenied = "Bu işlemi yapmak için yetkiniz bulunmamaktadır!";
        internal static string NotImage = "Resim bulunamadı!";
    }
}
