Shader "Scripts/ShaderFile/MotionBlur" 
{
  subShader
  {
    Pass
      CGPROGRAM
      #pragma vertex vert
      #pragma fragment frag

      #include "UnityCG.cginc"
      
      sampler2D MotionBlurTex;
      sampler2D MotionBlurTex1;
     
      fixed frag(v2f_img i) : SV_Target
      {
        fixed4 color0 = tex2D(MotionBlurTex,i.uv)  / 3;
        fixed4 color1 = tex2D(MotionBlurTex1,i.uv) / 3;
        return color0 + color1;
      }
      ENDCG
  }
}