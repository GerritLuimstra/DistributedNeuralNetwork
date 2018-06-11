<?php
    require "php/auth.php";
    require "php/conn.php";
    require "php/functions.php";

    if(!isset($_GET['id'])) die("Invalid project id.");
    if(!owns_project($_GET['id'])) die("You do not have permission to access this project.");

    $project = get_project_info($_GET['id']);

    $neuralNetwork = get_neural_network($_GET['id']);
    $dataset = get_dataset($_GET['id']);
    $pool = get_training_pool($_GET['id']);
    $pool_statuses = ["open", "being-trained", "trained"];

    $results = get_results($project->token);
?>
<!DOCTYPE html>
<html>
    <head>
        <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
        <link type="text/css" rel="stylesheet" href="css/materialize.min.css"  media="screen,projection"/>
        <link rel="stylesheet" href="css/custom.css">
        <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    </head>

    <body>
        <input type="hidden" id="projectID" value="<?= $project->id ?>">
        <div class="overlay"></div>
        <div class="popup fileUpload z-depth-5">
            <div class="title"><h6></h6></div>
            <div class="content">
                <i class="material-icons close">close</i>
                <form action="#" method="POST" enctype="multipart/form-data">
                    <p></p>
                    <input type="file" id="fileUpload" name="theFile">
                    <label for="fileUpload" class="btn waves-effect waves-light">Choose a file</label>
                    <button class="btn waves-effect waves-light" type="submit" name="action">Upload
                        <i class="material-icons right">send</i>
                    </button>
                </form>
            </div>
        </div>

        <nav>
            <div class="nav-wrapper blue lighten-1">
                <a href="index.php" class="brand-logo">Project DNN</a>
                <ul id="nav-mobile" class="right">
                    <li><a href="sass.html">Logout</a></li>
                </ul>
            </div>
        </nav>


        <div class="container">
            <div class="row">
                <div class="col s2">
                    <img src="uploads/<?= sanitize($project->picture) ?>" alt="<?= sanitize($project->name) ?>" class="circle responsive-img" style="width: 100px; height: 100px;">
                </div>
                <div class="col s10">
                    <h2>Project <span style="color: #4caf50"><?= sanitize($project->name) ?></span></h2>
                    <h5>Token: <span style="color: #4caf50"><?= $project->token ?></span></h5>
                </div>

                <h6>"<?= sanitize($project->desc) ?>"</h6>
            </div>

            <div class="row">
                <h5>Files</h5>
                <h6>Neural Network</h6>
                <?php if($neuralNetwork){ ?>
                    <ul class="collection">
                        <li class="collection-item avatar">
                            <img src="img/neuralnetwork.png" alt="Neural Network" class="circle">
                            <h6><?= short_print(sanitize($neuralNetwork->name), 100) ?></h6>
                            <p><?= sanitize($neuralNetwork->size) ?></p>
                        </li>
                    </ul>
                <?php } else { ?>
                    <a class="waves-effect waves-light btn blue lighten-1" href="#" id="uploadNN"><i class="material-icons left">add</i>Add</a>
                    <p>You have not yet uploaded your neural network python script</p>
                <?php } ?>

                <h6>Dataset</h6>
                <?php if($dataset){ ?>
                    <ul class="collection">
                        <li class="collection-item avatar">
                            <img src="img/dataset.png" alt="Dataset" class="circle">
                            <h6><?= short_print(sanitize($dataset->name), 100) ?></h6>
                            <p><?= sanitize($dataset->size) ?></p>
                        </li>
                    </ul>
                <?php } else { ?>
                    <a class="waves-effect waves-light btn blue lighten-1" href="#" id="uploadDataset"><i class="material-icons left">add</i>Add</a>
                    <p>You have not yet uploaded your CSV dataset</p>
                <?php } ?>

                <h6>Training pool</h6>
                <?php if(!empty($pool)){ ?>
                    <ul class="collection">
                        <?php foreach($pool as $split) { ?>
                            <li class="collection-item avatar">
                                <img src="img/dataset.png" alt="Split" class="circle">
                                <h6><?= short_print(sanitize($split->name), 100) ?></h6>
                                <p><?= sanitize($split->size) ?>%</p>
                                <a href="#!" class="secondary-content"><i class="material-icons"><span class="status <?= $pool_statuses[$split->status] ?>"></span></i></a>
                            </li>
                        <?php } ?>
                    </ul>
                <?php } else { ?>
                    <p>You don't have any splits in your training pool right now. You might want to start with splitting up the dataset.</p>
                <?php } ?>

                <h6>Results</h6>
                <?php if(can_merge($project->id)){ ?>
                    <p>All your datasets have been trained. You can now merge them.</p>
                    <a class="waves-effect waves-light btn blue lighten-1" href="#" id="mergeDatasets"><i class="material-icons left">settings</i>Merge</a>
                <?php } else { ?>
                    <p>As soon as the training of all datasets is done, merging will be available.</p>
                    <a class="waves-effect waves-light btn disabled blue lighten-1" href="#" id="mergeDatasets"><i class="material-icons left">settings</i>Merge</a>
                <?php } ?>
                <?php if(!empty($results)){ ?>
                    <ul class="collection">
                        <?php foreach($results as $folder => $contents) { ?>
                            <li class="collection-item">
                                <h6><?= $folder ?></h6>
                                <ul class="collection">
                                    <?php foreach($contents as $file) { ?>
                                        <li class="collection-item">
                                            <p><?= $file ?></p>
                                        </li>
                                    <?php } ?>
                                </ul>
                            </li>
                        <?php } ?>
                    </ul>
                <?php } else { ?>
                    <p>There are no results yet.</p>
                <?php } ?>

            </div>

        </div>

        <script type="text/javascript" src="js/materialize.min.js"></script>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src="js/main.js"></script>
    </body>
</html>
