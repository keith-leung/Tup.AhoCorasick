using System;

namespace Tup.AhoCorasick.NetCore21
{
    class Program
    {
        static void Main(string[] args)
        {
            var search = new AhoCorasickSearch() { IsCaseSensitive = true };
            var keywords = new string[] { "he", "She", "hIs", "herS" };
            search.Build(keywords);

            searchTest(search);
            replaceTest(search);
            replaceTest2();
            replaceTest3();

            Console.Read();
        }

        private static void searchTest(AhoCorasickSearch search)
        {
            var res = search.SearchAll("ushersushers");
            Console.WriteLine(res);
            for (int i = 0; i < res.Length; i++)
            {
                Console.WriteLine(res[i].ToString());
                Console.WriteLine("Match=" + res[i].Match);
            }
        }

        private static void replaceTest(AhoCorasickSearch search)
        {
            var text = "ushers";
            var res = search.Replace(text, "-");
            Console.WriteLine(res);

            text = "shersx";
            res = search.Replace(text, "-");
            Console.WriteLine(res);

            text = "her";
            res = search.Replace(text, "-");
            Console.WriteLine(res);

            text = "she";
            res = search.Replace(text, "-");
            Console.WriteLine(res);
        }

        private static void replaceTest2()
        {
            var search = new AhoCorasickSearch();
            var keywords = new string[] { "伟大", "特色主义", "公园" };
            search.Build(keywords);

            var text = "从这里建设伟大的特色主义主题公园";
            var res = search.Replace(text, "-");
            Console.WriteLine(res);

            text = "主题公园";
            res = search.Replace(text, "-");
            Console.WriteLine(res);

            text = "伟大的特色主义主题公园";
            res = search.Replace(text, "-");
            Console.WriteLine(res);

            text = "伟大特色主义公园";
            res = search.Replace(text, "-");
            Console.WriteLine(res);
        }

        private static void replaceTest3()
        {
            var search = new AhoCorasickSearch();
            var keywords = new string[] { "一边", "刀锋", "烽火" };
            search.Build(keywords);

            var text = "一边烽火, 一边烽火天";
            var res = search.Replace(text, "-");
            Console.WriteLine(res);

            text = "一边刀锋很犀利";
            res = search.Replace(text, "-");
            Console.WriteLine(res);
        }
    }
}
