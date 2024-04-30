using BechTech.Entity.Entities;

namespace BeckTech.Web.ResultMessages
{
    public static class Messages
    {
        public static class Article
        {
            public static string Add(string articleTitle)
            {
                return $"'{ articleTitle }' başlıklı makale başarılı şekilde eklendi.";
            }
            public static string Update(string articleTitle)
            {
                return $"'{articleTitle}' başlıklı makale başarılı şekilde güncellendi.";
            }
            public static string Delete(string articleTitle)
            {
                return $"'{articleTitle}' başlıklı makale başarılı şekilde silindi.";
            }
            public static string UndoDelete(string articleTitle)
            {
                return $"'{articleTitle}' başlıklı makale başarılı şekilde aktif edilmiştir.";
            }
        }

        public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"'{categoryName}' Kategori başarılı şekilde eklendi.";
            }
            public static string Update(string categoryName)
            {
                return $"'{categoryName}' Kategori  başarılı şekilde güncellendi.";
            }
            public static string Delete(string categoryName)
            {
                return $"'{categoryName}' Kategori  başarılı şekilde silindi.";
            }
            public static string UndoDelete(string articleTitle)
            {
                return $"'{articleTitle}' Kategori başarılı şekilde aktif edilmiştir.";
            }
        }

        public static class User
        {
            public static string Add(string userName)
            {
                return $"'{userName}' email adresli kullanıcı başarılı şekilde eklendi.";
            }
            public static string Update(string userName)
            {
                return $"'{userName}'email adresli kullanıcı başarılı şekilde güncellendi.";
            }
            public static string Delete(string userName)
            {
                return $"'{userName}'email adresli kullanıcı başarılı şekilde silindi.";
            }
            public static string UndoDelete(string articleTitle)
            {
                return $"'{articleTitle}' 'email adresli kullanıcı başarılı şekilde aktif edilmiştir.";
            }
        }

        public static class Contact
        {
            public static string Add()
            {
                return " Mesajınız başarılı şekilde gönderilmiştir.";
            }
            public static string Delete(string nameSurname)
            {
                return $"'{nameSurname}'email adresli kullanıcının mesajı başarılı şekilde silindi.";
            }
           
        }
    }
    
}
