using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transparencia : MonoBehaviour {

    Renderer r;
    Material [] standardShaderMaterial;

	void Start () {
        r = gameObject.GetComponent<Renderer>();
		standardShaderMaterial = r.materials;

	}

	void DesactivaTransparencia()
	{

		setOpaque();
		foreach (Material mat in standardShaderMaterial)
		{
			Color p = mat.color;
			p.a = 1f;
			mat.color = p;
		}

	}

    void ActivaTransparencia()
    {
		setTransparent();

		foreach (Material mat in standardShaderMaterial)
		{

			Color p = mat.color;
			p.a = 0.2f;
			mat.color = p;
		}
	}

    void setOpaque()
    {
		for (int i = 0; i < standardShaderMaterial.Length; i++)
		{
			standardShaderMaterial[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
			standardShaderMaterial[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
			standardShaderMaterial[i].SetInt("_ZWrite", 1);
			standardShaderMaterial[i].DisableKeyword("_ALPHATEST_ON");
			standardShaderMaterial[i].DisableKeyword("_ALPHABLEND_ON");
			standardShaderMaterial[i].DisableKeyword("_ALPHAPREMULTIPLY_ON");
			standardShaderMaterial[i].renderQueue = -1;
		}
    }

	void setTransparent()
	{
		for (int i = 0; i < standardShaderMaterial.Length; i++)
		{
			standardShaderMaterial[i].SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
			standardShaderMaterial[i].SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
			standardShaderMaterial[i].SetInt("_ZWrite", 0);
			standardShaderMaterial[i].DisableKeyword("_ALPHATEST_ON");
			standardShaderMaterial[i].DisableKeyword("_ALPHABLEND_ON");
			standardShaderMaterial[i].EnableKeyword("_ALPHAPREMULTIPLY_ON");
			standardShaderMaterial[i].renderQueue = 3000;
		}
	}
}
