using System;

public class SimpleNeuralNetwork
{
    private readonly int _numInputs;
    private readonly int _numHidden;
    private readonly double[] _weightsHidden;
    private readonly double _weightOutput;

    public SimpleNeuralNetwork(int numInputs, int numHidden)
    {
        _numInputs = numInputs;
        _numHidden = numHidden;

        // Randomly initialize weights with small values
        _weightsHidden = new double[_numHidden];
        for (int i = 0; i < _numHidden; i++)
        {
            _weightsHidden[i] = new Random().NextDouble() * 2 - 1; // Range between -1 and 1
        }

        _weightOutput = new Random().NextDouble() * 2 - 1; // Range between -1 and 1
    }

    public double Predict(double[] inputs)
    {
        if (inputs.Length != _numInputs)
        {
            throw new ArgumentException("Input length must match the number of input nodes");
        }

        // Calculate activation for hidden layer
        double hiddenSum = 0;
        for (int i = 0; i < _numInputs; i++)
        {
            hiddenSum += inputs[i] * _weightsHidden[i];
        }
        hiddenSum += 1; // Add bias term (implicitly assumed input has a bias of 1)

        double hiddenActivation = Sigmoid(hiddenSum);

        // Calculate output activation
        double output = hiddenActivation * _weightOutput;
        return output;
    }

    private double Sigmoid(double x)
    {
        return 1.0 / (1.0 + Math.Exp(-x));
    }

    // Example usage (Replace with your data)
    public static void Main(string[] args)
    {
        // Sample data (replace with 1 to 5 data points)
        double[][] data = new double[][] {
            new double[] { 0.5, 0.2, 0.8, 0.1 }, // Input 1
            new double[] { 0.3, 0.7, 0.1, 0.9 }, // Input 2
        };

        // Expected outputs (replace with corresponding outputs)
        double[] expectedOutputs = new double[] { 0.7, 0.2 };

        // Create network with 4 inputs and 3 hidden neurons
        SimpleNeuralNetwork network = new SimpleNeuralNetwork(4, 3);

        for (int i = 0; i < data.Length; i++)
        {
            double output = network.Predict(data[i]);
            Console.WriteLine($"Input {i+1}: {string.Join(", ", data[i])}, Expected Output: {expectedOutputs[i]}, Network Output: {output}");
        }
    }
}
