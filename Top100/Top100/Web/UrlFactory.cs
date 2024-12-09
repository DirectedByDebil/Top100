using Core;
using static System.Net.WebRequestMethods;

namespace Web
{
    public static class UrlFactory
    {

        public static string GetAllCollections(ContentType type)
        {

            switch (type)
            {

                case ContentType.Movies:

                    return GetKinopoiskAll();


                case ContentType.Music:

                    return GetLastFmAll();


                case ContentType.Games:

                    return GetRawgAll();


                case ContentType.Books:

                    return GetBooksAll();


                default:

                    return "";
            }
        }


        public static bool TryGetCurrentCollection(ContentType type,
            
            object item, out string request)
        {

            switch (type)
            {

                case ContentType.Movies:
                    
                    return TryGetKinopoiskCurrent(item, out request);

                
                case ContentType.Music:
                    
                    return TryGetLastFmCurrent(item, out request);
                

                case ContentType.Games:

                    return TryGetRawgCurrent(item, out request);
                

                case ContentType.Books:
                    
                    return TryGetBooksCurrent(item, out request);
                

                default:

                    request = "";

                    return false;
            }
        }


        #region Get All Collections Methods

        private static string GetKinopoiskAll()
        {

            return "https://api.kinopoisk.dev/v1.4/list?" +
                "page=1&limit=30&" +
                "selectFields=name&selectFields=category&selectFields=moviesCount&" +
                "selectFields=cover&selectFields=slug&" +
                "notNullFields=name&notNullFields=category&notNullFields=moviesCount&" +
                "notNullFields=cover.previewUrl&notNullFields=slug";
        }

        private static string GetLastFmAll() => "";

        private static string GetBooksAll() => "";


        private static string GetRawgAll()
        {

            return "https://api.rawg.io/api/tags?key=4ac16da180e847b3ba4cce6525a8bfdf";
        }

        #endregion


        #region Get Current Collection Methods

        private static bool TryGetKinopoiskCurrent(object item,
            
            out string request)
        {

            if (item is KinopoiskCollectionData data)
            {

                request = string.Format("https://api.kinopoisk.dev/v1.4/movie?" +
                   "page=1&limit={0}&" +
                   "selectFields=name&selectFields=year&selectFields=poster&selectFields=lists&" +
                   "notNullFields=name&notNullFields=year&notNullFields=poster.url&notNullFields=lists&" +
                   "lists={1}", data.MoviesCount, data.Slug);

                return true;
            }

            request = "";

            return false;
        }


        private static bool TryGetLastFmCurrent(object item,
            
            out string request)
        {

            request = "";

            return false;
        }


        private static bool TryGetRawgCurrent(object item,

            out string request)
        {

            if(item is RawgTag tag)
            {

                request = string.Format("https://api.rawg.io/api/games?key=4ac16da180e847b3ba4cce6525a8bfdf&" +
                    "tags={0}", tag.Slug);

                return true;
            }


            request = "";

            return false;
        }


        private static bool TryGetBooksCurrent(object item,

            out string request)
        {

            request = "";

            return false;
        }

        #endregion
    }
}
