﻿sampler2D implicitInput : register(s0);

static const float colorMap[] = {
    0.00000, 0.00392, 0.01176, 0.01569, 0.01961, 0.02745, 0.03137, 0.03922, 0.04706, 0.05490, 0.07059, 0.07059, 0.07843, 
    0.08627, 0.09412, 0.10588, 0.11373, 0.12549, 0.13725, 0.14902, 0.16078, 0.17255, 0.18431, 0.19608, 0.20784, 0.21961, 
    0.23529, 0.24706, 0.26275, 0.27843, 0.29412, 0.30980, 0.32549, 0.34118, 0.35686, 0.37255, 0.39216, 0.40784, 0.42745, 
    0.44706, 0.46275, 0.48235, 0.50196, 0.52157, 0.54118, 0.56471, 0.58431, 0.60784, 0.62745, 0.65098, 0.67059, 0.69412, 
    0.71765, 0.74118, 0.76471, 0.79216, 0.81569, 0.83922, 0.86667, 0.89020, 0.91765, 0.94510, 0.97255, 1.00000
};

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 color = tex2D(implicitInput, uv);

    color.r = colorMap[color.r * 63];
    color.g = colorMap[color.g * 63];
    color.b = colorMap[color.b * 63];
    color.a = color.a;

    return color;
}