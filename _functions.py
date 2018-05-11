import os

# OLD function to calculate the delta between two matrices
def calc_delta(x, y):
    combined = x
    for r_index, row in enumerate(x):
        for w_index, weight in enumerate(row):
            who1weight = y[r_index][w_index]
            who0weight = weight
            delta = (who1weight - who0weight) + 0.5
            combined[r_index, w_index] = delta
    return combined


# Get all the directory names inside a given dir
# This is NOT recursive
def get_dirlist(rootdir):
    dirlist = []
    with os.scandir(rootdir) as rit:
        for entry in rit:
            if not entry.name.startswith('.') and entry.is_dir():
                dirlist.append(entry.name)

    dirlist.sort() # Optional, in case you want sorted directory names
    return dirlist

# The improved formula for averaging
# The difference here is that it does not treat the two matrices as equal,
# But it looks at how big the influence of the dataset is (given by its percentage of the full dataset)
# and then uses a percentage (influence) of the delta instead of the delta / 2 (basic average)
def avg_func(w, delta, percentage):
    return w + (delta * percentage) / 100

# Combines two matrices using the gentle average formula
def gentle_avg(m1, m2, split_percentage):
    combined = m1
    for r_index, row in enumerate(m1):
        for w_index, weight in enumerate(row):
            clientW = m2[r_index][w_index]
            serverW = weight
            delta = (clientW - serverW)
            combined[r_index, w_index] = avg_func(serverW, delta, split_percentage)
    return combined
