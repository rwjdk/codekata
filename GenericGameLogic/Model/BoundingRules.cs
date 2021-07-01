using System;

namespace GenericGameLogic.Model
{
    [Flags]
    public enum BoundingRules
    {
        None=0,
        NeedToStayWithinGameScreen = 1,
        CanNotTouchOtherSpritesOnGameScreen = 2
    }
}