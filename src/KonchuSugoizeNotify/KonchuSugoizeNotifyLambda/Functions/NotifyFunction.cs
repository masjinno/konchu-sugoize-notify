using Amazon.Lambda.Core;
using KonchuSugoizeNotifyLambda.Models;

namespace KonchuSugoizeNotifyLambda.Functions;

public class NotifyFunction
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public string NotifyOfFreeTV(string input, ILambdaContext context)
    {
        NotifyLogic logic = new NotifyLogic();
        logic.NotifyOfFreeTV();
        return input.ToUpper();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public string NotifyOfPremiumTV(string input, ILambdaContext context)
    {
        NotifyLogic logic = new NotifyLogic();
        logic.NotifyOfPremiumTV();
        return input.ToUpper();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public string NotifyOfRadio(string input, ILambdaContext context)
    {
        NotifyLogic logic = new NotifyLogic();
        logic.NotifyOfRadio();
        return input.ToUpper();
    }
}
