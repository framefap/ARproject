using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VectorGraphics;

public class SVGRuntimeLoad : MonoBehaviour
{
    void Start()
    {
        /*string svg =
            @"<svg width=""283.9"" height=""283.9"" xmlns=""http://www.w3.org/2000/svg"">
                <line x1=""170.3"" y1=""226.99"" x2=""177.38"" y2=""198.64"" fill=""none"" stroke=""#888"" stroke-width=""1""/>
                <line x1=""205.73"" y1=""198.64"" x2=""212.81"" y2=""226.99"" fill=""none"" stroke=""#888"" stroke-width=""1""/>
                <line x1=""212.81"" y1=""226.99"" x2=""219.9"" y2=""255.33"" fill=""none"" stroke=""#888"" stroke-width=""1""/>
                <line x1=""248.25"" y1=""255.33"" x2=""255.33"" y2=""226.99"" fill=""none"" stroke=""#888"" stroke-width=""1""/>
                <path d=""M170.08,226.77c7.09-28.34,35.43-28.34,42.52,0s35.43,28.35,42.52,0"" transform=""translate(0.22 0.22)"" fill=""none"" stroke=""red"" stroke-width=""1.2""/>
                <circle cx=""170.3"" cy=""226.99"" r=""1.2"" fill=""blue"" stroke-width=""0.6""/>
                <circle cx=""212.81"" cy=""226.99"" r=""1.2"" fill=""blue"" stroke-width=""0.6""/>
                <circle cx=""255.33"" cy=""226.99"" r=""1.2"" fill=""blue"" stroke-width=""0.6""/>
                <circle cx=""177.38"" cy=""198.64"" r=""1"" fill=""black"" />
                <circle cx=""205.73"" cy=""198.64"" r=""1"" fill=""black"" />
                <circle cx=""248.25"" cy=""255.33"" r=""1"" fill=""black"" />
                <circle cx=""219.9"" cy=""255.33"" r=""1"" fill=""black"" />
            </svg>";*/

        string svg =
            @"<svg width=""28"" height=""32"" viewBox=""0 0 28 32"" fill=""none"" xmlns=""http://www.w3.org/2000/svg"">
                <path d = ""M27.3337 15C27.3337 13.1617 25.8387 11.6667 24.0003 11.6667H22.3337V6.66667C22.3337 2.07167 18.5953 0 14.0003 0C9.40532 0 5.66699 2.07167 5.66699 6.66667V11.6667H4.00032C2.16199 11.6667 0.666992 13.1617 0.666992 15V28.3333C0.666992 30.1717 2.16199 31.6667 4.00032 31.6667H24.0003C25.8387 31.6667 27.3337 30.1717 27.3337 28.3333V15ZM9.00032 6.66667C9.00032 3.91 11.2437 3.33333 14.0003 3.33333C16.757 3.33333 19.0003 3.91 19.0003 6.66667V11.6667H9.00032V6.66667Z"" fill = ""#BE1B1B"" />
            </svg>";


        var tessOptions = new VectorUtils.TessellationOptions()
        {
            StepDistance = 100.0f,
            MaxCordDeviation = 0.5f,
            MaxTanAngleDeviation = 0.1f,
            SamplingStepSize = 0.01f
        };

        // Dynamically import the SVG data, and tessellate the resulting vector scene.
        var sceneInfo = SVGParser.ImportSVG(new StringReader(svg));
        var geoms = VectorUtils.TessellateScene(sceneInfo.Scene, tessOptions);

        // Build a sprite with the tessellated geometry.
        var sprite = VectorUtils.BuildSprite(geoms, 10.0f, VectorUtils.Alignment.Center, Vector2.zero, 128, true);
        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    void OnDisable()
    {
        GameObject.Destroy(GetComponent<SpriteRenderer>().sprite);
    }
}