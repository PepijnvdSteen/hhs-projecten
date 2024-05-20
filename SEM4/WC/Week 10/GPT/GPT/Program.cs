class NeuralNetwork
{
    private double[] input;
    private double[] hiddenLayer;
    private double[,] inputHiddenWeights;
    private double[] output;
    private double[,] hiddenOutputWeights;

    private Random random;

    public NeuralNetwork(int inputNodes, int hiddenNodes, int outputNodes)
    {
        input = new double[inputNodes];
        hiddenLayer = new double[hiddenNodes];
        inputHiddenWeights = new double[inputNodes, hiddenNodes];
        output = new double[outputNodes];
        hiddenOutputWeights = new double[hiddenNodes, outputNodes];

        random = new Random();

        InitializeWeights();
    }

    private void InitializeWeights()
    {
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < hiddenLayer.Length; j++)
            {
                inputHiddenWeights[i, j] = random.NextDouble() * 2 - 1; 
            }
        }
        
        for (int i = 0; i < hiddenLayer.Length; i++)
        {
            for (int j = 0; j < output.Length; j++)
            {
                hiddenOutputWeights[i, j] = random.NextDouble() * 2 - 1; 
            }
        }
    }

    public double[] Predict(double[] inputs)
    {
        input = inputs;
        
        for (int j = 0; j < hiddenLayer.Length; j++)
        {
            double sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i] * inputHiddenWeights[i, j];
            }
            hiddenLayer[j] = Math.Tanh(sum);
        }
        
        for (int j = 0; j < output.Length; j++)
        {
            double sum = 0;
            for (int i = 0; i < hiddenLayer.Length; i++)
            {
                sum += hiddenLayer[i] * hiddenOutputWeights[i, j];
            }
            output[j] = Math.Tanh(sum);
        }

        return output;
    }

    public void Train(double[] inputs, double[] targets)
    {
        double[] predicted = Predict(inputs);
        
        double[] outputErrors = new double[output.Length];
        for (int i = 0; i < output.Length; i++)
        {
            outputErrors[i] = targets[i] - predicted[i];
        }

        for (int i = 0; i < hiddenLayer.Length; i++)
        {
            for (int j = 0; j < output.Length; j++)
            {
                hiddenOutputWeights[i, j] += outputErrors[j] * hiddenLayer[i];
            }
        }

        double[] hiddenErrors = new double[hiddenLayer.Length];
        for (int i = 0; i < hiddenLayer.Length; i++)
        {
            double sum = 0;
            for (int j = 0; j < output.Length; j++)
            {
                sum += outputErrors[j] * hiddenOutputWeights[i, j];
            }
            hiddenErrors[i] = sum * (1 - hiddenLayer[i] * hiddenLayer[i]); 
        }

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < hiddenLayer.Length; j++)
            {
                inputHiddenWeights[i, j] += hiddenErrors[j] * inputs[i];
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        NeuralNetwork neuralNetwork = new NeuralNetwork(4, 2, 1);

        double[][] inputs = {
            new double[] {0, 0, 0, 0},
            new double[] {0, 0, 1, 1},
            new double[] {0, 1, 0, 1},
            new double[] {1, 0, 0, 1},
            new double[] {1, 1, 1, 0}
        };

        double[][] targets = {
            new double[] {0},
            new double[] {1},
            new double[] {1},
            new double[] {0},
            new double[] {0}
        };
        
        for (int epoch = 0; epoch < 50; epoch++)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                neuralNetwork.Train(inputs[i], targets[i]);
            }
        }

        for (int i = 0; i < inputs.Length; i++)
        {
            double[] prediction = neuralNetwork.Predict(inputs[i]);
            Console.WriteLine($"Input: [{string.Join(", ", inputs[i])}], Predicted: {prediction[0]}, Target:  [{string.Join(", ", targets[i])}]");
        }
    }
}
