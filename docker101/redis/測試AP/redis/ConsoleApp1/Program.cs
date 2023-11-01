using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using StackExchange.Redis;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("digi-uat1.redis.cache.windows.net:6380,password=gsjSH2yaOmZnA7EgnAFxz4Ar4OdHmpIjdAzCaJwfJ0Y=,ssl=True,abortConnect=False,syncTimeout =3000");
            IDatabase db = redis.GetDatabase();

            //db.KeyDelete("key");

            //#region string

            ////string取值
            //var jsonName = db.StringGet("jsonName");
            //Console.WriteLine($"name's value in redis db is : {jsonName}");

            ////string予值
            //db.StringSet("name", "xavier");
            //db.StringSet("age", 20);
            //Console.WriteLine($"{db.StringGet("name")}'s age is : {db.StringGet("age")}");

            ////修改，重新設定即可
            //db.StringSet("age", 30);
            //Console.WriteLine($"{db.StringGet("name")}'s age is : {db.StringGet("age")}");

            ////刪除
            //db.KeyDelete("name");
            //db.KeyDelete("age");
            //Console.WriteLine($"{db.StringGet("name")}'s age is : {db.StringGet("age")}");


            ////可以針對一個數值做遞增或遞減，不指定的話預設就是1，比如用於訪客人數的運用，
            //db.StringIncrement("visitCount");
            //Console.WriteLine($"{db.StringGet("visitCount")}");

            //db.StringDecrement("visitCount");
            //Console.WriteLine($"{db.StringGet("visitCount")}");


            ////expire
            //db.KeyExpire("name", new TimeSpan(0, 0, 5));
            //Thread.Sleep(5 * 1000);
            //Console.WriteLine("expire " + "strKey:name " + ", after 5 seconds, value is " + db.StringGet("name"));


            ////多筆 mset mget
            //KeyValuePair<RedisKey, RedisValue> kv1 = new KeyValuePair<RedisKey, RedisValue>("key1", "value1");
            //KeyValuePair<RedisKey, RedisValue> kv2 = new KeyValuePair<RedisKey, RedisValue>("key2", "value2");
            //db.StringSet(new KeyValuePair<RedisKey, RedisValue>[] { kv1, kv2 });
            //RedisValue[] values = db.StringGet(new RedisKey[] { kv1.Key, kv2.Key });
            //Console.WriteLine("mget " + kv1.Key.ToString() + " " + kv2.Key.ToString() + ", result is " + values[0] + "&&" + values[1]);

            //#endregion

            #region list 有序排列，值可以重複

            ////可以通過pop、push操作來從頭部和尾部刪除或者添加元素
            // db.ListRightPush("company", "apple");
            //db.ListLeftPush("company", "microsoft");
            //db.ListRightPush("company", "google");
            //db.ListRightPush("companyy", "google");

            ////取值
            //db.ListRange("company").ToList().ForEach(d => Console.WriteLine(d));

            //db.ListRange("company", 0, 1).ToList().ForEach(d => Console.WriteLine(d));

            //Console.WriteLine(db.ListGetByIndex("company", 2));

            /////刪除
            //////從後刪除
            //db.ListRightPop("company");
            //////從前面刪除
            //db.ListLeftPop("company");
            //////刪除資料用指定的方式
            //db.ListRemove("company", "apple");

            /////太亂，整個刪掉重來
            ////db.KeyDelete("company");

            #endregion

            #region  sets 無序排列，值不可重復

            //增加刪除查詢都很快。提供了取並集交集差集等一些有用的操作

            //實際應用情境可以想像存進了一些queue的值，然後一筆一筆去消化，全部消化完這個key裡的value就都會全部清空

            ////insert
            //db.SetAdd("test", "apple");
            //db.SetAdd("test", "apple");
            //db.SetAdd("test", "pineapple");
            //db.SetAdd("test", "peach");

            ////取值
            //var setScan = db.SetScan("test", "*pple");
            //setScan.ToList().ForEach(x => Console.WriteLine(x));

            //// 刪除
            //db.SetRemove("test", "apple");
            //db.SetScan("test").ToList().ForEach(x => Console.WriteLine(x));

            ////判斷是否存在
            //bool a = db.SetContains("test", "peach");

            ////多個SET取交集
            //db.SetAdd("test2", "peach");
            //RedisValue[] combine = db.SetCombine(SetOperation.Intersect, "test", "test2");
            //Console.WriteLine(string.Join(",", combine));

            #endregion

            #region SortedSet 有序排列，值不可重復；類似Set，不同的是sortedset的每個元素都會關聯一個double類型的score，用此元素來進行排序

            //需求：顯示文章被贊最多的十條評論

            //List<SortedSetEntry> entrys = new List<SortedSetEntry>();
            for (int i = 1; i <= 100; i++)
            {
                db.SortedSetAdd("文章1", "評論者" + i, 1);
            }

            //評論者2又被贊了兩次
            db.SortedSetIncrement("文章1", "評論者2", 2); //對應的值的score+2

            //評論者101被贊了4次
            db.SortedSetIncrement("文章1", "評論者101", 4);  //若不存在該值，則插入一個新的

            //取前10名
            RedisValue[] userStores = db.SortedSetRangeByRank("文章1", 0, 10, Order.Descending);
            for (int i = 0; i < userStores.Length; i++)
            {
                Console.WriteLine(userStores[i] + ":" + db.SortedSetScore("文章1", userStores[i]));
            }
            #endregion

            #region hashes 特點:Hash是一個string類型的field和value的對應表，它更適合來存儲對象，相比於每個屬性進行一次緩存，利用hash來存儲整個對象會占用更小的內存。但是存儲速度並不會更快
            //很像dictionary的概念，可以存key值和一個value值，key值唯一

            //予值
            //db.HashSet("chailease", new HashEntry[] {
            //    new HashEntry("1","Ian"),
            //    new HashEntry("2","Kai"),
            //    new HashEntry("3","Xavier")
            //});

            db.HashSet("chailease", "4", "Lewis");

            ///取值
            //全部
            Console.WriteLine("取出chailease中成員:");
            db.HashGetAll("chailease").ToList().ForEach(x => Console.WriteLine(x));
            //某筆
            Console.WriteLine("取出chailease中key為4的成員:");
            Console.WriteLine(db.HashGet("chailease", "4"));
            //某幾筆
            RedisValue[] result = db.HashGet("chailease", new RedisValue[] { "2", "4" });
            Console.WriteLine("取出chailease中key為2、4的成員:");
            Console.WriteLine(string.Join(",", result));

            ///修改
            db.HashSet("chailease", "3", "KaiLiu");
            Console.WriteLine("將chailease中key為3的成員重新于值:");
            db.HashGetAll("chailease").ToList().ForEach(x => Console.WriteLine(x));

            ///刪除
            db.HashDelete("chailease", 3);
            Console.WriteLine("將chailease中key為3的成員刪除:");
            db.HashGetAll("chailease").ToList().ForEach(x => Console.WriteLine(x));
            #endregion



        }
    }
}
