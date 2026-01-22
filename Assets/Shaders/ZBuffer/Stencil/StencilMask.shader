Shader "StencilMask"
{
    Properties
    {
        [IntRange] _StencilRef("StencilValue", Range(0, 255)) = 1
    }
    SubShader
    {
        Tags
        {
            "RenderType" = "Transparent"
            "Queue" = "Geometry-1"
            "RenderPipeline" = "UniversalPipeline"
        }
        Pass
        {
            ColorMask 0
            ZWrite Off
            
            Stencil
            {
                Ref [_StencilRef]
                Comp Always
                Pass Replace
            }
        }
    }
    Fallback Off
}