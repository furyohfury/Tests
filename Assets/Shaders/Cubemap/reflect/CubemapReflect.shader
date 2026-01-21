Shader "CubemapReflect"
{
    Properties
    {
        _BaseColor ("Base Color", Color) = (1,
        1, 1, 1)
        _Cubemap("Base Texture", Cube) = "white"
        {}
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
                float3 normalOS : Normal;
            };

            struct v2f
            {
                float4 positionCS : SV_Position;
                float3 reflectWS : TEXCOORD0;
            };
            
            CBUFFER_START(UnityPerMaterial)
            float4 _BaseTex_ST;
            float4 _BaseColor;
            CBUFFER_END
            samplerCUBE _Cubemap;

            v2f vert(appdata v)
            {
                v2f o;
                o.positionCS = TransformObjectToHClip(v.positionOS);
                float3 normalWS = TransformObjectToWorldNormal(v.normalOS);
                
                // float3 positionWS = mul(unity_ObjectToWorld, v.positionOS).xyz;
                float3 positionWS = TransformObjectToWorld(v.positionOS);
                float3 viewDirWS = GetWorldSpaceNormalizeViewDir(positionWS);
                o.reflectWS = reflect(-viewDirWS, normalWS);
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                float4 cubemapSample = texCUBE(_Cubemap, i.reflectWS);
return cubemapSample;
            }
            ENDHLSL
        }
    }
}