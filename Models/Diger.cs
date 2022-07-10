namespace OrnekProje.Models
{
    public static class Diger //Rol ile ilgili işlemleri,sipariş durumu ile ilgili işlemler,session ile ilgili işlemleri burada yapacaz.
    {
        public const string Role_Birey = "Birey"; //facebook ve google ile giris yapanların rolu
        public const string Role_Admin = "Admin"; 
        public const string Role_User = "User";

        public const string ssShoppingCart = "Shopping Cart Session";

        public const string Durum_Onaylandı = "Onaylandı";
        public const string Durum_Beklemede = "Beklemede";
        public const string Durum_Kargoda= "Kargoya Verildi";

    }
}
