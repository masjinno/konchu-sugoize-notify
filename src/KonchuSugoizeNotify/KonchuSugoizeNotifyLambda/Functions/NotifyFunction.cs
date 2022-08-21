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
    public void NotifyOfFreeTV(object input, ILambdaContext context)
    {
        NotifyLogic logic = new NotifyLogic();
        logic.NotifyOfFreeTV();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public void NotifyOfPremiumTV(object input, ILambdaContext context)
    {
        NotifyLogic logic = new NotifyLogic();
        logic.NotifyOfPremiumTV();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public void NotifyOfRadio(object input, ILambdaContext context)
    {
        NotifyLogic logic = new NotifyLogic();
        logic.NotifyOfRadio();
    }
}
