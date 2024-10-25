namespace Klotski;
public static class Utils
{
    public static (float, float, float) HsvToRgb(float h, float s, float v)
    {
        if (h == 360)
        {
            h = 0;
        }
        float[] rgb = new float[3];
        float r = 0;
        float g = 0;
        float b = 0;

        if (s == 0)
        {
            r = g = b = v;
        }
        else
        {
            float sectorPos = h / 60f;
            int sectorNum = (int)Math.Floor(sectorPos);
            float fractionalSector = sectorPos - sectorNum;
            float p = v * (1 - s);
            float q = v * (1 - (s * fractionalSector));
            float t = v * (1 - (s * (1 - fractionalSector)));
            switch (sectorNum)
            {
                case 0:
                    r = v;
                    g = t;
                    b = p;
                    break;
                case 1:
                    r = q;
                    g = v;
                    b = p;
                    break;
                case 2:
                    r = p;
                    g = v;
                    b = t;
                    break;
                case 3:
                    r = p;
                    g = q;
                    b = v;
                    break;
                case 4:
                    r = t;
                    g = p;
                    b = v;
                    break;
                case 5:
                    r = v;
                    g = p;
                    b = q;
                    break;
            }

        }
        return (r * 255, g * 255, b * 255);
    }
}