Shader "Custom/DepthMaskTexture_URP"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry-1" }
        Pass
        {
            Name "DepthMask"
            Tags { "LightMode" = "UniversalForward" }

            ZWrite On
            ColorMask 0

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 uv           : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionHCS  : SV_POSITION;
                float2 uv           : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            Varyings vert(Attributes input)
            {
                Varyings output;
                float4 posWS = TransformObjectToHClip(input.positionOS.xyz);
                output.positionHCS = posWS;
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                // No color output, just depth write
                return 0;
            }
            ENDHLSL
        }
    }
    FallBack Off
}
