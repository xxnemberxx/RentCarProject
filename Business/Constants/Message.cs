using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Message
    {
		internal static string Added => "Added";
		internal static string Deleted => "Deleted";
		internal static string Updated => "Updated";
		internal static string Unknown => "Unknown";
		internal static string SelectedList => "SelectedList";
		internal static string Selected => "SelectedItem";
        internal static string ContentTypeOfImageNotSupport = "Hatalı dosya türü!";
        internal static string ThereIsNotImageOfTheVehicle = "Araca ait resim bulunmamaktadır!";
        internal static string VehicleImagesExceededTheUploadLimit = "Araç için belirtilmiş olan yükleme sınırını aştınız!";
        internal static string AuthorizationDenied = "Bu işlemi yapmak için yetkiniz bulunmamaktadır!";
        internal static string NotImage = "Resim bulunamadı!";
    }
}
