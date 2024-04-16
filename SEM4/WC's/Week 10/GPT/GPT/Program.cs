using System;

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
        // Initialize input to hidden weights
        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < hiddenLayer.Length; j++)
            {
                inputHiddenWeights[i, j] = random.NextDouble() * 2 - 1; // Random weights between -1 and 1
            }
        }

        // Initialize hidden to output weights
        for (int i = 0; i < hiddenLayer.Length; i++)
        {
            for (int j = 0; j < output.Length; j++)
            {
                hiddenOutputWeights[i, j] = random.NextDouble() * 2 - 1; // Random weights between -1 and 1
            }
        }
    }

    public double[] Predict(double[] inputs)
    {
        // Forward pass
        input = inputs;

        // Calculate hidden layer values
        for (int j = 0; j < hiddenLayer.Length; j++)
        {
            double sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                sum += input[i] * inputHiddenWeights[i, j];
            }
            hiddenLayer[j] = Math.Tanh(sum);
        }

        // Calculate output values
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
        // Forward pass
        double[] predicted = Predict(inputs);

        // Calculate output layer errors
        double[] outputErrors = new double[output.Length];
        for (int i = 0; i < output.Length; i++)
        {
            outputErrors[i] = targets[i] - predicted[i];
        }

        // Update hidden to output weights
        for (int i = 0; i < hiddenLayer.Length; i++)
        {
            for (int j = 0; j < output.Length; j++)
            {
                hiddenOutputWeights[i, j] += outputErrors[j] * hiddenLayer[i];
            }
        }

        // Calculate hidden layer errors
        double[] hiddenErrors = new double[hiddenLayer.Length];
        for (int i = 0; i < hiddenLayer.Length; i++)
        {
            double sum = 0;
            for (int j = 0; j < output.Length; j++)
            {
                sum += outputErrors[j] * hiddenOutputWeights[i, j];
            }
            hiddenErrors[i] = sum * (1 - hiddenLayer[i] * hiddenLayer[i]); // Derivative of tanh
        }

        // Update input to hidden weights
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
        // Create a neural network with 4 input nodes, 1 hidden layer with 2 nodes, and 1 output node
        NeuralNetwork neuralNetwork = new NeuralNetwork(4, 2, 1);

        // Example data
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
            new double[] {1},
            new double[] {0}
        };

        // Training
        for (int epoch = 0; epoch < 1000; epoch++)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                neuralNetwork.Train(inputs[i], targets[i]);
            }
        }

        // Testing
        for (int i = 0; i < inputs.Length; i++)
        {
            double[] prediction = neuralNetwork.Predict(inputs[i]);
            Console.WriteLine($"Input: [{string.Join(", ", inputs[i])}], Predicted: {prediction[0]}");
        }
    }
}
