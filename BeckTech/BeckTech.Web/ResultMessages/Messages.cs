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
    }
    
}
