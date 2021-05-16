namespace E_Commerce_App.Core.Shared
{
    public static class Messages
    {
        public const string REQUIRED_INPUT = "Bu alan boş bırakılamaz.";
        public static string RANGE_INPUT(string min, string max)
            => $"Bu alan {min} ile {max} arasında değer alabilir.";


        public static string JSON_CREATE_MESSAGE(string type, bool state = true)
        {
            if (state == true) return $"{type} başarıyla oluşturuldu.";
            else return $"{type} oluşturulurken hata gerçekleşti.";
        }
        public static string JSON_REMOVE_MESSAGE(string type, bool state = true)
        {
            if (state == true) return $"{type} başarıyla silindi.";
            else return $"{type} silinirken hata gerçekleşti.";
        }

        public static string EMAIL_CONFIRM_MESSAGE()
        {
            return "";
        }


    }
}
