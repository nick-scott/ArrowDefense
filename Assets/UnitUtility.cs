using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitUtility {

	public static float percentHeight(float percent)
	{
		float realPercentage = 100 / percent;
		return Screen.height/realPercentage;
	}

	public static float percentWidth(float percent)
	{
		float realPercentage = 100 / percent;
		return Screen.width / realPercentage;
	}

	public static float centerWidth()
	{
		return Screen.width / 2;
	}

	public static float centerHeight()
	{
		return Screen.height / 2;
	}

    public static float byAnchorPercentHeight(GameObject anchorObject, Anchor anchor, float percent)
    {
        switch (anchor)
        {
            case Anchor.TOP:
                return 0;
            case Anchor.BOTTOM:
                return 0;
        }
        return percentHeight(percent);
    }

    public static float byAnchorPercentWidth(GameObject anchorObject, Anchor anchor, float percent)
    {
        switch (anchor)
        {
            case Anchor.LEFT:
                return 0;
            case Anchor.RIGHT:
                return 0;
        }
        return percentHeight(percent);
    }

    public enum Anchor{
        TOP,
        RIGHT,
        BOTTOM,
        LEFT
    }
    
}