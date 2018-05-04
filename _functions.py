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
