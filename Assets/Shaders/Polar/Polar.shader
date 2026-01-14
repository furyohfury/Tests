Shader "Polar"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1,
        1, 1, 1)
        _BaseTex("Base Texture", 2D) = "white"
        {}
        _Center ("Center", Vector) = (0.5, 0.5, 0, 0)
        _RadialScale("Radial scale", Float) = 1
        _LengthScale("LengthScale", Float) = 1
    }
    SubShader
    {
        Tags
        {
            "RenderType" = "Opaque"
            "Queue" = "Geometry"
            "RenderPipeline" = "UniversalPipeline"
        }
        Pass
        {
            Tags
            {
                "LightMode" = "UniversalForward"
            }
            
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            
            struct appdata
            {
                float4 positionOS : Position;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 positionCS : SV_Position;
                float2 uv : TEXCOORD0;
            };
            
            CBUFFER_START(UnityPerMaterial)
            float4 _BaseTex_ST;
            float4 _BaseColor;
            float4 _Center;
            float _RadialScale;
            float _LengthScale;
            CBUFFER_END
            sampler2D _BaseTex;
            
            float2 cartesianToPolar(float2 cartUV)
            {
                float2 polarUV;
                float2 offseted = cartUV - _Center;
                float x = offseted.x;
                float y = offseted.y;
                polarUV.x = sqrt(x * x + y * y);
                polarUV.y = atan(y / x);
                
                return polarUV;
            }

            v2f vert(appdata v)
            {
                v2f o;
                o.positionCS = TransformObjectToHClip(v.positionOS);
                o.uv = TRANSFORM_TEX(v.uv, _BaseTex);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float2 radialUV = cartesianToPolar(i.uv);
                radialUV.x *= _RadialScale;
                radialUV.y *= _LengthScale;
                float4 textureSample = tex2D(_BaseTex,                radialUV);
                return textureSample * _BaseColor;
            }
            ENDHLSL
        }
    }
}