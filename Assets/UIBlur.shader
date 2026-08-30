Shader "Custom/UIBlur"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BlurSize ("Blur Size", Range(0, 10)) = 3
        _Darkness ("Darkness", Range(0, 1)) = 0.3
    }

    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }

        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        Cull Off

        Pass
        {
            HLSLPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_TexelSize;

            float _BlurSize;
            float _Darkness;

            v2f vert(appdata v)
            {
                v2f o;

                o.vertex =
                    UnityObjectToClipPos(v.vertex);

                o.uv = v.uv;

                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 blur =
                    _MainTex_TexelSize.xy * _BlurSize;

                fixed4 col = tex2D(_MainTex, i.uv);

                col += tex2D(
                    _MainTex,
                    i.uv + float2( blur.x, 0)
                );

                col += tex2D(
                    _MainTex,
                    i.uv + float2(-blur.x, 0)
                );

                col += tex2D(
                    _MainTex,
                    i.uv + float2(0, blur.y)
                );

                col += tex2D(
                    _MainTex,
                    i.uv + float2(0, -blur.y)
                );

                col += tex2D(
                    _MainTex,
                    i.uv + float2( blur.x, blur.y)
                );

                col += tex2D(
                    _MainTex,
                    i.uv + float2(-blur.x, blur.y)
                );

                col += tex2D(
                    _MainTex,
                    i.uv + float2( blur.x, -blur.y)
                );

                col += tex2D(
                    _MainTex,
                    i.uv + float2(-blur.x, -blur.y)
                );

                col /= 9;

                col.rgb *= (1.0 - _Darkness);

                return col;
            }

            ENDHLSL
        }
    }
}
