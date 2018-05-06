# DistributedNeuralNetwork
>"A painful attempt to build a distributed neural network to cut down the time it takes to train one by distributing the training over multiple computers in a network."

The general idea is that we split up the data into a multitude of smaller (equally divided) subsets that will be distributed over an x amount of computers in a self proclaimed 'Distributed Neural Network'.
Each of the computers will then feed this data into their *own* Neural Network locally, and send back the final weights to the distributing (main neural network) server.

The server receives the locally trained weight matrices from the client computers in the network, and merges them with the already existing running network's weights. In it's current state, this is done by **averaging** both matrices.

Because of the distribution of the data set, the training should in theory be done significantly faster, because the client computers won't have to process such a big data set. 

Currently there is a trade-off between the time and accuracy. The more "splits" you make in the initial data set, the less observations the clients can make from the distributed (reduced) data set.

Advantages of this approach:

* Significantly faster training time;
* Relatively simple to implement;
* Can be done globally (over internet)

Disadvantages of this approach:

* Because of the averaging, might lose important observations;
* Prone to overfitting;
* Currently done on CPU, which will be slower than GPU;
* Requires a fast internet connection for distribution
