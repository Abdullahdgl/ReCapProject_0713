using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.Constants
{
	public class Messages
	{
        //Kullanıcı mesajları
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserListed = "Kullanıcılar listelendi.";

        //Müşteri mesajları
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerListed = "Müşteriler listelendi.";

        //Araçlar için hazır mesajlar
        public static string CarAdded = "Araç eklendi.";
        public static string CarDeleted = "Araç silindi.";
        public static string CarUpdated = "Araç güncellendi.";
        public static string CarListed = "Araç listelendi.";
        public static string CarValueInvalid = "Araç açıklaması en az 2 harf içermeli ve ücreti 0 dan büyük olmalıdır";
        //Boyalar için hazır mesajlar
        public static string ColorAdded = "Boya eklendi.";
        public static string ColorDeleted = "Boya silindi.";
        public static string ColorUpdated = "Boya güncelendi.";
        public static string ColorListed = "Boyalar listelendi.";
        //Markalar  için hazır mesajlar
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncelendi.";
        public static string BrandListed = "Markalar listelendi.";
        public static string MaintenanceTime = "Sunucu bakımda";
        public static string BrandError = "Markada bir hata var";

        //Kiralama işlem mesajları
        public static string RentalAdded = "Araç kiralama başarılı.";
        public static string RentalDeleted = "Kiralama bilgileri silindi.";
        public static string RentalUpdated = "Kiralama işlemi güncellendi.";
        public static string RentalValueInvalid = "Araç şuan başka bir kullanıcıya tanımlı kirala işlemi başarısız.";
        public static string RentalListed = "Kiralama işlemleri listelendi";



    }
}
