namespace JoyCastleExam;
using System;
using System.Collections.Generic;
using NUnit.Framework;

public class TreasureHuntSystem
{
    public static int MaxTreasureValue(int[] treasures)
    {
        // 在这⾥实现你的代码
        int n = treasures.Length;
        int[] dp1 = new int[n], dp2 = new int[n];//分别存储到第k个宝箱为止，开或不开第k个宝箱的最大价值
        if (0 == n)
            return 0;
        dp1[0] = treasures[0];
        for (int i = 1; i < n; ++i)
        {
            dp1[i] = dp2[i - 1] + treasures[i];
            dp2[i] = int.Max(dp1[i - 1], dp2[i - 1]);
        }
        return int.Max(dp1[n - 1], dp2[n - 1]);
    }
}

// 单元测试
[TestFixture]
public class TreasureHuntSystemTests
{
    [Test]
    [TestCase(new int[] { 3, 1, 5, 2, 4 }, 12)]
    [TestCase(new int[] { 3, -1, 5, 2, -4, -5, 2, }, 10)]
    public void TestMaxTreasureValue(int[] treasures, int ans)
    {
        // 在这⾥编写测试⽤例
        Assert.That(TreasureHuntSystem.MaxTreasureValue(treasures), Is.EqualTo(ans));
    }
}