Shader "Unlit/TestUnlitShader"
{
    Properties
    {
       _Color ("Color", color) =(0.07, 0.75, 0.57, 1)
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert;
            #pragma fragment frag

            struct appdata_base{
            float4 vertex : POSITION;
            };
            
            struct v2f{
            //vertex shader(balang) ile fragment shader aras�ndaki ileim
            float4 pos : SV_POSITION;
            };
            v2f vert(appdata_base v){
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                return o;
            }
            float4 _Color;
            float4 frag(v2f i) : SV_Target {
                return _Color;
            }

            ENDCG
        }
    }
}
