using walkerscott_domain.Entities;

namespace walkerscott_application.Utilities
{
    public static class MatchUtil
    {
        public static List<NewsArticle> FindTopNBestMatch(string stringToCompare, IEnumerable<NewsArticle> articles, int count)
        {

            HashSet<string> strCompareHash = stringToCompare.Split(' ').ToHashSet();

            var listWIthMatchCount = new List<MatchScore>();

            List<NewsArticle> bestMatch = new List<NewsArticle>();
            char[] charArr = new char[] { ' ', ',' , ','};

            foreach (var item in articles)
            {
                HashSet<string> strHash = item.Description.Split(charArr).ToHashSet();

                int intersectCount = strCompareHash.Intersect(strHash).Count();
                if(intersectCount > 0 )
                {
                    listWIthMatchCount.Add(new MatchScore { item = item, score = intersectCount });

                }

            }


            bestMatch = listWIthMatchCount.OrderByDescending(x => x.score).Select(x => x.item).Take(count).ToList();

            return bestMatch;
        }
    }

    public class MatchScore
    {
        public int score;
        public NewsArticle item;
    }
}
