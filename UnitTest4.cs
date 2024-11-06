namespace JoyCastleExam;
using System;
using System.Collections.Generic;
using NUnit.Framework;

public class TalentAssessmentSystem
{
    public static int GetKthElement(int[] nums1, int[] nums2, int k)
    {

        int m = nums1.Length;
        int n = nums2.Length;
        int index1 = 0, index2 = 0;

        while (true)
        {
            if (index1 == m)
            {
                return nums2[index2 + k - 1];
            }
            if (index2 == n)
            {
                return nums1[index1 + k - 1];
            }
            if (k == 1)
            {
                return int.Min(nums1[index1], nums2[index2]);
            }

            int newIndex1 = int.Min(index1 + k / 2 - 1, m - 1);
            int newIndex2 = int.Min(index2 + k / 2 - 1, n - 1);
            int pivot1 = nums1[newIndex1];
            int pivot2 = nums2[newIndex2];
            if (pivot1 <= pivot2)
            {
                k -= newIndex1 - index1 + 1;
                index1 = newIndex1 + 1;
            }
            else
            {
                k -= newIndex2 - index2 + 1;
                index2 = newIndex2 + 1;
            }
        }
    }
    public static double FindMedianTalentIndex(int[] fireAbility, int[] iceAbility)
    {
        // 在这⾥实现你的代码
        int totalLength = fireAbility.Length + iceAbility.Length;
        if (totalLength % 2 == 1)
        {
            return GetKthElement(fireAbility, iceAbility, (totalLength + 1) / 2);
        }
        else
        {
            return (GetKthElement(fireAbility, iceAbility, totalLength / 2) + GetKthElement(fireAbility, iceAbility, totalLength / 2 + 1)) / 2.0;
        }
    }
}



// 单元测试
[TestFixture]
public class TalentAssessmentSystemTests
{
    [Test]
    [TestCase(new int[] { 1, 3, 7, 9, 11 }, new int[] { 2, 4, 8, 10, 12, 14 }, 8)]
    [TestCase(new int[] { 1, 3, 7, 9, 11 }, new int[] { 2, 4, 6, 8, 10, 12, 14 }, 7.5)]
    public void TestFindMedianTalentIndex(int[] fireAbility, int[] iceAbility, double median)
    {
        // 在这⾥编写测试⽤例
        Assert.That(TalentAssessmentSystem.FindMedianTalentIndex(iceAbility, fireAbility), Is.EqualTo(median));
    }
}