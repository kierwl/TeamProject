Shader "Custom/GlowShader"
{
    Properties
    {
        _Color ("Glow Color", Color) = (1, 0, 0, 1)  // 초기 색상은 빨간색으로 설정
        _GlowIntensity ("Glow Intensity", Float) = 1.0
        _MainTex ("Base (RGB)", 2D) = "white" { }
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
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
                float4 pos : POSITION;
                float4 color : COLOR;
            };

            uniform float _GlowIntensity;
            uniform float4 _Color;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.color = _Color * _GlowIntensity;  // 색상과 발광 강도를 결합
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                return i.color;  // 색상 값을 반환
            }
            ENDCG
        }
    }
}
