import random
import math

class SimpleNeuralNetwork:
  """
  A simple neural network with 1 hidden layer, no training algorithm
  """
  def __init__(self, num_inputs, num_hidden, learning_rate=0.1):
    self.num_inputs = num_inputs
    self.num_hidden = num_hidden
    self.learning_rate = learning_rate

    # Randomly initialize weights with small values
    self.weights_hidden = [[random.uniform(-1, 1) for _ in range(num_inputs + 1)] for _ in range(num_hidden)]  # +1 for bias
    self.weights_output = [random.uniform(-1, 1) for _ in range(num_hidden + 1)]  # +1 for bias

  def predict(self, inputs):
    """
    Performs a forward pass through the network
    """
    # Add a bias term of 1
    inputs_with_bias = inputs + [1]

    # Calculate activation for hidden layer
    hidden_activations = [self.sigmoid(sum(w * i for w, i in zip(weights, inputs_with_bias))) for weights in self.weights_hidden]
    hidden_activations_with_bias = hidden_activations + [1]  # Add bias term

    # Calculate output activation
    output = self.sigmoid(sum(w * i for w, i in zip(self.weights_output, hidden_activations_with_bias)))
    return output

  def sigmoid(self, x):
    """
    Sigmoid activation function
    """
    return 1 / (1 + math.exp(-x))

# Example usage
network = SimpleNeuralNetwork(4, 3)  # 4 inputs, 3 hidden neurons

# Sample input
inputs = [0.5, 0.2, 0.8, 0.1]

# Get prediction
output = network.predict(inputs)
print(f"Network output for input {inputs}: {output}")
