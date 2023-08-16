using walkerscott_domain.Entities;

namespace walkerscott_application.Utilities
{
    public static class MatchUtil
    {
        public static List<NewsArticle> FindTopNBestMatch(string stringToCompare, IEnumerable<NewsArticle> articles, int count, int toSkip = 0)
        {

            HashSet<string> strCompareHash = stringToCompare.Split(' ').ToHashSet();

            var listWIthMatchCount = new List<MatchScore>();

            List<NewsArticle> bestMatch = new List<NewsArticle>();
            char[] charArr = new char[] { ' ', ',' , ','};

            foreach (var item in articles)
            {
                HashSet<string> strHash = String.Concat(item.Description, " " +  item.Title).Split(charArr).ToHashSet();

                int intersectCount = strCompareHash.Intersect(strHash).Count();
                int partialIntersect = strCompareHash.Where(x => strHash.Any(y => y.Contains(x))).ToList().Count();
                if ( partialIntersect > 0)
                {
                    listWIthMatchCount.Add(new MatchScore { item = item, score =  partialIntersect + intersectCount });

                }

            }


            bestMatch = listWIthMatchCount.Skip(toSkip).OrderByDescending(x => x.score).Select(x => x.item).Take(count).ToList();

            return bestMatch;
        }
    }

    public class MatchScore
    {
        public int score;
        public NewsArticle item;
    }

}
