using UnityEngine;
using Unity.Mathematics;

public class FeedForward : MonoBehaviour
{
    [SerializeField] private int[] m_LayerSizes;
    [SerializeField, NonReorderable] private float[] m_Neurons;
    [SerializeField, NonReorderable] private float[] m_Biases;
    [SerializeField, NonReorderable] private float[] m_Weights;

    private void Start()
    {
        this.InitializeFeedForward();
    }

    private void InitializeFeedForward()
    {
        if (this.m_LayerSizes.Length < 2) return;

        int neuronCount = this.m_LayerSizes[0];
        int biasCount = 0;
        int weightCount = 0;

        for (int l = 1; l < this.m_LayerSizes.Length; l++)
        {
            int layerSize = this.m_LayerSizes[l];
            biasCount += layerSize;
            neuronCount += layerSize;
            weightCount += this.m_LayerSizes[l - 1] * layerSize;
        }

        this.m_Neurons = new float[neuronCount];
        this.m_Biases = new float[biasCount];
        this.m_Weights = new float[weightCount];
    }

    private void SetInput(float[] inputs)
    {
        for (int i = 0; i < inputs.Length; i++)
        {
            this.m_Neurons[i] = inputs[i];
        }
    }

    private float[] GetOutput()
    {
        float[] output = new float[this.m_LayerSizes[this.m_LayerSizes.Length - 1]];

        for (int o = 0; o < output.Length; o++)
        {
            output[output.Length - o - 1] = this.m_Neurons[this.m_Neurons.Length - o - 1];
        }

        return output;
    }

    private void Inference()
    {
        int firstNeuronIdx = 0;
        for (int l = 0; l < this.m_LayerSizes.Length - 1; l++)
        {
            int currLayerSize = this.m_LayerSizes[l];
            int nextLayerSize = this.m_LayerSizes[l + 1];

            for (int nl = 0; nl < nextLayerSize; nl++)
            {
                float weightedSum = 0.0f;
                for (int cl = 0; cl < currLayerSize; cl++)
                {
                    // weightedSum += this.m_Neurons[firstNeuronIdx + cl];
                }

                weightedSum += this.m_Biases[firstNeuronIdx + nl];
            }
        }
    }
}
