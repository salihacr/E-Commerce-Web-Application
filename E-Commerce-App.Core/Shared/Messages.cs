namespace E_Commerce_App.Core.Shared
{
    public static class Messages
    {
        public const string REQUIRED_INPUT = "Bu alan boş bırakılamaz.";
        public static string RANGE_INPUT(string min, string max)
            => $"Bu alan {min} ile {max} arasında değer alabilir.";
    }
}
