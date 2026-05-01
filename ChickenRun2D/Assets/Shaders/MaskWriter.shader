Shader "UI/MaskWriterSoft"
{
    Properties
    {
        _MainTex ("Sprite", 2D) = "white" {}
        _Cutoff ("Alpha Cutoff", Range(0,1)) = 0.1
        _Softness ("Edge Softness", Range(0.001, 0.5)) = 0.05
        _Stencil ("Stencil ID", Float) = 1
        _StencilOp ("Stencil Operation", Float) = 2
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        _StencilComp ("Stencil Comparison", Float) = 8
        _ColorMask ("Color Mask", Float) = 0
    }

    SubShader
    {
        Tags { "Queue"="Transparent" }

        ColorMask 0

        Stencil
        {
            Ref 1
            Comp Always
            Pass Replace
        }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            sampler2D _MainTex;
            float _Cutoff;
            float _Softness;

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            void frag (v2f i)
            {
                float alpha = tex2D(_MainTex, i.uv).a;

                // плавный переход
                float edge = smoothstep(_Cutoff, _Cutoff + _Softness, alpha);

                clip(edge - 0.01);
            }
            ENDCG
        }
    }
}