import numpy as np

serverWIH= np.load("server_wih.npy")
serverWHO = np.load("server_who.npy")

def avg_func(w, delta, percentage):
    return w + delta * 1/(100/percentage)

def gentle_avg(m1, m2, split_percentage):
    combined = m1
    for r_index, row in enumerate(m1):
        for w_index, weight in enumerate(row):
            clientW = m2[r_index][w_index]
            serverW = weight
            delta = (clientW - serverW)
            combined[r_index, w_index] = avg_func(serverW, delta, split_percentage)
    return combined


clientWIH = np.load("client_wih.npy")
clientWHO = np.load("client_who.npy")

#serverWIH = np.mean( np.array([ serverWIH, clientWIH ]), axis=0 )
#serverWHO = np.mean( np.array([ serverWHO, clientWHO ]), axis=0 )
serverWIH = gentle_avg(serverWIH, clientWIH, 20)
serverWHO = gentle_avg(serverWHO, clientWHO, 20)

np.save("merged_wih", serverWIH)
np.save("merged_who", serverWHO)
