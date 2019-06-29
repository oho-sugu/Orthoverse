Shader "Unlit/DepthOnly"
{
	SubShader{
		Tags {"Queue" = "Background+10"}

		ColorMask 0
		ZWrite On

		Pass{}
	}
}