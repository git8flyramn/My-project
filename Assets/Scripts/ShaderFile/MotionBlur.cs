using UnityEngine;

public class MotionBlur : MonoBehaviour
{
    Material material;
    RenderTexture[] TexList;

    private void Awake()
    {
        Application.targetFrameRate = 30;
    }

    void RenderImage(RenderTexture src, RenderTexture dst)
    {
        if (material == null)
        {
            var shader = Shader.Find("Scripts/ShaderFile/MotionBlurShader");
            material = new Material(shader);
            material.hideFlags = HideFlags.DontSave;

            int w = src.width;
            int h = src.height;

            // RenderTextureの配列  
            TexList = new[] {
                new RenderTexture(w, h, 0, RenderTextureFormat.RGB565),
                new RenderTexture(w, h, 0, RenderTextureFormat.RGB565)
            };

            for (int i = 0; i < TexList.Length; i++)
            {
                // シェーダにレンダーテクスチャを渡す  
                material.SetTexture("_Tex" + i, TexList[i]);
            }
        }

        // 1フレームずらしたフレームバッファをコピーする  
        var tmp = TexList[Time.frameCount % 3];
        Graphics.Blit(src, tmp);
        // シェーダに渡されたレンダーテクスチャを合成して出力  
        Graphics.Blit(src, dst, material);
    }
}