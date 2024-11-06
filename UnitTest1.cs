namespace JoyCastleExam;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

public class LeaderboardSystem
{
    public static List<int> GetTopScores(int[] scores, int m)
    {
        // 在这⾥实现你的代码
        int n = scores.Length, left = 0, right = n - 1, l, r;
        List<int> topScores = [];
        if (m <= 0)
            return [];
        if (m >= n)
        {
            //若m较大，可以考虑直接对scores全部进行排序
            topScores.AddRange(scores);
            topScores.Sort((x, y) => y.CompareTo(x));
            return topScores;
        }
        else
        {
            //利用快速选择，找到第m大的数后对前m大的数排序
            while (left < right)
            {
                l = left;
                r = right;
                while (l < r)
                {
                    while (l <= r && scores[l] <= scores[left])
                        ++l;
                    while (l <= r && scores[r] >= scores[left])
                        --r;
                    if (l < r)
                        (scores[r], scores[l]) = (scores[l], scores[r]);
                }
                (scores[left], scores[r]) = (scores[r], scores[left]);
                if (r > n - m)
                    right = r - 1;
                else if (r < n - m)
                    left = r + 1;
                else if (r == n - m)
                {
                    left = r;
                    break;
                }
            }
            topScores.AddRange(scores.Skip(n - m));
            topScores.Sort((x, y) => y.CompareTo(x));
            return topScores;
        }
    }
}

// 单元测试
[TestFixture]
public class LeaderboardSystemTests
{
    [Test]
    [TestCase(new int[] { 100, 50, 75, 80, 65 }, 3, new int[] { 100, 80, 75 })]
    [TestCase(new int[] { 100, 50, 75, 80, 65, 104, 105, 1234, 23 }, 6, new int[] { 1234, 105, 104, 100, 80, 75 })]
    public void TestGetTopScores(int[] scores, int m, int[] ans)
    {
        // 在这⾥编写测试⽤例
        List<int> answer = new(ans);
        List<int> list = LeaderboardSystem.GetTopScores(scores, m);
        Assert.That(list, Is.EqualTo(answer).AsCollection);
    }
}