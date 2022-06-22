Shader "Unlit/FinishShader"
{
    Properties
    {
        _CoordFirst ("First Object Coord",float)=10
        _CoordLast ("Last Object Coord",float)=10
        _RefColor("Ref Color",Color)=(0,0,0,0)
        _Offset("Offset",Range(0,3))=2
        _Brightness("Brightness",Range(0.01,0.99))=0.5
        _ColorSaturation("Color Saturation",Range(0.01,0.99))=0.5
        _Transparency("Transparency",Range(0.01,0.99))=0.5
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 world_pos : TEXCOORD2;
                float4 vertex : SV_POSITION;
            };
            float _CoordFirst;
            float _CoordLast;
            float4 _RefColor;
            float _Offset;
            float _ColorSaturation;
            float _Brightness;
            float _Transparency;

            

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.world_pos=mul( unity_ObjectToWorld,v.vertex);
                return o;
            }
            float3 RGBToHSV(float3 c)
			{
				float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
				float4 p = lerp( float4( c.bg, K.wz ), float4( c.gb, K.xy ), step( c.b, c.g ) );
				float4 q = lerp( float4( p.xyw, c.r ), float4( c.r, p.yzx ), step( p.x, c.r ) );
				float d = q.x - min( q.w, q.y );
				float e = 1.0e-10;
				return float3( abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
			}
            float3 HSVToRGB( float3 c )
			{
				float4 K = float4( 1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0 );
				float3 p = abs( frac( c.xxx + K.xyz ) * 6.0 - K.www );
				return c.z * lerp( K.xxx, saturate( p - K.xxx ), c.y );
			}

            fixed4 frag (v2f i) : SV_Target
            {
                float objectZCoord= i.world_pos.z;
                float distance=_CoordLast-_CoordFirst;
                float4 color=_RefColor;
                float3 color1= RGBToHSV(color.rgb);
                if(objectZCoord>_CoordFirst)
                {
                    float constant= (objectZCoord-_CoordFirst)/distance;
                    color1*=float3(constant+_Offset,_ColorSaturation,_Brightness);
                    color.rgb= HSVToRGB(color1);
                }
                color-=(0,0,0,_Transparency);
                
                return color;
            }
            ENDCG
        }
    }
}
