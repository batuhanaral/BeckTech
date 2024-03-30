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
        }

        public static class Category
        {
            public static string Add(string categoryName)
            {
                return $"'{categoryName}' Kategori başarılı şekilde eklendi.";
            }
            public static string Update(string categoryName)
            {
                return $"'{categoryName}' Kategori makale başarılı şekilde güncellendi.";
            }
            public static string Delete(string categoryName)
            {
                return $"'{categoryName}' Kategori makale başarılı şekilde silindi.";
            }
        }
    }
    
}
