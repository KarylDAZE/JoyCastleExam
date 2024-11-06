namespace JoyCastleExam;
using System;
using System.Collections.Generic;
using NUnit.Framework;

public class EnergyFieldSystem
{
    public static float MaxEnergyField(int[] heights)
    {
        // 在这⾥实现你的代码
        int n = heights.Length;
        float area = 0;
        //枚举
        for (int i = 0; i < n - 1; ++i)
            for (int j = i + 1; j < n; ++j)
            {
                if (0 != heights[i] && 0 != heights[j])
                    area = float.Max(area, (heights[i] + heights[j]) * (j - i) / 2.0f);
            }
        return area;
    }
}
// 单元测试
[TestFixture]
public class EnergyFieldSystemTests
{
    [Test]
    [TestCase(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, 52.5f)]
    [TestCase(new int[] { 1, 2, 6, 10, 20, 20, 8, 9, 7 }, 54)]
    public void TestMaxEnergyField(int[] heights, float ans)
    {
        // 在这⾥编写测试⽤例
        Assert.That(EnergyFieldSystem.MaxEnergyField(heights), Is.EqualTo(ans));
    }
}