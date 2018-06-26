import numpy as np
import scipy.special
import matplotlib.pyplot
import os
import time
import math
import csv

# neural network class definition
class NeuralNetwork:
    
    # initialise the neural network
    def __init__(self, inputnodes, hiddennodes, outputnodes, learningrate):
        
        # set number of nodes in each input, hidden, output layer
        self.inodes = inputnodes
        self.hnodes = hiddennodes
        self.onodes = outputnodes
        
        self.wih = np.random.normal(0.0, pow(self.inodes, -0.5), (self.hnodes, self.inodes))
        self.who = np.random.normal(0.0, pow(self.hnodes, -0.5), (self.onodes, self.hnodes))
        
        # learning rate
        self.lr = learningrate
        
        # activation function is the sigmoid function
        self.activation_function = lambda x: scipy.special.expit(x)
        
        pass
    
    def get_output_nodes(self):
        return self.onodes

    
    # train the neural network
    def train(self, inputs_list, targets_list):
        # convert inputs list to 2d array
        inputs = np.array(inputs_list, ndmin=2).T
        targets = np.array(targets_list, ndmin=2).T
        
        # calculate signals into hidden layer
        hidden_inputs = np.dot(self.wih, inputs)
        # calculate the signals emerging from hidden layer
        hidden_outputs = self.activation_function(hidden_inputs)
        
        # calculate signals into final output layer
        final_inputs = np.dot(self.who, hidden_outputs)
        # calculate the signals emerging from final output layer
        final_outputs = self.activation_function(final_inputs)
        
        # output layer error is the (target - actual)
        output_errors = targets - final_outputs
        # hidden layer error is the output_errors, split by weights, recombined at hidden nodes
        hidden_errors = np.dot(self.who.T, output_errors) 
        
        # update the weights for the links between the hidden and output layers
        self.who += self.lr * np.dot((output_errors * final_outputs * (1.0 - final_outputs)), np.transpose(hidden_outputs))
        
        # update the weights for the links between the input and hidden layers
        self.wih += self.lr * np.dot((hidden_errors * hidden_outputs * (1.0 - hidden_outputs)), np.transpose(inputs))
        
        pass
    
    # Saves a trained model
    def saveModel(self, modelname):
        if not os.path.isdir(modelname):
            modelname = modelname + str(time.time())
            os.makedirs(modelname)
        np.save(modelname + "\\" + "wih", self.wih)
        np.save(modelname + "\\" + "who", self.who)
    
    # Loads a given model
    def loadModel(self, modelname):
        self.wih = np.load(modelname + "/wih.npy")
        self.who = np.load(modelname + "/who.npy")
        
    def update_info(self, wih, who):
        self.wih = wih
        self.who = who
    
    # query the neural network
    def query(self, inputs_list):
        # convert inputs list to 2d array
        inputs = np.array(inputs_list, ndmin=2).T
        
        # calculate signals into hidden layer
        hidden_inputs = np.dot(self.wih, inputs)
        # calculate the signals emerging from hidden layer
        hidden_outputs = self.activation_function(hidden_inputs)
        
        # calculate signals into final output layer
        final_inputs = np.dot(self.who, hidden_outputs)
        # calculate the signals emerging from final output layer
        final_outputs = self.activation_function(final_inputs)
        
        return final_outputs

"""
    Calculates the performance of the Neural Network by testing it on the test set
"""
def performance(n):
    # load the mnist test data CSV file into a list
    test_data_file = open("MNIST/mnist_test.csv", 'r')
    test_data_list = test_data_file.readlines()
    test_data_file.close()
    # test the neural network
    # scorecard for how well the network performs, initially empty
    scorecard = []
    #go through all the records in the test data set
    for record in test_data_list:
        all_values = record.split(',')
        correct_label = int(all_values[0])
        inputs = (np.asfarray(all_values[1:]) / 255.0 * 0.99) + 0.01
        outputs = n.query(inputs)
        label = np.argmax(outputs)
        if label == correct_label:
            scorecard.append(1)
        else:
            scorecard.append(0)
            pass
        pass 
    # calculate the performance score, the fraction of correct answers
    scorecard_array = np.asarray(scorecard)
    return scorecard_array.sum() / scorecard_array.size

"""
    Train the given Neural Network
"""
def train_nn(n, data_set = "MNIST/mnist_train.csv", epochs = 5):
    # load the mnist training data CSV file into a list
    training_data_file = open(data_set, 'r')
    training_data_list = training_data_file.readlines()
    training_data_file.close()

    # train the neural network
    # go through all records in the training data set
    for e in range(epochs):
        for record in training_data_list:
            # split the record by the ',' commas
            record = record.strip()
            all_values = record.split(',')
            # Dividing the raw inputs which are in the range 0-255 by 255 will bring them into the range 0-1. 
            #We then need to multiply by 0.99 to bring them into the range 0.0 - 0.99. 
            #We then add 0.01 to shift them up to the desired range 0.01 to 1.00.
            inputs = (np.asfarray(all_values[1:]) / 255.0 * 0.99) + 0.01
            # create the target output values (all 0.01, except the desired label which is 0.99)
            targets = np.zeros(n.get_output_nodes()) + 0.01
            # all_values[0] is the target label for this record
            targets[int(all_values[0])] = 0.99
            n.train(inputs, targets)
            pass
        pass

def writeCsvFile(fname, data, *args, **kwargs):
    """
    @param fname: string, name of file to write
    @param data: list of list of items

    Write data to file
    """
    mycsv = csv.writer(open(fname, 'wb'), *args, **kwargs)
    for row in data:
        mycsv.writerow(row)
    
"""
    Split the dataset into an x amount of datasets
"""
def split(dataset, split_amount):
    data_file= open(dataset, 'r')
    data_list= data_file.readlines()
    data_file.close()
    split_row_count = math.floor(len(data_list) / split_amount)
    for i in range(0, split_amount):
        lbound = i * split_row_count
        hbound = lbound + split_row_count
        subset = data_list[lbound:hbound]
        csv_file = "dataset" + str(i) + ".csv"
        mycsv = csv.writer(open(csv_file, 'w'), quoting=csv.QUOTE_MINIMAL, lineterminator="\n")
        for row in subset:
            row = row.strip()
            row = row.split(',')
            mycsv.writerow(row)

            
# number of input, hidden and output nodes
input_nodes = 784
hidden_nodes = 200
output_nodes = 10
learning_rate = 0.1

# Create the neural network object
n = NeuralNetwork(input_nodes, hidden_nodes, output_nodes, learning_rate)

# Find the csv file
files = [f for f in os.listdir('.') if os.path.isfile(f)]
csv_file = ""
for f in files:
    if ".csv" in f:
        csv_file = f
        break

# Possibly train a neural network
train_nn(n, data_set = csv_file, epochs = 5)

# Save the model
n.saveModel("mnist")

# Create the done file
fopen("done.txt", "w")
