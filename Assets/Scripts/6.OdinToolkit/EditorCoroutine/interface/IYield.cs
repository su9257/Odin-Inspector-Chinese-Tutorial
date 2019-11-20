
internal interface IYield
{
    /// <summary>
    /// 判断迭代是否可以跳转下一次迭代
    /// </summary>
    /// <param name="deltaTime"></param>
    /// <param name="frameCount"></param>
    /// <returns></returns>
    bool IsReadyToYield(double deltaTime, int frameCount);
}
